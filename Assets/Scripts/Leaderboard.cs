using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Leaderboard : MonoBehaviour {

	// Use this for initialization
	string rank1, rank2, rank3, rank4,rank5,rank6,rank7,rank8,rank9,rank10;
	float score1,score2,score3,score4,score5,score6,score7,score8,score9,score10;
	float[] topTen;
	string[]topUsers;
	float userScore;
	string userName;
	public Text rank1Text, rank2Text, rank3Text, rank4Text,rank5Text,rank6Text,rank7Text,rank8Text,rank9Text,rank10Text,userScoreDisplay;
	public GameObject inputPanel, yourScorePanel;
	public InputField initialInput;
	public Button submitButton = null;
	void Start () 
	{
		yourScorePanel.SetActive(true);
		topTen = new float[] {PlayerPrefs.GetFloat("Score 1"),PlayerPrefs.GetFloat("Score 2"),PlayerPrefs.GetFloat("Score 3"),
				PlayerPrefs.GetFloat("Score 4"),PlayerPrefs.GetFloat("Score 5"),PlayerPrefs.GetFloat("Score 6"),
				PlayerPrefs.GetFloat("Score 7"),PlayerPrefs.GetFloat("Score 8"),PlayerPrefs.GetFloat("Score 9"),
			PlayerPrefs.GetFloat("Score 10")};
		topUsers = new string[] {PlayerPrefs.GetString("Rank 1"),PlayerPrefs.GetString("Rank 2"),PlayerPrefs.GetString("Rank 3"),
			PlayerPrefs.GetString("Rank 4"),PlayerPrefs.GetString("Rank 5"),PlayerPrefs.GetString("Rank 6"),
			PlayerPrefs.GetString("Rank 7"),PlayerPrefs.GetString("Rank 8"),PlayerPrefs.GetString("Rank 9"),
			PlayerPrefs.GetString("Rank 10")};
	


		inputPanel.SetActive(false);
		userScore = PlayerPrefs.GetFloat("High Score");
		if (userScore == 0) 
		{
			yourScorePanel.SetActive(false);
		}
		userScoreDisplay.text = (""+PlayerPrefs.GetFloat("High Score")+"");
		SetLeaderboard ();
		DisplayLeaderboard ();
		if (userScore > (PlayerPrefs.GetFloat ("Score 10"))) 
		{

			inputPanel.SetActive(true);

		}
	}

	public void OnClickSubmit()
	{
		///get user input
		///userName = the thing that was input
		userName = initialInput.text;
		SortScore();
		DisplayLeaderboard();
		SaveLeaderboard();
		inputPanel.SetActive(false);
		//What to do with the value from input field
	}
	public void OnClickMainMenu(){

		Application.LoadLevel("StartMenu");
		
	}
	public void OnClickQuit()
	{
		Application.Quit ();
	}
	public void SortScore()
	{
		for (int i = 0; i<topTen.Length; i++) 
		{
			if(userScore > topTen[i])
			{
				float currentValue = topTen[i];
				string currentName = topUsers[i];
				topTen[i] = userScore;
				topUsers[i] = userName;
				for(int j = i+1; j < topTen.Length; j++)
				{
					float valueToMove = topTen[j];
					string userToMove = topUsers[j];
					topTen[j] = currentValue;
					topUsers[j] = currentName;
					currentValue = valueToMove;
					currentName = userToMove;
				}

				return;
			}
		}
	}

	// Update is called once per frame

	void DisplayLeaderboard()
	{
		rank1Text.text = ("#1:  "+(topUsers[0])+"-----------"+(topTen[0])+"");
		rank2Text.text = ("#2:  "+(topUsers[1])+"-----------"+(topTen[1])+"");
		rank3Text.text = ("#3:  "+(topUsers[2])+"-----------"+(topTen[2])+"");
		rank4Text.text = ("#4:  "+(topUsers[3])+"-----------"+(topTen[3])+"");
		rank5Text.text = ("#5:  "+(topUsers[4])+"-----------"+(topTen[4])+"");
		rank6Text.text = ("#6:  "+(topUsers[5])+"-----------"+(topTen[5])+"");
		rank7Text.text = ("#7:  "+(topUsers[6])+"-----------"+(topTen[6])+"");
		rank8Text.text = ("#8:  "+(topUsers[7])+"-----------"+(topTen[7])+"");
		rank9Text.text = ("#9:  "+(topUsers[8])+"-----------"+(topTen[8])+"");
		rank10Text.text = ("#10:"+(topUsers[9])+"-----------"+(topTen[9])+"");
		
		
	}
	void SaveLeaderboard()
	{

			PlayerPrefs.SetString("Rank 1",topUsers[0]);
			PlayerPrefs.SetFloat("Score 1",topTen[0]);


			PlayerPrefs.SetString("Rank 2",topUsers[1]);
			PlayerPrefs.SetFloat("Score 2",topTen[1]);


			PlayerPrefs.SetString("Rank 3",topUsers[2]);
			PlayerPrefs.SetFloat("Score 3",topTen[2]);


			PlayerPrefs.SetString("Rank 4",topUsers[3]);
			PlayerPrefs.SetFloat("Score 4",topTen[3]);

			PlayerPrefs.SetString("Rank 5",topUsers[4]);
			PlayerPrefs.SetFloat("Score 5",topTen[4]);

			PlayerPrefs.SetString("Rank 6",topUsers[5]);
			PlayerPrefs.SetFloat("Score 6",topTen[5]);

			PlayerPrefs.SetString("Rank 7",topUsers[6]);
			PlayerPrefs.SetFloat("Score 7",topTen[6]);

			PlayerPrefs.SetString("Rank 8",topUsers[7]);
			PlayerPrefs.SetFloat("Score 8",topTen[7]);

			PlayerPrefs.SetString("Rank 9",topUsers[8]);
			PlayerPrefs.SetFloat("Score 9",topTen[8]);

			PlayerPrefs.SetString("Rank 10",topUsers[9]);
			PlayerPrefs.SetFloat("Score 10",topTen[9]);

	}
	void SetLeaderboard()
	{
		if(!PlayerPrefs.HasKey("Rank 1"))
		{
			PlayerPrefs.SetString("Rank 1","VGD");
			PlayerPrefs.SetFloat("Score 1",0);
		}
		if(!PlayerPrefs.HasKey("Rank 2"))
		{
			PlayerPrefs.SetString("Rank 2","VGD");
			PlayerPrefs.SetFloat("Score 2",0);
		}
		if(!PlayerPrefs.HasKey("Rank 3"))
		{
			PlayerPrefs.SetString("Rank 3","VGD");
			PlayerPrefs.SetFloat("Score 3",0);
		}
		if(!PlayerPrefs.HasKey("Rank 4"))
		{
			PlayerPrefs.SetString("Rank 4","VGD");
			PlayerPrefs.SetFloat("Score 4",0);
		}
		if(!PlayerPrefs.HasKey("Rank 5"))
		{
			PlayerPrefs.SetString("Rank 5","VGD");
			PlayerPrefs.SetFloat("Score 5",0);
		}
		if(!PlayerPrefs.HasKey("Rank 6"))
		{
			PlayerPrefs.SetString("Rank 6","VGD");
			PlayerPrefs.SetFloat("Score 6",0);
		}
		if(!PlayerPrefs.HasKey("Rank 7"))
		{
			PlayerPrefs.SetString("Rank 7","VGD");
			PlayerPrefs.SetFloat("Score 7",0);
		}
		if(!PlayerPrefs.HasKey("Rank 8"))
		{
			PlayerPrefs.SetString("Rank 8","VGD");
			PlayerPrefs.SetFloat("Score 8",0);
		}
		if(!PlayerPrefs.HasKey("Rank 9"))
		{
			PlayerPrefs.SetString("Rank 9","VGD");
			PlayerPrefs.SetFloat("Score 9",0);
		}
		if(!PlayerPrefs.HasKey("Rank 10"))
		{
			PlayerPrefs.SetString("Rank 10","VGD");
			PlayerPrefs.SetFloat("Score 10",0);
		}
	}
}
