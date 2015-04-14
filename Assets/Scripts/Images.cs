using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Images : MonoBehaviour {
	public Sprite[] images;
	public Image image;
	int current = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
		if (current > images.Length - 1) {
			current = 0;
		}
		if (current < 0) {
			current = images.Length - 1;
		}
		image.sprite = images [current];
	}
}
