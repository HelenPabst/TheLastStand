//notes to self: 
//Still have to manually make the two arrays the same size in inspector.  Is there a way to fix this?
//Resize function doesn't work right

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
	//Next scene to load. Old code, does not work with exe 
	//public Object nextScene;
	//Tells if needs to fade
	private bool doFade = false;
	//Tells if needs to come back from fade
	private bool doUnfade = false;
	//Speed at which the image fades in and out
	private float fadeSpeed = 2.0f;
	//Timer
	private float timer = 0.0f;


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
		//Resize(); //Does not work, needs to be fixed.
		nextFrameTime = cutsceneTime[0];
		GetComponent<SpriteRenderer>().sprite = cutsceneSprites[0];

		GetComponent<SpriteRenderer>().color = Color.clear;//start 'faded'
		doUnfade = true;//fade to image from start

	}

	//Calls fading functions and updates timer
	void Update(){

		//if currently fading in or out, the timer does not increment
		if(doFade){
			FadetoBlack();
		}
		else if(doUnfade){
			FadetoImage();
		}
		else{
			timer += Time.deltaTime;
			if(timer >= nextFrameTime){
				doFade = true;
			}
		}

		/*
		//succesful no-fading code
		timer += Time.deltaTime;
		if(currentImage < (cutsceneSprites.Length)-1)
		{
			if(timer >= nextFrameTime){
				//needFade = true;
				currentImage++;
				nextFrameTime += cutsceneTime[currentImage];
				GetComponent<SpriteRenderer>().sprite = cutsceneSprites[currentImage];
			}

		}
		else{
			if(timer >= nextFrameTime)
			{
				//Application.LoadLevel(nextScene.name);
				Application.LoadLevel(Application.loadedLevel+1);//Assumes next scene is +1 in build order
			}
        }*/
        
    }

    /*
	//Code to resize the image.  DOES NOT CURRENTLY WORK.
	void Resize()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		
		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		transform.localScale = new Vector3(
			worldScreenWidth / sr.sprite.bounds.size.x,
			worldScreenHeight / sr.sprite.bounds.size.y, 1);
	}*/

	//Function for fading to black.  Also handles changing the sprite.  If the current image was the last image, it goes to the next Scene after fading to black.
	//Works by making the image transparent, exposing the black background.
	void FadetoBlack(){
		GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, fadeSpeed * Time.deltaTime);
		//once close enough to transparent, go fully transparent and undergo logic to display next image or go to next Scene
		if(GetComponent<SpriteRenderer>().color.a <= 0.05f){
			GetComponent<SpriteRenderer>().color = Color.clear;
			doFade = false;
			currentImage++;
			if(currentImage < cutsceneSprites.Length){
				GetComponent<SpriteRenderer>().sprite = cutsceneSprites[currentImage];
				nextFrameTime += cutsceneTime[currentImage];
			}
			else{
				//Application.LoadLevel(nextScene.name);
				Application.LoadLevel(Application.loadedLevel+1);//Assumes next scene is +1 in build order
			}
			doUnfade = true;
		}
	}
	//Function for fading to image
	void FadetoImage()
	{
		GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.white, fadeSpeed * Time.deltaTime);
		//Once close enough to fully visable, go fully visable and unset doUnfade to allow counter to run
		if(GetComponent<SpriteRenderer>().color.a >= 0.95f)
		{
			GetComponent<SpriteRenderer>().color = Color.white;
			doUnfade = false;
		}
	}


	/*old gui code
	//Keeps the current display updated to the correct image.
	oid OnGUI() {
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
