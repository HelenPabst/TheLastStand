using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public bool paused = false;
	public GameObject pausePanel,optionsPanel;
	Player player;

	void Start(){//This ensures nothing is enabled or frozen on start
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		//GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		pauseMenu.enabled = false;
		AudioListener.pause = false;
	}

		void Update()
		{

		if (Input.GetKeyUp (KeyCode.Escape)) {
			paused = togglePause();//bool paused is toggled 

		}
	}


//The following lines handle the timescale of the game
	bool togglePause()
		{
			if(Time.timeScale == 0f)
			{

			//GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
			player.pause = false;
			pauseMenu.enabled = false;
			AudioListener.pause = false;
				Time.timeScale = 1f;
				return(false);
			}
			else
			{
			player.pause = true;
			pauseMenu.enabled = true;
			//GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;//Player script is paused 
			Time.timeScale = 0f;//freezes all instances in the game
			AudioListener.pause = true;//pauses the music 
				return(true);    
			}
		}

	//The following lines involve the button operations of the PauseMenu
	public void OnClickQuit()
	{
		Application.Quit ();
	}
	public void OnClickMainMenu(){
		//GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		player.pause = false;
		pauseMenu.enabled = false;
		AudioListener.pause = false;
		Time.timeScale = 1f;
		Application.LoadLevel("StartMenu");

	}
	public void OnClickResume(){
		Time.timeScale = 1f;//Everything is unfrozen
		//GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		player.pause = false;
		AudioListener.pause = false;
		pauseMenu.enabled = false;
	}
	public void OnClickOptions()
	{
		optionsPanel.SetActive(true);
		pausePanel.SetActive(false);
	}
	public void OnClickSoundOn()
	{
		//Play indicator sound
		AudioListener.volume = 1;
		
	}
	public void OnClickSoundOff()
	{
		AudioListener.volume = 0;
		
	}
	public void OnClickDelete()
	{
		PlayerPrefs.SetFloat ("High Score", 0);
		Debug.Log ("Score Deleted! Current high score is "+PlayerPrefs.GetFloat("High Score"));
	}
	public void OnClickBack()
	{
		optionsPanel.SetActive(false);
		pausePanel.SetActive(true);
	}



}
	