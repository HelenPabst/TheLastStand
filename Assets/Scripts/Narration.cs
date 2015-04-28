using UnityEngine;
using System.Collections;

public class Narration : MonoBehaviour {


	AudioSource audio;
	public AudioClip introA,introB, introC, level2, level3;
	// Use this for initialization
	void Start () 
	{
	

		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
