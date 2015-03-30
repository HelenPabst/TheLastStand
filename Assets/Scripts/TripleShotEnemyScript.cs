using UnityEngine;
using System.Collections;

public class TripleShotEnemyScript : GenericCharacter {
				
		Vector3 arrowDirLeft, arrowDirRight;
		public Transform sightStart, sightEnd;
		public bool playerInSight = false;
		protected GameObject leftArrow, rightArrow;
		
		// Use this for initialization
		void Start () {
			theta = new Vector3(0, 0, 0);//z value controls rotation, 0 is facing to the right
			//transform.Rotate(theta);
		}
		
		// Update is called once per frame
		void Update () {
			Raycast ();
			currentTime += Time.deltaTime;
			if (currentTime >= fireRate && playerInSight) 
			{
				fireArrow("EnemyArrow");
				fireExtraArrows("EnemyArrow");
				currentTime = 0;
			}
			
			if (health <= 0) 
			{
				health = 1;
				RePool(this.gameObject);
			}
		}

		protected void fireExtraArrows(string tag) {
		//left arrow firing
		leftArrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
		leftArrow.transform.position = transform.position;
		leftArrow.transform.rotation = transform.rotation*Quaternion.Euler(0, 0, -15); //multiplies the rotation to angle the arrows
		//subtracts 15 to shoot arrow diagonally
		arrowDirLeft = new Vector3(Mathf.Cos(transform.eulerAngles.z-15 * Mathf.PI/180), Mathf.Sin(transform.eulerAngles.z-15 * Mathf.PI/180));
		leftArrow.rigidbody2D.velocity = arrowDirLeft * arrowVelocity;
		leftArrow.tag = tag;
		//right arrow firing
		rightArrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
		rightArrow.transform.position = transform.position;
		rightArrow.transform.rotation = transform.rotation*Quaternion.Euler(0, 0, 15);//multiplies the rotation to angle the arrows
		//adds 15 to shoot arrow diagonally
		arrowDirRight = new Vector3(Mathf.Cos(transform.eulerAngles.z+15 * Mathf.PI/180), Mathf.Sin(transform.eulerAngles.z+15 * Mathf.PI/180));
		rightArrow.rigidbody2D.velocity = arrowDirRight * arrowVelocity;
		rightArrow.tag = tag;
	}
		
	void OnColliderEnter2D(Collider col) 
	{
			health--;
			RePool(col.gameObject);
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