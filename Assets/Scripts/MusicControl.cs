using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
	Player playerScript;
	int health;
	public AudioSource levelMusic;
	public AudioSource lowHealthMusic;
	bool lowHealth = false;
	bool fadeBool = false;
	// Use this for initialization
	void Start () 
	{

		levelMusic.Play();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		health = (int)playerScript.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		health = (int)playerScript.health;
		if (health <= 2 && lowHealth == false) 
		{
            if (health > 0)
            {
                levelMusic.volume = 0.4f;
                lowHealth = true;
                lowHealthMusic.Play();
            }
           
		}
        else if (health < 1 && lowHealth == true)
        {
            //levelMusic.volume = 1.0f;
            lowHealth = false;
            lowHealthMusic.Stop();
        }
		else if (health > 2 && lowHealth == true) 
		{

			levelMusic.volume=1.0f;
			lowHealth = false;
			lowHealthMusic.Stop();
		
		}
       
        else if(playerScript.levelFinish==true && fadeBool == false)
		{
			fadeBool = true;
			//FadeOutMusic();
		}
	}
	/*
	public void FadeOutMusic()
	{
		StartCoroutine(FadeMusic());
	}
	IEnumerator FadeMusic()
	{
		while(levelMusic.volume > .1F)
		{
			levelMusic.volume = Mathf.Lerp(levelMusic.volume,0F,0.4f*Time.deltaTime);
			yield return 0;
		}
		levelMusic.volume = 0;
		
	}
	*/
}
