using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {
	// Test comment
	// Use this for initialization

	public Canvas gameOver;
    Player playerScript;
	public GameObject highScoreButton;
	bool buttonCheck = false;
	void Start()
	{

		GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameOver.enabled = false;
		Debug.Log ( "High Score is: "+PlayerPrefs.GetFloat("High Score"));
		Debug.Log ("0 is standard level, 1 is endless mode: " +PlayerPrefs.GetInt ("Endless"));
	}

	void Update(){
		//if(dead.gameObject.GetComponent<Player>().isdead = true){
			
		if (playerScript.isdead == true) {
			if(buttonCheck == false)
			{
				Time.timeScale = 0f;//freezes all instances in the game
			}
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
			//Time.timeScale = 0f;
			//Debug.Log ("you are dead");
			gameOver.enabled = true;
			if(PlayerPrefs.GetInt ("Endless")==0)
			{
				highScoreButton.transform.gameObject.SetActive(false); 
			}
		} else {
			gameOver.enabled = false;
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		}

	}

	public void OnClickRetry()
	{
		buttonCheck = true;
		//Time.timeScale = 1f;
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
		//needs to look @ PlayerPrefs and load where player died last
	}
	public void OnClickQuit()
	{
		PlayerPrefs.SetInt ("Endless",0);
		Application.Quit ();
	}
	public void OnClickHighScore()
	{
		buttonCheck = true;
		Time.timeScale = 1f;
		//Time.timeScale = 1f;
		PlayerPrefs.SetInt ("Endless",0);
		Application.LoadLevel ("HighScore");
	}

	public void onClickMain()
	{
		buttonCheck = true;
		Time.timeScale = 1f;
		//Time.timeScale = 1f;
		PlayerPrefs.SetInt ("Endless", 0);
		Application.LoadLevel ("StartMenu");
	}
}


