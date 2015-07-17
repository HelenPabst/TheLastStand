using UnityEngine;
using System.Collections;

public class GenericEnemy : GenericCharacter
{
    // Use this for initialization
    private Animator animator;
    Player player;
    public Transform sightStart1, sightEnd1,sightStart2, sightEnd2,sightStart3,sightEnd3;
    public bool playerInSight = false;
    RaycastHit hit;
    Vector3 direction;
	public GameObject inkSplatter;
	public AudioSource spawnSound, fireSound;

    void Start()
    {
		spawnSound.Play ();
        animator = this.GetComponent<Animator>();
        player = (Player)GameObject.Find("Player").GetComponent("Player");
        theta = new Vector3(0, 0, 0);//z value controls rotation, 0 is facing to the right
        //transform.Rotate(theta);
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        //Debug.Log (playerInSight);
        currentTime += Time.deltaTime;
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Spawning"))
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
			animator.SetBool("Despawning", false);
			player.kills += 1;
			//Debug.Log("Kill confirmed! Kill count is: " + player.kills);

            health = 1;
            RePool(this.gameObject);
        }
        //animator.SetBool("Firing", false);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "EnemyArrow") return;
        if (col.gameObject.tag.Equals("PlayerArrow"))
        {

			RePool(col.gameObject);
			///causes ink splatter on hit
			inkSplatter = ObjectPool.instance.GetObjectForType("InkSplatter", true);
			float inkX = col.gameObject.transform.position.x;
			float inkY = col.gameObject.transform.position.y;
			inkSplatter.transform.position = new Vector3(inkX,inkY,1.0f);
			inkSplatter.transform.rotation = col.gameObject.transform.rotation;
			///end of ink code
            health--;

        }
    }
	public void FireSound()
	{
		fireSound.Play ();
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
		Debug.DrawLine(sightStart2.position, sightEnd2.position, Color.green);
		Debug.DrawLine(sightStart3.position, sightEnd3.position, Color.blue);
       
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
		 else if(Physics2D.Linecast (sightStart2.position, sightEnd2.position, 1 << LayerMask.NameToLayer ("Player"))) {
			playerInSight = true;
			///causes unit to face player
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 
		 else if(Physics2D.Linecast (sightStart3.position, sightEnd3.position, 1 << LayerMask.NameToLayer ("Player"))) {
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