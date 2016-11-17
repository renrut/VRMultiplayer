using UnityEngine;
using System.Collections;


public class FollowPlayer : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object

	private float value;
	public Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () 
	{
		value = 5.0f;
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.LookAt(player.transform.position);

		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	void Update(){
		if(Input.GetKey ("q")){
			transform.LookAt(player.transform.position);
			transform.RotateAround (player.transform.position,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * value);
			offset = transform.position - player.transform.position;

		}
		if (Input.GetKey ("e")) {
			transform.LookAt(player.transform.position);
			transform.RotateAround (player.transform.position,new Vector3(0.0f,-1.0f,0.0f),20 * Time.deltaTime * value);
			offset = transform.position - player.transform.position;

		}
			

	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;

	}
		
}

