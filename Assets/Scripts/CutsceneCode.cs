//notes to self: 
//Do fade ins and outs.
//Resize doesn't work right

using UnityEngine;
using System.Collections;

public class CutsceneCode : MonoBehaviour {
	//An array of plain images, old code
	//public Texture[] cutsceneImage;
	//An array of cutscene images
	public Sprite[] cutsceneSprites;
	//An array of time durations corresponding to CutsceneImage
	public float[] cutsceneTime;
	//Holds the time for the next still image to trigger
	private float nextFrameTime;
	//Which image the sequence starts on.
	private int currentImage = 0;
	//Next scene to load
	public Object nextScene;
	//Reference to the fader script, maybe unneccesary
	//public FaderCode fadeCode;
	//Tells if needs to fade
	private bool startFade = false;

	//Timer
	private float timer = 0.0f;
	//


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

	//Sets initial values to allow the first cutscene image.
	void Start(){
		//Resize();
		nextFrameTime = cutsceneTime[0];
		GetComponent<SpriteRenderer>().sprite = cutsceneSprites[0];

	}

	//
	void Update(){
		//succesful no-fading code
		timer += Time.deltaTime;
		if(currentImage < cutsceneSprites.Length){
			if(timer >= nextFrameTime){
				//needFade = true;
				currentImage++;
				nextFrameTime += cutsceneTime[currentImage];
				GetComponent<SpriteRenderer>().sprite = cutsceneSprites[currentImage];
			}
		}
		else{
			Application.LoadLevel(nextScene.name);
		}
	}

	//Code to resize the image
	void Resize()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		
		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		transform.localScale = new Vector3(
			worldScreenWidth / sr.sprite.bounds.size.x,
			worldScreenHeight / sr.sprite.bounds.size.y, 1);
	}

	/*old gui code
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
	}*/
}
