//notes to self: 
//Maybe do fade ins and outs.
//after some time add text saying 'click to skip'?

using UnityEngine;
using System.Collections;

public class CutsceneCode : MonoBehaviour {
	//An array of plain images
	public Texture[] CutsceneImage;
	//Which image the sequence starts on.
	private int currentImage = 0;
	//Next scene to load
	public Object nextScene;

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
	}

	//Keeps the current display updated to the correct image.
	void OnGUI() {
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), CutsceneImage [currentImage]); 
	}
}
