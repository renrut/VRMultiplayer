using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

	public GameObject cam;
	public GameObject GVR;
	public GameObject eventSystem;

	// Use this for initialization
	void Start () {
	
	}
		

	public override void OnStartLocalPlayer()
	{
		print ("called");
		foreach(SkinnedMeshRenderer s in GetComponentsInChildren<SkinnedMeshRenderer>()){
				s.material.color = Color.blue;
		}

		GameObject c = Instantiate (cam);
		GameObject viewer = Instantiate (GVR);
		c.transform.position = gameObject.transform.position;
		c.transform.parent = gameObject.transform;

	}
}

