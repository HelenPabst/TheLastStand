using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject mobilePanel, pcPanel;

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

		Application.LoadLevel("LevelSelectMenu");
	}
	public void OnClickOptions()
	{
		//Application.LoadLevel("BasicLevel");
		//Application.LoadLevel("Options");
	}

	public void OnClickExtras() {
		Application.LoadLevel ("Gallery");
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}
}
