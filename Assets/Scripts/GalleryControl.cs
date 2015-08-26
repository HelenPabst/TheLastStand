using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryControl : MonoBehaviour {

	public GameObject loadPanel;
	public GameObject galleryText;
	/*
	Sprite[] Cindy;
	Sprite[] Coleton;
	Sprite[] Ellen;
	Sprite[] Erin;
	Sprite[] Francis;
	Sprite[] Gil;
	Sprite[] Jamie;
	Sprite[] Jimmy;
	Sprite[] Katrina;
	Sprite[] Micheal;
	Sprite[] Nathan;
	Sprite[] Paul;
	Sprite[] Philip;
	Sprite[] Sarah;
	Sprite[] Sebastian;
	Sprite[] Tomy;
	Sprite[] Wahona;
	*/
	//changed
	Sprite[] Xun;
	Sprite[] Enemy;
	Sprite[] Environment;
	Sprite[] Misc;
	//
	Sprite[] CurrentSet;

	public Image image;
	public Text text, imageInfo;
	public GameObject ImagePanel;
	public GameObject GalleryPanel;
	int current = 0;

	// Use this for initialization
	void Start () {
		loadPanel.SetActive(false);

		/*
		Cindy = Resources.LoadAll<Sprite>("Cindy Phung");
		Coleton = Resources.LoadAll<Sprite>("Coleton Palmer");
		Ellen = Resources.LoadAll<Sprite>("Ellen Wong");
		Erin = Resources.LoadAll<Sprite>("Erin Emre");
		Francis = Resources.LoadAll<Sprite>("Francis Basco");
		Gil = Resources.LoadAll<Sprite>("Gil Ona");
		Jamie = Resources.LoadAll<Sprite>("Jamie Strassenburg");
		Jimmy = Resources.LoadAll<Sprite>("Jimmy Ip");
		Katrina = Resources.LoadAll<Sprite>("Katrina Yi");
		Micheal = Resources.LoadAll<Sprite>("Micheal Clute");
		Nathan = Resources.LoadAll<Sprite>("Nathan");
		Paul = Resources.LoadAll<Sprite>("Paul LaPoint");
		Philip = Resources.LoadAll<Sprite>("Philip Houth");
		Sarah = Resources.LoadAll<Sprite>("Sarah Aqil");
		Sebastian = Resources.LoadAll<Sprite>("Sebastian Adame");
		Tomy = Resources.LoadAll<Sprite>("Tomy");
		Wahona = Resources.LoadAll<Sprite>("Wahona");
		*/
		//changed
		Xun = Resources.LoadAll<Sprite>("ConceptXun");
		Enemy = Resources.LoadAll<Sprite>("ConceptEnemy");
		Environment = Resources.LoadAll<Sprite>("ConceptEnviro");
		Misc = Resources.LoadAll<Sprite>("ConceptMisc");
		//
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectSet(string set) {
		current = 0;
		switch (set) {
		/*
		case "Cindy": CurrentSet = Cindy; break;
		case "Coleton": CurrentSet = Coleton; break;
		case "Ellen": CurrentSet = Ellen; break;
		case "Erin": CurrentSet = Erin; break;
		case "Francis": CurrentSet = Francis; break;
		case "Gil": CurrentSet = Gil; break;
		case "Jamie": CurrentSet = Jamie; break;
		case "Jimmy": CurrentSet = Jimmy; break;
		case "Katrina": CurrentSet = Katrina; break;
		case "Micheal": CurrentSet = Micheal; break;
		case "Nathan": CurrentSet = Nathan; break;
		case "Paul": CurrentSet = Paul; break;
		case "Philip": CurrentSet = Philip; break;
		case "Sarah": CurrentSet = Sarah; break;
		case "Sebastian": CurrentSet = Sebastian; break;
		case "Tomy": CurrentSet = Tomy; break;
		case "Wahona": CurrentSet = Wahona; break;
		*/	//
		case "Xun": CurrentSet = Xun; break;
		case "Enemy": CurrentSet = Enemy; break;
		case "Environment": CurrentSet = Environment; break;
		case "Misc": CurrentSet = Misc; break;
			//
		}
		loadPanel.SetActive(true);
		Invoke ("LoadPage", 2.0f);
		//from here
	}
	public void LoadPage()
	{
		loadPanel.SetActive(false);
		GalleryPanel.SetActive (false);
		galleryText.SetActive(false);
		ImagePanel.SetActive (true);
		
		display ();
	}
	public void NextImage() {
		current ++;
		display();
	}
	
	public void PrevImage() {
		current --;
		display();
	}

	private void display() {
		if (current > CurrentSet.Length - 1) {
			current = 0;
		}
		if (current < 0) {
			current = CurrentSet.Length - 1;
		}

		text.text = (current + 1).ToString() + "/" + CurrentSet.Length.ToString ();
		imageInfo.text = CurrentSet[current].name;
		image.sprite = CurrentSet[current];
	}

	public void Menu() {
		galleryText.SetActive(true);
		GalleryPanel.SetActive (true);
		ImagePanel.SetActive (false);
	}

	public void MainMenu() {
		loadPanel.SetActive(true);
		Invoke ("LoadMain", 2.0f);

	}
	public void LoadMain()
	{
		Application.LoadLevel ("StartMenu");
	}
}
