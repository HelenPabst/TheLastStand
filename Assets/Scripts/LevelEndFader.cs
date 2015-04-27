using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndFader : MonoBehaviour {
	//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays before fading
	private float pauseBeforeFade = 3.0f;
	//if the text should begin to fade
	private bool outFade = false;
	//a reference to the image
	private Image thisFader;
	//Speed at which the image fades out
	private float fadeSpeed = 2.0f;
	//backup for normal deltaTime
	private float myDelta;
	//boolean for the outro text to reference
	public bool endMessage = false;
	//name of next scene to load
	public string nextScene;
	//reference to the player
	Player player;


	// Make references to other objects and define myDelta for when time stops
	void Start () {
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		thisFader = gameObject.GetComponent<Image>();
		myDelta = Time.deltaTime;
	}
	
	// 
	void Update () {
		//fade out
		if(outFade){
			FadetoBlack();
		}
		//give message time to be seen
		else if(endMessage){
			textCounter = textCounter+myDelta;
			if(textCounter >= pauseBeforeFade){
				outFade = true;
				endMessage = false;
			}
		}
		//freeze player and signal that message should display
		else if(player.levelFinish){
			endMessage = true;
			player.pause = true;
			//Time.timeScale = 0f;
		}
	}

	//fades scene to black and then loads next scene
	void FadetoBlack(){
		/*
		Time.timeScale = 1f;
		Application.LoadLevel(nextScene);*/

		thisFader.color = Color.Lerp(thisFader.color, Color.black, fadeSpeed * myDelta);
		if(thisFader.color.a >= 0.95f)
		{
			thisFader.color = Color.black;
			Time.timeScale = 1f;
			Application.LoadLevel(nextScene);
		}
	}
}
