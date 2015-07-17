using UnityEngine;
using System.Collections;

public class PlayerCatch : MonoBehaviour {

	//get script from parent class (Player.cs)
	Player playerScript;
	Controls controlScript;
	GenericEnemy enemyScript;
	public GameObject controls;
	public GameObject catchParticle;
	//public AudioClip arrowCatch;
	//AudioSource audio;
	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource>();
		GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0.5f));
		//renderer.enabled = false;//makes catch radius invisible
		playerScript = transform.parent.GetComponent<Player>();
		controlScript = controls.transform.GetComponent<Controls>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnTriggerStay2D(Collider2D col){
		if(playerScript.health > 0)//catches on "Fire2" press, which is right mouse button, spacebar, or gamepad button 1 (B on xbox 360 remote)
		{
			if (col.gameObject.tag.Equals("EnemyArrow")&&(controlScript.grab))//(Input.GetMouseButtonDown(1)||Input.GetKeyDown(KeyCode.LeftShift)))
			{
				if(playerScript.ammo < playerScript.ammoLimit )
				{
					//audio.PlayOneShot(arrowCatch);
					ObjectPool.instance.PoolObject(col.gameObject);
					//add in particle effect
					catchParticle = ObjectPool.instance.GetObjectForType("CatchParticle", true);
					catchParticle.transform.position = new Vector3(col.transform.position.x,col.transform.position.y, -3);
					catchParticle.transform.rotation = transform.rotation;
					playerScript.ammo++;
					//Debug.Log("Arrow Caught. New Ammo is :"+ playerScript.ammo);
				}
				else
				{
					//Debug.Log("Ammo is full");
				}
			}
		}
	}
}
