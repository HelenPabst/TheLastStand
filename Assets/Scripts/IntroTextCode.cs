using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroTextCode : MonoBehaviour {
	//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays up and paused
	private float countFin = 2.0f;
	//if the text should stay up and paused
	private bool textStay = true;
	//a reference to the image
	private Image thisText;
	//Speed at which the image fades out
	private float fadeSpeed = 1.0f;
	//backup for normal deltaTime
	private float myDelta;
	//reference to the player
	Player player;

	// prevents any action at start
	void Start () {
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		player.pause = true;
		thisText = gameObject.GetComponent<Image>();
		myDelta = Time.deltaTime;
		Time.timeScale = 0f;//freezes all instances in the game
	}

	//
	void Update () {
		//keeps text up and pauses action in first few seconds
		if (textStay) {
			//after a few seconds, unpause and start fading
			if (textCounter >= countFin) {
				textStay = false;
				Time.timeScale = 1f;
				player.pause = false;
			}
			//measure how long has been paused and keeps paused
			else {
				textCounter = textCounter + myDelta;//Time.deltaTime;
				player.pause = true;
			}
		} 
		//text fades after a few seconds
		else {
			FadetoClear();
		}
	}

	//fades out the intro text, then disables text when done
	void FadetoClear(){
		thisText.color = Color.Lerp(thisText.color, Color.clear, fadeSpeed * Time.deltaTime);
		if(thisText.color.a <= 0.35f)
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
