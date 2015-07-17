using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1Tutorial : MonoBehaviour {
	
	public GameObject tutorialSpawn;
	public Text tutorialText, tutorialText2, tutorialText3;
	public bool tutEnemyDead = false;
	public bool tutArrowCaught = false;
	//these are the spawn points in the level
	public GameObject s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12;
	//tutorialSpawn.GetComponent<SpawnPoint>().EnemyCheck == false
	void Start () 
	{
		if (Application.isMobilePlatform) 
		{
			tutorialText.text = "Press Catch Button To Catch Arrows In Cone";
			tutorialText2.text = "Aim And Press Fire Button To Fire Arrows";
		} 
		Invoke ("DisplayCatchText", 4.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(tutArrowCaught == true)
		{
			tutorialText.gameObject.SetActive(false);
			Invoke ("DisplayFireText", 1.0f);

		}
		if(tutEnemyDead == true)
		{


			tutorialText2.gameObject.SetActive(false);
			Invoke ("DisplayDefendText", 1.0f);

			Invoke("RemoveText", 3.0f);
			s1.SetActive(true);
			s2.SetActive(true);
			s3.SetActive(true);
			s4.SetActive(true);
			s5.SetActive(true);
			s6.SetActive(true);
			s7.SetActive(true);
			s8.SetActive(true);
			s9.SetActive(true);
			s10.SetActive(true);
			s11.SetActive(true);
			s12.SetActive(true);
		}

	}
	void DisplayCatchText()
	{
		tutorialText.gameObject.SetActive(true);
	}
	void DisplayFireText()
	{
		tutArrowCaught = false;
		tutorialText2.gameObject.SetActive(true);
	}
	void DisplayDefendText()
	{
		tutEnemyDead = false;
		tutorialText3.gameObject.SetActive(true);
	}
	void RemoveText()
	{
		tutorialText3.gameObject.SetActive(false);
	}
}
