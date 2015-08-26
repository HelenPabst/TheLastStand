using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	//a black image used for fading to black
	public Image fadeImage;
	private float fadeSpeed = 3.0f;
	private bool fadeOut = false;
	
	// Use this for initialization
	void Start () 
	{
		Invoke ("FadeOut",2.0f);
		Invoke ("Menu",3.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fadeOut == false)
		{
			//fade in
			fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
		else
		{
			//fade out
			fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
		}
	}


	void FadeOut()
	{
		fadeOut = true;
	}
	void Menu()
	{
		Application.LoadLevel("StartMenu");
	}
}
