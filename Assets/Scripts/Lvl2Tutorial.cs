using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lvl2Tutorial : MonoBehaviour {

	public Text tutorialText;
	// Use this for initialization
	void Start () 
	{
		//plays at same time as ballista spawn
		Invoke ("DisplayBallistaText", 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void DisplayBallistaText()
	{
		tutorialText.gameObject.SetActive(true);
		Invoke ("RemoveText", 6.0f);
	}
	void RemoveText()
	{
		tutorialText.gameObject.SetActive(false);
	}
}
