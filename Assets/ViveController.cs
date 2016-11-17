using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ViveController : NetworkBehaviour {
	public GameObject spawnButton;

	public override void OnStartLocalPlayer()
	{
		GameObject cam = new GameObject();
		cam.AddComponent<Camera>();
		cam.tag = "MainCamera";
		cam.name = "cam";
		cam.transform.parent = gameObject.transform;
		cam.transform.localPosition = new Vector3 (0, 0, 0);
		cam.transform.localRotation = Quaternion.Euler (90, 0, 0);
	}
}
