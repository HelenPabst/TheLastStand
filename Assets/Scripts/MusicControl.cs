using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
	Player playerScript;
	int health;
	public AudioSource musicSource;
	public AudioClip levelMusic;
	public AudioClip lowHealthMusic;
	// Use this for initialization
	void Start () 
	{
		musicSource.clip = levelMusic;
		musicSource.Play();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		health = (int)playerScript.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		health = (int)playerScript.health;
		if (health <= 2 && musicSource.clip == levelMusic) 
		{
			musicSource.clip = lowHealthMusic;
			musicSource.Play();
		}
		else if (health > 2 && musicSource.clip == lowHealthMusic) 
		{
			musicSource.clip = levelMusic;	
			musicSource.Play();
		}
	}
}
