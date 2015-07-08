using UnityEngine;
using System.Collections;

public class BasicProjectile : MonoBehaviour
{
    private double timeSpawned = 0;
    private double selfDestructTime;
    private double currentTime;
	private Animator animator;

	//added to fix rotation issue, but there could be a better way
	private Quaternion arrowRotation;
	//
    // Use this for initialization
    void Start()
    {
		arrowRotation = transform.rotation;
		animator = this.GetComponent<Animator>();
		animator.speed = 1;
        selfDestructTime = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
		//added to fix rotation issue, but there could be a better way
		if (transform.rotation != arrowRotation)
		{
			transform.rotation = arrowRotation;
		}
		//
		if (this.gameObject.tag == "StuckArrow")
		{
			if(this.gameObject.GetComponent<ParticleSystem>().isPlaying)
			{
				this.gameObject.GetComponent<ParticleSystem>().Stop ();
			}
		} 
		if (this.gameObject.tag == "EnemyArrow")
		{
			animator.SetBool("XunFire",false);
			if(this.gameObject.GetComponent<ParticleSystem>().isPlaying)
			{
				this.gameObject.GetComponent<ParticleSystem>().Stop ();
			}
		} 
		else if(this.gameObject.tag == "PlayerArrow")
		{
			animator.SetBool("XunFire",true);
			if(this.gameObject.GetComponent<ParticleSystem>().isPaused)
			{
				this.gameObject.GetComponent<ParticleSystem>().Play();
			}
		}
        currentTime += Time.deltaTime;
        if (currentTime + timeSpawned >= timeSpawned + selfDestructTime)
        {
            currentTime = 0;
            RemoveArrow();
        }
    }

    public void RemoveArrow()
    {
        this.gameObject.tag = "Untagged";
		animator.speed = 1;
        ObjectPool.instance.PoolObject(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Obstacle"))
		{
			////added this for arrow sticking
			this.gameObject.tag = "StuckArrow";
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
			animator.speed = 0;

            //RemoveArrow();
		}
    }
}
