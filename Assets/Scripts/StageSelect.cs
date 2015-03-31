using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	public void OnClickLevel1()
	{
		//Application.LoadLevel("BasicLevel");
		Application.LoadLevel("Level1Cutscene");
	}
	public void OnClickLevel3()
	{
		//Application.LoadLevel("BasicLevel");
		Application.LoadLevel("Level3-Temple");
	}
}