using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

//	public GameObject camera;
//	public GameObject reticle;
//	public GameObject eventSystem;

	// Use this for initialization
	void Start () {
	
	}
		

	public override void OnStartLocalPlayer()
	{
		print ("called");
		foreach(SkinnedMeshRenderer s in GetComponentsInChildren<SkinnedMeshRenderer>()){
				s.material.color = Color.blue;
		}
		GameObject cam = new GameObject();
		cam.AddComponent<Camera>();
		cam.tag = "MainCamera";
		cam.name = "cam";
		cam.transform.parent = gameObject.transform;
		cam.transform.localPosition = new Vector3 (0, 2, -5);
		cam.transform.localRotation = Quaternion.Euler (20, 0, 0);
	}
}

