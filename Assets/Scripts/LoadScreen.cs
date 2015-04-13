using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {
	// Use this for initialization
	public int level;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		if(Application.GetStreamProgressForLevel("Level"+level+"-Village") ==1){ //if we have loaded the level
			Application.LoadLevel("Level"+level+"Cutscene");					 //load this scene
		}
	}
}