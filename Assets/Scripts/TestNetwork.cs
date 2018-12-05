using UnityEngine;
using UnityEngine.Networking;

public class TestNetwork : MonoBehaviour {
	private bool? _isServer;

	private void Update() {
		if (!_isServer.HasValue) {
			if (Input.GetKeyDown(KeyCode.S)) {
				_isServer = true;

				NetworkManager.singleton.StartServer();
			}
			else if (Input.GetKeyDown(KeyCode.C)) {
				_isServer = false;

				NetworkManager.singleton.StartClient();
			}
		}
	}

	private void OnGUI() {
		var modeString = "";
		if (!_isServer.HasValue) {
			modeString = "None";
		}
		else {
			modeString = _isServer.Value ? "Server" : "Client";
		}

		GUI.Label(new Rect(10, 10, 150, 30), $"Current Mode: {modeString}");
	}
}
