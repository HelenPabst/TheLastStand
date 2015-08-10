using UnityEngine;
using System.Collections;

public class TripleShotEnemyScript : GenericCharacter {
		private Animator animator;	
		Vector3 arrowDirLeft, arrowDirRight;
		Player player;
		public Transform sightStart1, sightEnd1, sightEnd2,sightEnd3, sightEnd4, sightEnd5;
		public bool playerInSight = false;
		protected GameObject leftArrow, rightArrow;
		public GameObject inkSplatter;
		
		// Use this for initialization
		void Start () 
		{
			animator = this.GetComponent<Animator>();
			player = (Player)GameObject.Find("Player").GetComponent("Player");
			theta = new Vector3(0, 0, 0);//z value controls rotation, 0 is facing to the right
			//transform.Rotate(theta);
		}
		
		// Update is called once per frame
		void Update () {

			Raycast ();
			currentTime += Time.deltaTime;
			if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("TripleOniSpawn"))
			{
				if (currentTime >= fireRate && playerInSight)
				{
					//animator.SetBool("Firing", true);
					//firing an arrow is now an animator event
					//fireArrow("EnemyArrow");
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
			animator.SetBool("Firing", false);
			//animator.SetBool("Despawning", false);
			player.kills += 1;
			Debug.Log("Kill confirmed! Kill count is: " + player.kills);
			//resets health to starting health
			health = standardHealth;
			RePool(this.gameObject);
			}
		}

		protected void fireExtraArrows(string tag) {
		//left arrow firing
		leftArrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
		leftArrow.transform.position = transform.position;
		leftArrow.transform.rotation = transform.rotation; //multiplies the rotation to angle the arrows
		leftArrow.transform.rotation *= Quaternion.Euler (0, 0, 15);
		//adds 15 to shoot arrow diagonally
		arrowDirLeft = new Vector3(Mathf.Cos((transform.eulerAngles.z+15) * Mathf.PI/180), Mathf.Sin((transform.eulerAngles.z+15) * Mathf.PI/180));//PI/180 converts to radians

		leftArrow.GetComponent<Rigidbody2D>().velocity = arrowDirLeft * arrowVelocity;
		leftArrow.tag = tag;
		//right arrow firing
		rightArrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
		rightArrow.transform.position = transform.position;
		rightArrow.transform.rotation = transform.rotation;//multiplies the rotation to angle the arrows
		rightArrow.transform.rotation *= Quaternion.Euler (0, 0, -15);
		//subtracts 15 to shoot arrow diagonally
		arrowDirRight = new Vector3(Mathf.Cos((transform.eulerAngles.z-15)  * Mathf.PI/180), Mathf.Sin((transform.eulerAngles.z-15) * Mathf.PI/180));

		rightArrow.GetComponent<Rigidbody2D>().velocity = arrowDirRight * arrowVelocity;
		rightArrow.tag = tag;
	}
		
	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EnemyArrow") return;
		if (col.gameObject.tag.Equals("PlayerArrow"))
		{
			health--;
			///causes ink splatter on hit
			inkSplatter = ObjectPool.instance.GetObjectForType("InkSplatter", true);
			float inkX = col.gameObject.transform.position.x;
			float inkY = col.gameObject.transform.position.y;
			inkSplatter.transform.position = new Vector3(inkX,inkY,1.0f);
			inkSplatter.transform.rotation = col.gameObject.transform.rotation;
			///end of ink code

			RePool(col.gameObject);
		}
	}
	public void Raycast()
	{
		//direction = playerScript.transform.position - this.transform.position;
		//if ((Vector3.Angle(direction, this.transform.forward) <= fOV * 0.5f)) {
		//	if (Physics.Raycast(this.transform.position, direction, out hit, visibility)) {
		//		playerInSight = hit.transform.CompareTag ("Player");
		//	}
		//}
		
		//Debug.Log (direction);
		//Debug.Log (transform.forward);
		// Debug.Log (Vector3.Angle (direction, transform.forward));
		//draws enemy line of sight in debug scene view
		
		Debug.DrawLine(sightStart1.position, sightEnd1.position, Color.red);
		Debug.DrawLine(sightStart1.position, sightEnd2.position, Color.green);
		Debug.DrawLine(sightStart1.position, sightEnd3.position, Color.blue);
		Debug.DrawLine(sightStart1.position, sightEnd4.position, Color.green);
		Debug.DrawLine(sightStart1.position, sightEnd5.position, Color.blue);
		//makes player in sight true when player crosses line of sight. 
		//layermask makes the line of sight only trigger on objects contained on the "Player" layer
		//only the player itself should be contained on that layer
		
		if (Physics2D.Linecast (sightStart1.position, sightEnd1.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player. Comment out for staggered tracking
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		else if(Physics2D.Linecast (sightStart1.position, sightEnd2.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		else if(Physics2D.Linecast (sightStart1.position, sightEnd3.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		else if(Physics2D.Linecast (sightStart1.position, sightEnd4.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		else if(Physics2D.Linecast (sightStart1.position, sightEnd5.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		else {
			playerInSight = false;
		}
	}
	}