using UnityEngine;
using System.Collections;

public class BallistaEnemy : GenericCharacter {
	Vector3 playerPosition, diff;
	float rotation;

	// Update is called once per frame
	void Start()
	{
		health = standardHealth;
	}
	void Update () 
	{
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		if (currentTime >= fireRate) 
		{
			fireArrow("BallistaBolt");
			currentTime = 0;			
		}
		if (health <= 0) 
		{
			health = 2;
			RePool(this.gameObject);
		}
	}
	private void RotateToPlayer()
	{
		GameObject player = GameObject.Find("Player");
		Transform playerTransform = player.transform;
		// get player position
		playerPosition = playerTransform.position;
		playerPosition = new Vector3(playerPosition.x, playerPosition.y, 0);
		diff = playerPosition - transform.position;
		diff.Normalize();
		rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotation);
	}
	new protected void fireArrow(string tag) {
		arrow = ObjectPool.instance.GetObjectForType("BallistaProjectile", true);
		arrow.transform.position = transform.position;
		arrow.transform.rotation = transform.rotation;
		arrowDir = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.PI/180), Mathf.Sin(transform.eulerAngles.z * Mathf.PI/180));
		arrow.rigidbody2D.velocity = arrowDir * arrowVelocity;
		arrow.tag = tag;
	}
	public void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "BallistaBolt") return;
		if (col.gameObject.tag.Equals("PlayerArrow")) 
		{
			health--;
			RePool(col.gameObject);
		}
	}
}