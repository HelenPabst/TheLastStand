using UnityEngine;
using System.Collections;

public class Boss : GenericCharacter {
	private Animator animator;
	Vector3 playerPosition, diff;
	private Vector2 sPosition;
	float rotation;
	GameObject boss;
	public GameObject inkSplatter;
	Player player;
	public AudioSource spawnSound, fireSound;

	// Use this for initialization
	void Start () 
	{
		spawnSound.Play ();
		player = (Player)GameObject.Find("Player").GetComponent("Player");
		animator = this.GetComponent<Animator>();
		//audio = GetComponent<AudioSource>();
		InvokeRepeating ("Teleport", 6, 7);
	}

	// Update is called once per frame
	void Update () 
	{
		//if(animator.)
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
		{
			if (currentTime >= fireRate)
			{
				//animator.SetBool("Firing", true);
				animator.SetBool("Firing", true);
				//fireArrow("EnemyArrow");
				currentTime = 0;

			}
			else
			{
				animator.SetBool("Firing", false);
			}
		}

		if (health <= 0) 
		{
			player.killedBoss = true;
			//(clip, volume)
			Destroy (gameObject);
			Debug.Log ("Boss is DEAD!!!!");
		}
	}
	public void FireSound()
	{
		fireSound.Play ();
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
			///causes ink splatter on hit
			inkSplatter = ObjectPool.instance.GetObjectForType("InkSplatter", true);
			float inkX = col.gameObject.transform.position.x;
			float inkY = col.gameObject.transform.position.y;
			inkSplatter.transform.position = new Vector3(inkX,inkY,1.0f);
			inkSplatter.transform.rotation = col.gameObject.transform.rotation;
			///end of ink code
		}
	}

	void Teleport () 
	{		


		sPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,Screen.width-200), 
	                                                     Random.Range(180,Screen.height-180), 
	                                                     Camera.main.farClipPlane/2));
		//Get he size of a collider at a position
	    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(sPosition,
			                                                       Mathf.Abs(GetComponent<Collider2D>().GetComponent<Renderer>().bounds.size.x - GetComponent<Collider2D>().GetComponent<Renderer>().bounds.size.x) + 4);
        while (hitColliders.Length != 0) {
			sPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(200,Screen.width-200), 
			                                                       Random.Range(180,Screen.height-180), 
			                                                       Camera.main.farClipPlane/2));
			//Get he size of a collider at a position
			hitColliders = Physics2D.OverlapCircleAll(sPosition,
                                                     Mathf.Abs(GetComponent<Collider2D>().GetComponent<Renderer>().bounds.size.x - GetComponent<Collider2D>().GetComponent<Renderer>().bounds.size.x) + 4);
				}
	    if (hitColliders.Length == 0) {		            
						//	animator.SetBool ("Despawning", true);
			StartCoroutine ("DespawnBoss"); 
		}
	}
	//Changing state of the animation
	IEnumerator DespawnBoss() {
		animator.SetBool ("Despawning",true);
		yield return new WaitForSeconds (1.5f);
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds (1.0f);
		animator.SetBool ("Despawning", false);
		yield return new WaitForSeconds (1.0f);
		this.transform.position = sPosition;
		yield return new WaitForSeconds (1.0f);
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider2D>().enabled = true;
		animator.SetBool ("Spawning", true);
		yield return new WaitForSeconds (2f);
		animator.SetBool ("Spawning", false);

	}

}