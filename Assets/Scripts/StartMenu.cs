using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour {

	public GameObject mobilePanel, pcPanel, pcLogo, mobileLogo, pcScroll, mobileScroll;
	public GameObject mainPanel, levelSelectPanel, extrasPanel,optionsPanel,instructionsPanel, 
	mainMobilePanel, levelMobilePanel, extrasMobilePanel, optionsMobilePanel;
	public GameObject loadPanel;


	public bool clickedStart;
	public AudioSource buttonSound;
	public int levelSelected;

	//cursor texture code
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;


	void Start () {
		levelSelected = 0;
		loadPanel.SetActive(false);
		if (Application.isMobilePlatform) {
			mobileScroll.SetActive(true);
			mobileLogo.SetActive(true);
			pcScroll.SetActive(false);
			pcLogo.SetActive(false);
			//keep phone from sleeping
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			//disable mouse image 
			Cursor.visible = false;
	
		} else {
			//set cursor texture
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

			mobileScroll.SetActive(false);
			mobileLogo.SetActive(false);
			pcScroll.SetActive(true);
			pcLogo.SetActive(true);
		}
		Invoke ("DisplayMenu",1.0f);
		clickedStart = false;
		//set android vibration
		PlayerPrefs.SetFloat("Vibrate",1);
		//creates a variable for high score if it doesnt exist yet
		PlayerPrefs.SetInt ("Endless", 0);
		//reset player score to 0 at start
		PlayerPrefs.SetFloat("High Score",0);


		Debug.Log ("current high score is "+PlayerPrefs.GetFloat("High Score"));


	}
	void Update()
	{

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
	public void LoadLevel()
	{
		if(levelSelected == -1)
		{
			Application.LoadLevel ("Gallery");
		}
		if(levelSelected == 0)
		{
			Application.LoadLevel("NarrationIntro");
		}
		if(levelSelected == 1)
		{
			Application.LoadLevel("Level1-Village");
		}
		if(levelSelected == 2)
		{
			Application.LoadLevel("Level2-Forest");
		}
		if(levelSelected == 3)
		{
			Application.LoadLevel("Level3-Temple");
		}
	}


	public void OnClickStart()
	{
		//Application.LoadLevel("Level1-Village");
		/*buttonSound.Play ();
		clickedStart = true;
		instructionsPanel.SetActive(true);
		*/
		//Application.LoadLevel("Level1Cutscene");

		buttonSound.Play ();

		loadPanel.SetActive(true);
		levelSelected = 0;
		Invoke ("LoadLevel", 2.0f);
		//Application.LoadLevel("Level1-Village");


	}
	public void OnClickDone()
	{

		buttonSound.Play ();
		if(clickedStart==true)
		{
			loadPanel.SetActive(true);
			//Application.LoadLevel("Level1-Village");
			Application.LoadLevel("NarrationIntro");
		}
		else
		{
			instructionsPanel.SetActive(false);
		}
		
		//Application.LoadLevel("Level1Cutscene");
	}
	public void OnClickLevelSelect()
	{
		buttonSound.Play ();
		if (Application.isMobilePlatform) {
			levelMobilePanel.SetActive(true);
			mainMobilePanel.SetActive(false);
			
		} else {
			
			levelSelectPanel.SetActive(true);
			mainPanel.SetActive(false);
		}


	}
	public void OnClickOptions()
	{
		buttonSound.Play ();
		if (Application.isMobilePlatform) {
			optionsMobilePanel.SetActive(true);
			mainMobilePanel.SetActive(false);
			
		} else {
			
			optionsPanel.SetActive(true);
			mainPanel.SetActive(false);
		}

	}

	public void OnClickExtras() 
	{
		buttonSound.Play ();
		if (Application.isMobilePlatform) {
			extrasMobilePanel.SetActive(true);
			mainMobilePanel.SetActive(false);
			
		} else {
			
			extrasPanel.SetActive(true);
			mainPanel.SetActive(false);
		}

	}

	public void OnClickQuit()
	{
		buttonSound.Play ();
		Application.Quit ();
	}

	public void OnClickLevel1()
	{
		buttonSound.Play ();
		loadPanel.SetActive(true);
		levelMobilePanel.SetActive(false);
		levelSelectPanel.SetActive(false);
		levelSelected = 1;
		Invoke ("LoadLevel", 2.0f);
		//Application.LoadLevel("Level1-Village");
		//Application.LoadLevel("Level1Cutscene");
	}
	
	public void OnClickLevel2()
	{
		buttonSound.Play ();
		loadPanel.SetActive(true);
		levelMobilePanel.SetActive(false);
		levelSelectPanel.SetActive(false);
		levelSelected = 2;
		Invoke ("LoadLevel", 2.0f);
		//Application.LoadLevel("Level2-Forest");
		//Application.LoadLevel("Level2Cutscene");
	}
	
	public void OnClickLevel3()
	{
		buttonSound.Play ();
		loadPanel.SetActive(true);
		levelMobilePanel.SetActive(false);
		levelSelectPanel.SetActive(false);
		levelSelected = 3;
		Invoke ("LoadLevel", 2.0f);
		//Application.LoadLevel("Level3-Temple");
		//Application.LoadLevel("Level3Cutscene");
	}
	public void OnClickEndless()
	{
		buttonSound.Play ();
		PlayerPrefs.SetInt ("Endless", 1);
		loadPanel.SetActive(true);
		levelMobilePanel.SetActive(false);
		levelSelectPanel.SetActive(false);
		levelSelected = 3;
		Invoke ("LoadLevel", 2.0f);
		//Application.LoadLevel("EndlessMode");
		//Application.LoadLevel("Level3-Temple");
	}
	public void OnClickHighScore()
	{
		buttonSound.Play ();
		//Application.LoadLevel("EndlessMode");
		Application.LoadLevel("HighScore");
	}
	public void OnClickMain()
	{
		buttonSound.Play ();
		if (Application.isMobilePlatform) {
			instructionsPanel.SetActive(false);
			optionsMobilePanel.SetActive(false);
			extrasMobilePanel.SetActive(false);
			levelMobilePanel.SetActive(false);
			mainMobilePanel.SetActive(true);
			
		} else {
			
			instructionsPanel.SetActive(false);
			optionsPanel.SetActive(false);
			extrasPanel.SetActive(false);
			levelSelectPanel.SetActive(false);
			mainPanel.SetActive(true);
		}

	}
	public void OnClickGallery()
	{
		buttonSound.Play ();
		loadPanel.SetActive(true);
		//level -1 is gallery
		levelSelected = -1;
		Invoke ("LoadLevel", 2.0f);
    }
	public void OnClickCredits()
	{
		buttonSound.Play ();
		Application.LoadLevel ("Credits");
    }
	public void OnClickInstructions()
	{
		buttonSound.Play ();
		instructionsPanel.SetActive(true);
	}

	///////////////options controls
	public void OnClickSoundOn()
	{
		buttonSound.Play ();
		AudioListener.volume = 1;

	}
	public void OnClickSoundOff()
	{
		AudioListener.volume = 0;

	}

	public void OnClickDelete()
	{
		buttonSound.Play ();
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
	//android only
	public void OnClickVibrateOn()
	{
		buttonSound.Play ();
        ////remove this for pc build
#if UNITY_IPHONE || UNITY_ANDROID      
        Handheld.Vibrate ();
#endif
        PlayerPrefs.SetFloat("Vibrate",1);
		
	}
	public void OnClickVibrateOff()
	{
		buttonSound.Play ();
		PlayerPrefs.SetFloat("Vibrate",0);
		
	}
}
