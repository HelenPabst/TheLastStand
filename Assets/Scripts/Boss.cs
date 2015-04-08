using UnityEngine;
using System.Collections;

public class Boss : GenericCharacter {
	private Animator animator;
	Vector3 playerPosition, diff;
	private Vector2 sPosition;
	float rotation;
	GameObject boss;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		InvokeRepeating ("SpawnBoss",4, Random.Range (4,6));	
	}

	// Update is called once per frame
	void Update () 
	{
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
		{
			if (currentTime >= fireRate)
			{
				//animator.SetBool("Firing", true);
				fireArrow("EnemyArrow");
				currentTime = 0;
				animator.SetBool("Firing", true);
			}
			else
			{
				animator.SetBool("Firing", false);
			}
		}

		if (health <= 0) 
		{
			Destroy (gameObject);
			Debug.Log ("Boss is DEAD!!!!");
		}
	}
	
	//Rotate to face a player
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
	
	
	public void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "EnemyArrow") return;
		if (col.gameObject.tag.Equals("PlayerArrow")) 
		{
			health--;
			RePool(col.gameObject);
		}
	}
	void SpawnBoss () 
	{		
		sPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,Screen.width-200), 
		                                                       Random.Range(200,Screen.height-200), 
		                                                       Camera.main.farClipPlane/2));
		//Get he size of a collider at a position
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(sPosition,
		                                                       Mathf.Abs(collider2D.renderer.bounds.size.x - collider2D.renderer.bounds.size.x) + 2);
		
		
		if (hitColliders.Length == 0) {
			transform.position = sPosition;
			
		}
		
		
	}
	
	
	
}