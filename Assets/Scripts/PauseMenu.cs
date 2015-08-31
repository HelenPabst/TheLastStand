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
		
		PlayerPrefs.SetString("Rank 1","VGD");
		PlayerPrefs.SetFloat("Score 1",0);
		
		PlayerPrefs.SetString("Rank 2","VGD");
		PlayerPrefs.SetFloat("Score 2",0);
		
		PlayerPrefs.SetString("Rank 3","VGD");
		PlayerPrefs.SetFloat("Score 3",0);
		
		PlayerPrefs.SetString("Rank 4","VGD");
		PlayerPrefs.SetFloat("Score 4",0);
		
		PlayerPrefs.SetString("Rank 5","VGD");
		PlayerPrefs.SetFloat("Score 5",0);
		
		PlayerPrefs.SetString("Rank 6","VGD");
		PlayerPrefs.SetFloat("Score 6",0);
		
		PlayerPrefs.SetString("Rank 7","VGD");
		PlayerPrefs.SetFloat("Score 7",0);
		
		PlayerPrefs.SetString("Rank 8","VGD");
		PlayerPrefs.SetFloat("Score 8",0);
		
		PlayerPrefs.SetString("Rank 9","VGD");
		PlayerPrefs.SetFloat("Score 9",0);
		
		PlayerPrefs.SetString("Rank 10","VGD");
		PlayerPrefs.SetFloat("Score 10",0);

		Debug.Log ("Score Deleted! Current high score is "+PlayerPrefs.GetFloat("High Score"));
	}
	public void OnClickBack()
	{
		optionsPanel.SetActive(false);
		pausePanel.SetActive(true);
	}



}
	