using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Spawner : NetworkBehaviour {
	public GameObject spawn;

	public void Spawn(){
		GameObject obj = Instantiate (spawn);
		GameObject vivePlayer = GameObject.FindGameObjectWithTag ("VivePlayer");
		obj.transform.position = new Vector3(vivePlayer.transform.position.x, 0 ,vivePlayer.transform.position.z);
		NetworkServer.Spawn (obj);
	}
}
