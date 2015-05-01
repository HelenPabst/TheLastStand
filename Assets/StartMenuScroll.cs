using UnityEngine;
using System.Collections;

public class StartMenuScroll : MonoBehaviour {

	// Use this for initialization
	public bool scrollOpen;
	void Start () {
		scrollOpen = false;
	}
	
	// Update is called once per frame
	void ScrollOpen () {
		scrollOpen = true;
	}
}
