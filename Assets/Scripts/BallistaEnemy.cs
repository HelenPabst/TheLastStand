using UnityEngine;
using System.Collections;

public class BallistaEnemy : GenericCharacter {
	Vector3 playerPosition, diff;
	float rotation;
	Player player;
	private Animator animator;
	public GameObject inkSplatter;
	// Update is called once per frame
	void Start()
	{
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		animator = this.GetComponent<Animator>();
		health = standardHealth;
	}
	void Update () 
	{
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		if (currentTime >= fireRate) 
		{	
			//animator.SetBool("Firing", true);
			fireArrow("BallistaBolt");
			currentTime = 0;			
		}
		else
		{
			//animator.SetBool("Firing", false);
		}
		if (health <= 0) 
		{
			health = 2;
			RePool(this.gameObject);
			animator.SetBool("Firing", false);
			animator.SetBool("Despawning", false);
			player.kills += 1;
			Debug.Log("Kill confirmed! Kill count is: " + player.kills);
		
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
			///causes ink splatter on hit
			inkSplatter = ObjectPool.instance.GetObjectForType("InkSplatter", true);
			float inkX = col.gameObject.transform.position.x;
			float inkY = col.gameObject.transform.position.y;
			inkSplatter.transform.position = new Vector3(inkX,inkY,1.0f);
			inkSplatter.transform.rotation = col.gameObject.transform.rotation;
			///end of ink code
		}
	}
}