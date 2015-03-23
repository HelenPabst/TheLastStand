using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public bool paused = false;


	void Start(){//This ensures nothing is enabled or frozen on start
		GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
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
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
			pauseMenu.enabled = false;
			AudioListener.pause = false;
				Time.timeScale = 1f;
				return(false);
			}
			else
			{
			pauseMenu.enabled = true;
			GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;//Player script is paused 
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
		Application.LoadLevel("StartMenu");
	}
	public void OnClickResume(){
		Time.timeScale = 1f;//Everything is unfrozen
		GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
		AudioListener.pause = false;
		pauseMenu.enabled = false;
	}



}
	