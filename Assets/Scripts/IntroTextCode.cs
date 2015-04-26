using UnityEngine;
using System.Collections;

public class IntroTextCode : MonoBehaviour {
	//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays up and paused
	private float countFin = 2.0f;
	//if the text should stay up and paused
	private bool textStay = true;
	//a reference to the image
	private Images thisText;
	//Speed at which the image fades out
	private float fadeSpeed = 4.0f;
	//backup for normal deltaTime
	private float myDelta;
	//reference to the player
	Player player;

	// prevents any action at start
	void Start () {
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		player.pause = true;
		thisText = gameObject.GetComponent<Image>();//Does not recognize Image as valid, not sure what else to use
		myDelta = Time.deltaTime;
		Time.timeScale = 0f;//freezes all instances in the game
	}

	//
	void Update () {
		if (textStay) {
			if (textCounter >= countFin) {
				textStay = false;
				Time.timeScale = 1f;
				player.pause = true;
			} else {
				textCounter = textCounter + myDelta;//Time.deltaTime;
			}
		} 
		else {
			FadetoClear();
		}
	}

	//sprite version
	void FadetoClear(){
		GetComponent<SpriteRenderer>().color = Color.Lerp(thisText.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(thisText.color.a >= 0.05f)
		{
			thisText.color = Color.clear;
			gameObject.SetActive(false);
		}
	}

	/*
	void FadetoClear(){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(guiTexture.color.a >= 0.05f)
		{
			guiTexture.color = Color.clear;
			gameObject.SetActive(false);
		}
	}*/
}
