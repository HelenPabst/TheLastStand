using UnityEngine;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Label(new Rect(600, 0, 200, 100), "High Score: "+PlayerPrefs.GetFloat("High Score"));


	}
}
