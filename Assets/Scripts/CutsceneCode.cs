//notes to self: 
//Maybe do fade ins and outs.
//The white screen is back.  Will doing fadeouts cover it up?

using UnityEngine;
using System.Collections;

public class CutsceneCode : MonoBehaviour {
	//An array of plain images
	public Texture[] cutsceneImage;
	//An array of time durations corresponding to CutsceneImage
	public float[] cutsceneTime;
	//Holds the time for the next still image to trigger
	private float nextFrameTime;
	//Which image the sequence starts on.
	private int currentImage = 0;
	//Next scene to load
	public Object nextScene;

	/* Old code for click-based progression
	//Responds to user clicks to update scene.
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			//When clicking on last image, go to next scene.
			if(currentImage==CutsceneImage.Length-1){
				Application.LoadLevel(nextScene.name);
			}
			//When clicking on all other images, go to next image.
			else{
				currentImage++;
			}     
		}
	}*/

	//Sets nextFrameTime to allow the first cutscene image.
	void Start(){
		nextFrameTime = cutsceneTime[0];
	}

	//Keeps the current display updated to the correct image.
	void OnGUI() {
		if (Time.time >= nextFrameTime) {
			currentImage++;
			if (currentImage < cutsceneImage.Length) {
				nextFrameTime += cutsceneTime [currentImage];
			}
			else{
				Application.LoadLevel(nextScene.name);
			}
		}
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), cutsceneImage [currentImage]);
	}
}
