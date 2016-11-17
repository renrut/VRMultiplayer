using System;
using System.ComponentModel;

#if ENABLE_UNET

namespace UnityEngine.Networking
{
	[AddComponentMenu("Network/NMHud")]
	[RequireComponent(typeof(NetworkManager))]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class NMHud : MonoBehaviour
	{
		public NetworkManager manager;
		[SerializeField] public bool showGUI = true;
		[SerializeField] public int offsetX;
		[SerializeField] public int offsetY;

		// Runtime variable
		bool m_ShowServer;

		void Awake()
		{
			manager = GetComponent<NetworkManager>();
		}

		void Update()
		{
			if (!showGUI)
				return;

			if (!manager.IsClientConnected() && !NetworkServer.active && manager.matchMaker == null)
			{
				if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer)
				{

					if (Input.GetKeyDown(KeyCode.H))
					{
						manager.StartHost();
						//showGUI = false;
					}
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					print (manager.networkAddress);
					manager.StartClient();
					//showGUI = false;
				}
			}
			if (NetworkServer.active && manager.IsClientConnected())
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					manager.StopHost();
				}
			}
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			int xpos = 10 + offsetX;
			int ypos = 40 + offsetY;
			const int spacing = 24;

			bool noConnection = (manager.client == null || manager.client.connection == null ||
			                    manager.client.connection.connectionId == -1);

			if (!manager.IsClientConnected () && !NetworkServer.active && manager.matchMaker == null) {
				if (noConnection) {
					if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer) {
						if (GUI.Button (new Rect (xpos, ypos, 200, 20), "LAN Host(H)")) {
							manager.StartHost ();
						}
						ypos += spacing;
					}

					if (GUI.Button (new Rect (xpos, ypos, 105, 20), "LAN Client(C)")) {
						manager.StartClient ();
					}
					manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), manager.networkAddress);
					ypos += spacing;


				}
			} else {
				if (NetworkServer.active) {
					string serverMsg = "Server: port=" + manager.networkPort;
					if (manager.useWebSockets) {
						serverMsg += " (Using WebSockets)";
					}
					GUI.Label (new Rect (xpos, ypos, 300, 20), serverMsg);
					ypos += spacing;
				}
				if (manager.IsClientConnected ()) {
					GUI.Label (new Rect (xpos, ypos, 300, 20), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
					ypos += spacing;
				}
			}

			if (manager.IsClientConnected () && !ClientScene.ready) {
				if (GUI.Button (new Rect (xpos, ypos, 200, 20), "Client Ready")) {
					ClientScene.Ready (manager.client.connection);

					if (ClientScene.localPlayers.Count == 0) {
						ClientScene.AddPlayer (0);
					}
				}
				ypos += spacing;
			}

			if (NetworkServer.active || manager.IsClientConnected ()) {
				if (GUI.Button (new Rect (xpos, ypos, 200, 20), "Stop (X)")) {
					manager.StopHost ();
				}
				ypos += spacing;
			}
		}
		}
	}

#endif //ENABLE_UNET