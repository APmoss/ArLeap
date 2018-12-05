using UnityEngine;
using UnityEngine.Networking;

public class TestDiscovery : NetworkDiscovery {
	private bool? _isServer;

	private void Start() {
		// Initialize();

		if (Application.isEditor) {
			//StartAsClient();
		}
		else {
			_isServer = true;

			NetworkManager.singleton.StartServer();
			//StartAsServer();
		}
	}

	public override void OnReceivedBroadcast(string fromAddress, string data) {
		Debug.Log($"Received {data} from {fromAddress}");

		_isServer = false;

		NetworkManager.singleton.StartClient();

		StopBroadcast();
	}
}
