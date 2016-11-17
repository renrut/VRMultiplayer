using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetManager : NetworkManager {

 	public int curPlayer;

	public GameObject vivePlayer;
	public GameObject cardboardPlayer;
	public Vector3 vivePlayerSpawn;
	public Vector3 cardboardPlayerSpawn;


	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId){
		Vector3 playerSpawnPos;
		GameObject playerPrefab;
		print (conn.address);

		if (conn.address == "localClient") {
			playerPrefab = vivePlayer;
			playerSpawnPos = vivePlayerSpawn;
		}else{
			playerPrefab = cardboardPlayer;
			playerSpawnPos = cardboardPlayerSpawn;
		}

		GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);

		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

}
