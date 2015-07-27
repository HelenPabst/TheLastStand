using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	float playerPosX;
	float playerPosY;
	Vector3 playerPos;
	Player player;

	public float minX; //left boundary 
	public float maxX; //right boundary 
	public float minY; //up boundary 
	public float maxY; //down boundary

	void Start () 
	{

		player = (Player)GameObject.Find("Player").GetComponent("Player");
		playerPos = player.transform.position;
		playerPosX = playerPos.x;
		playerPosY = playerPos.y;
		//set camera to player position at start
		this.transform.position = new Vector3(playerPosX,playerPosY, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{


		playerPos = player.transform.position;
		playerPosX = playerPos.x;
		playerPosY = playerPos.y;

		if((playerPosX > minX) && (playerPosX < maxX))
		{


			FollowPlayerX();
		}
		if((playerPosY > minY) && (playerPosY < maxY))
		{
			
			
			FollowPlayerY();
		}

	}
	void FollowPlayerX()
	{
		this.transform.position = new Vector3(playerPosX, this.transform.position.y, this.transform.position.z);
		//float xboundary = Mathf.Clamp(transform.position.x, minX, maxX);
		//float yboundary = Mathf.Clamp(transform.position.y, minY, maxY);
		//transform.position = new Vector3(xboundary, yboundary, this.transform.position.z);
	}
	void FollowPlayerY()
	{
		this.transform.position = new Vector3(this.transform.position.x, playerPosY, this.transform.position.z);
		//float xboundary = Mathf.Clamp(transform.position.x, minX, maxX);
		//float yboundary = Mathf.Clamp(transform.position.y, minY, maxY);
		//transform.position = new Vector3(xboundary, yboundary, this.transform.position.z);
	}
}
