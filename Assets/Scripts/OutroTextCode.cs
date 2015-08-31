using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutroTextCode : MonoBehaviour {
	//a reference to the image
	private Image thisText;
	//Reference to the fader
	LevelEndFader fader;
	//find initial references
	
	void Start () {
		fader = GameObject.Find("FadeImage").GetComponent<LevelEndFader>();
		thisText = gameObject.GetComponent<Image>();
	}
	
	//when outro has started, make outro text visable and stop scene
	void Update () {
		//makes outro text visable and stops scene (except on lvl 3)
		if(fader.endMessage){

			if(Application.loadedLevelName != "Level3-Temple")
			{
				thisText.color = Color.white;
			}
			Time.timeScale = 0f;
		}
	}

}
