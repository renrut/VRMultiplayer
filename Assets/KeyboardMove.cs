using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class KeyboardMove : NetworkBehaviour {

	//Variables
	public float movementSpeed;
	public GameObject spawner;
	void Update() {
		if (!isLocalPlayer)
		{
			return;
		}

		// is the controller on the ground?
		if (Input.GetKey("up"))
			transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
		if (Input.GetKey("left"))
			transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
		if (Input.GetKey("down"))
			transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
		if (Input.GetKey("right"))
			transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
		if (Input.GetKeyDown ("space"))
			spawner.GetComponent<Spawner>().Spawn ();
		
	}
}
