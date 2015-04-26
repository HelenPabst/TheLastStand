using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndFader : MonoBehaviour {
	//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays before fading
	private float pauseBeforeFade = 2.0f;
	//if the text should begin to fade
	private bool outFade = false;
	//a reference to the image
	private Image thisFader;
	//Speed at which the image fades out
	private float fadeSpeed = 1.0f;
	//backup for normal deltaTime
	private float myDelta;
	//boolean for the outro text to reference
	public bool levelEnded = false;
	//reference to the player
	Player player;


	// Use this for initialization
	void Start () {
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		thisFader = gameObject.GetComponent<Image>();
		myDelta = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(outFade){

		}
		else if(levelEnded){
			textCounter = textCounter+myDelta;

		}
		else if(player.levelFinish){
			levelEnded = true;
			player.pause = true;
			Time.timeScale = 0f;
		}
	}
}
