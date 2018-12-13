using UnityEngine;
using UnityEngine.Networking;

public class TestDiscovery : NetworkDiscovery {
	private void Start() {
		// Initialize();

		if (Application.isEditor) {
			//StartAsClient();
		}
		else {
			NetworkManager.singleton.StartServer();
			//StartAsServer();
		}
	}

	public override void OnReceivedBroadcast(string fromAddress, string data) {
		Debug.Log($"Received {data} from {fromAddress}");

		NetworkManager.singleton.StartClient();

		StopBroadcast();
	}
}
