using UnityEngine;
using System.Collections;

public class TripleShotEnemyScript : GenericCharacter {
		private Animator animator;	
		Vector3 arrowDirLeft, arrowDirRight;
		Player player;
		public Transform sightStart, sightEnd;
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
			if (currentTime >= fireRate && playerInSight) 
			{
				//fireArrow("EnemyArrow");
				//fireExtraArrows("EnemyArrow");
				animator.SetBool("Firing", true);
				currentTime = 0;
			}
			else
			{
				animator.SetBool("Firing", false);
			}
			
			if (health <= 0) 
			{
				health = 1;
				player.kills += 1;
				Debug.Log("Kill confirmed! Kill count is: " + player.kills);
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
		//draws enemy line of sight in debug scene view
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.red);
		//makes player in sight true when player crosses line of sight. 
		//layermask makes the line of sight only trigger on objects contained on the "Player" layer
		//only the player itself should be contained on that layer
		playerInSight = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
	}