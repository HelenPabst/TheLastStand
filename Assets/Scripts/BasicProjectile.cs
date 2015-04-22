using UnityEngine;
using System.Collections;

public class BasicProjectile : MonoBehaviour
{
    private double timeSpawned;
    private double selfDestructTime;
    private double currentTime;
	private Animator animator;

    // Use this for initialization
    void Start()
    {

		animator = this.GetComponent<Animator>();
		animator.speed = 1;
        selfDestructTime = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
		if (this.gameObject.tag != "PlayerArrow")
		{
			if(this.gameObject.particleSystem.isPlaying)
			{
				this.gameObject.particleSystem.Stop ();
			}
		} 
		else if(this.gameObject.tag == "PlayerArrow")
		{
			if(this.gameObject.particleSystem.isPaused)
			{
				this.gameObject.particleSystem.Play();
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
        this.gameObject.tag = "";
        ObjectPool.instance.PoolObject(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Obstacle"))
		{
			////added this for arrow sticking
			this.gameObject.tag = "StuckArrow";
			this.rigidbody2D.velocity = new Vector3(0,0,0);
			animator.speed = 0;

            //RemoveArrow();
		}
    }
}
