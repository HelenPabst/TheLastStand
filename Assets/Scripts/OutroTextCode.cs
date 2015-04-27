using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutroTextCode : MonoBehaviour {
	/*//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays up and paused
	private float countFin = 2.0f;
	//if the text should begin to fade
	private bool textFade = false;*/
	//a reference to the image
	private Image thisText;
	/*//Speed at which the image fades out
	private float fadeSpeed = 1.0f;
	//backup for normal deltaTime
	private float myDelta;
	//reference to the player
	Player player;*/
	//Reference to the fader
	LevelEndFader fader;

	//make references to objects
	void Start () {
		fader = gameObject.GetComponentInChildren<LevelEndFader>();
		thisText = gameObject.GetComponent<Image>();
		/*
		player = (Player)GameObject.Find("Player").GetComponent("Player");

		thisText = gameObject.GetComponent<Image>();
		myDelta = Time.deltaTime;
		*/
	}
	
	// make outro visable and pause scene
	void Update () {
		if(fader.endMessage){
			thisText.color = Color.white;
			Time.timeScale = 0f;
		}
		/*if(textFade){

		}
		else if(player.levelFinish){
			Time.timeScale = 0f;
			thisText.color = Color.white;
			textCounter = textCounter+myDelta;
			if(textCounter >= countFin){
				textFade = true;
			}
		}*/
	}
}
