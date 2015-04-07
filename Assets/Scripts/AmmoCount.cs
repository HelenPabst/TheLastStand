using UnityEngine;
using System.Collections;

public class AmmoCount : MonoBehaviour {
	private Animator animator;
	Player playerScript;
	int ammo;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		//playerScript = transform.parent.GetComponent<Player>();
		ammo = (int)playerScript.health;
	}
	
	// Update is called once per frame
	void Update () {
		ammo = (int)playerScript.ammo;
		animator.SetInteger("PlayerAmmo", ammo);
	}
}
