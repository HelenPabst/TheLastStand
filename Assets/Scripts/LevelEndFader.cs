using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndFader : MonoBehaviour {
	//A time counter that runs independantly of the Time
	private float textCounter = 0.0f;
	//how long the text stays before fading
	private float pauseBeforeFade = 1.5f;
	//if the text should begin to fade
	private bool outFade = false;
	//a reference to the image
	private Image thisFader;
	//Speed at which the image fades out
	private float fadeSpeed = 1.5f;
	//backup for normal deltaTime
	private float myDelta;
	//boolean for the outro text to reference
	public bool endMessage = false;
	//name of next scene to load
	public string nextScene;
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
		//fade out after displaying outro text
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
		//triggers outrotext and pauses player when level is complete
		else if(player.levelFinish){
			endMessage = true;
			player.pause = true;
		}
	}

	//fades scene to black and then loads next scene once fully black
	void FadetoBlack(){
		thisFader.color = Color.Lerp(thisFader.color, Color.black, fadeSpeed * myDelta);
		if(thisFader.color.a >= 0.97f)
		{
			thisFader.color = Color.black;
			Time.timeScale = 1f;
			Application.LoadLevel(nextScene);
		}
	}
}
