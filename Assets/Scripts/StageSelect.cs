using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	public void OnClickLevel1()
	{
		Application.LoadLevel("LoadingScreenLevel1");
		//Application.LoadLevel("Level1Cutscene");
	}

	public void OnClickLevel2()
	{
		Application.LoadLevel("LoadingScreenLevel2");
		//Application.LoadLevel("Level2Cutscene");
	}

	public void OnClickLevel3()
	{
		Application.LoadLevel("LoadingScreenLevel3");
		//Application.LoadLevel("Level3Cutscene");
	}
}