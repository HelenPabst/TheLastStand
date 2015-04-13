using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryControl : MonoBehaviour {

	Sprite[] Animations;
	Sprite[] Logo;
	Sprite[] Lore;
	Sprite[] LVL5;
	Sprite[] Statue;
	Sprite[] Signal;
	Sprite[] Oni;
	Sprite[] Xun;
	Sprite[] CurrentSet;

	public Image image;
	public Text text;
	public GameObject ImagePanel;
	public GameObject GalleryPanel;
	int current = 0;

	// Use this for initialization
	void Start () {
		Animations = Resources.LoadAll<Sprite>("Animations");
		Logo = Resources.LoadAll<Sprite>("Logo");
		Lore = Resources.LoadAll<Sprite>("Lore");
		LVL5 = Resources.LoadAll<Sprite>("LVL5");
		Statue = Resources.LoadAll<Sprite>("Statue");
		Signal = Resources.LoadAll<Sprite>("Signal");
		Oni = Resources.LoadAll<Sprite>("Oni");
		Xun = Resources.LoadAll<Sprite>("Xun");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectSet(string set) {
		current = 0;
		switch (set) {
		case "Animations": CurrentSet = Animations; break;
		case "Logo": CurrentSet = Logo; break;
		case "Lore": CurrentSet = Lore; break;
		case "LVL5": CurrentSet = LVL5; break;
		case "Statue": CurrentSet = Statue; break;
		case "Signal": CurrentSet = Signal; break;
		case "Oni": CurrentSet = Oni; break;
		case "Xun": CurrentSet = Xun; break;
		}

		GalleryPanel.SetActive (false);
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
		image.sprite = CurrentSet[current];
	}

	public void Menu() {
		GalleryPanel.SetActive (true);
		ImagePanel.SetActive (false);
	}

	public void MainMenu() {
		Application.LoadLevel ("StartMenu");
	}
}
