using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

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
}