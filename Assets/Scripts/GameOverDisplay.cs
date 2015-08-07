using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {
	// Test comment
	// Use this for initialization

	public Canvas gameOver;
	public GameObject highScoreButton;

	
	void Start()
	{

		GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		gameOver.enabled = false;
		Debug.Log ( "High Score is: "+PlayerPrefs.GetFloat("High Score"));
		Debug.Log ("0 is standard level, 1 is endless mode: " +PlayerPrefs.GetInt ("Endless"));
	}

	void Update(){
		//if(dead.gameObject.GetComponent<Player>().isdead = true){
			
		if (Player.isdead == true) {
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
	
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
		PlayerPrefs.SetInt ("Endless",0);
		Application.LoadLevel ("HighScore");
	}

	public void onClickMain()
	{
		PlayerPrefs.SetInt ("Endless", 0);
		Application.LoadLevel ("StartMenu");
	}
}


