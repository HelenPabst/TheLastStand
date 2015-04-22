using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject mobilePanel, pcPanel;
	public GameObject mainPanel, levelSelectPanel, extrasPanel,optionsPanel;

	void Start () {
		if (Application.isMobilePlatform) {
			mobilePanel.SetActive(true);
			pcPanel.SetActive(false);
		} else {
			mobilePanel.SetActive(false);
			pcPanel.SetActive(true);
		}
		//creates a variable for high score if it doesnt exist yet
		if(!PlayerPrefs.HasKey("High Score")){
			PlayerPrefs.SetFloat("High Score",0);
		}
		Debug.Log ("current high score is "+PlayerPrefs.GetFloat("High Score"));


	}

	public void OnClickStart()
	{
		//Application.LoadLevel("Level1-Village");
		Application.LoadLevel("Level1Cutscene");
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
		//Application.LoadLevel("LoadingScreenLevel1");
		Application.LoadLevel("Level1Cutscene");
	}
	
	public void OnClickLevel2()
	{
		//Application.LoadLevel("LoadingScreenLevel2");
		Application.LoadLevel("Level2Cutscene");
	}
	
	public void OnClickLevel3()
	{
		//Application.LoadLevel("LoadingScreenLevel3");
		Application.LoadLevel("Level3Cutscene");
	}
	public void OnClickEndless()
	{
		//Application.LoadLevel("LoadingScreenLevel3");
		Application.LoadLevel("Level3-Temple");
	}
	public void OnClickMain()
	{
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
		//Application.LoadLevel ("Credits");
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
		Debug.Log ("Score Deleted! Current high score is "+PlayerPrefs.GetFloat("High Score"));
	}
}
