using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject mobilePanel, pcPanel;
	public GameObject mainPanel, levelSelectPanel, extrasPanel,optionsPanel,instructionsPanel;
	public bool clickedStart;


	void Start () {
	
		Invoke ("DisplayMenu",1.0f);
		clickedStart = false;
		//creates a variable for high score if it doesnt exist yet
		PlayerPrefs.SetInt ("Endless", 0);
		//reset player score to 0 at start
		PlayerPrefs.SetFloat("High Score",0);


		Debug.Log ("current high score is "+PlayerPrefs.GetFloat("High Score"));


	}
	public void DisplayMenu()
	{
		if (Application.isMobilePlatform) {
			mobilePanel.SetActive(true);
			pcPanel.SetActive(false);
		} else {
			mobilePanel.SetActive(false);
			pcPanel.SetActive(true);
		}
	}

	public void OnClickStart()
	{
		//Application.LoadLevel("Level1-Village");
		clickedStart = true;
		instructionsPanel.SetActive(true);

		//Application.LoadLevel("Level1Cutscene");
	}
	public void OnClickDone()
	{


		if(clickedStart==true)
		{
			Application.LoadLevel("Level1-Village");
		}
		else
		{
			instructionsPanel.SetActive(false);
		}
		
		//Application.LoadLevel("Level1Cutscene");
	}
	public void OnClickLevelSelect()
	{
		levelSelectPanel.SetActive(true);
		mainPanel.SetActive(false);

	}
	public void OnClickOptions()
	{

		optionsPanel.SetActive(true);
		mainPanel.SetActive(false);
	}

	public void OnClickExtras() {
		//Application.LoadLevel ("Gallery");
		extrasPanel.SetActive(true);
		mainPanel.SetActive(false);
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}

	public void OnClickLevel1()
	{
		Application.LoadLevel("Level1-Village");
		//Application.LoadLevel("Level1Cutscene");
	}
	
	public void OnClickLevel2()
	{
		Application.LoadLevel("Level2-Forest");
		//Application.LoadLevel("Level2Cutscene");
	}
	
	public void OnClickLevel3()
	{
		Application.LoadLevel("Level3-Temple");
		//Application.LoadLevel("Level3Cutscene");
	}
	public void OnClickEndless()
	{
		PlayerPrefs.SetInt ("Endless", 1);
		//Application.LoadLevel("EndlessMode");
		Application.LoadLevel("Level3-Temple");
	}
	public void OnClickHighScore()
	{
		//Application.LoadLevel("EndlessMode");
		Application.LoadLevel("HighScore");
	}
	public void OnClickMain()
	{
		instructionsPanel.SetActive(false);
		optionsPanel.SetActive(false);
		extrasPanel.SetActive(false);
		levelSelectPanel.SetActive(false);
		mainPanel.SetActive(true);
	}
	public void OnClickGallery()
	{
		Application.LoadLevel ("Gallery");
    }
	public void OnClickCredits()
	{
		Application.LoadLevel ("Credits");
    }
	public void OnClickInstructions()
	{
		instructionsPanel.SetActive(true);
	}

	///////////////options controls
	public void OnClickSoundOn()
	{
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

		Debug.Log ("Score Deleted!");
	}


}
