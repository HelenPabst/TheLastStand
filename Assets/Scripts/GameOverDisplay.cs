using UnityEngine;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {
	// Test comment
	// Use this for initialization

	public Canvas gameOver;

	
	void Start()
	{
		GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		gameOver.enabled = false;
		Debug.Log ( "High Score is: "+PlayerPrefs.GetFloat("High Score"));
	}

	void Update(){
		//if(dead.gameObject.GetComponent<Player>().isdead = true){
			
		if (Player.isdead == true) {
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
	
			Debug.Log ("you are dead");
			gameOver.enabled = true;
		} else {
			gameOver.enabled = false;
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		}

	}
	public void OnClickRetry()
	{
		Application.LoadLevel(Application.loadedLevel);
		//needs to look @ PlayerPrefs and load where player died last
	}
	public void OnClickQuit()
	{
		Application.Quit ();
	}
	public void onClickSelect()
	{
		Application.LoadLevel ("LevelSelectMenu");
	}
	public void onClickStart()
	{
		Application.LoadLevel ("StartMenu");
	}
}


