using UnityEngine;
using UnityEngine.Networking;

public class DesktopController : MonoBehaviour {
	public DiscoveryConnect DiscoveryConnect;
	public GameObject LeapController;

	private bool _mainScreen = true;

	private void Start() {
		Physics.gravity = new Vector3(0f, -0.5f, 0f);
	}

	private void OnGUI() {
		if (_mainScreen) {
			if (GUI.Button(new Rect(10, 10, 100, 100), "Start Server")) {
				StartServer();
			}
			else if (GUI.Button(new Rect(110, 10, 100, 100), "Start Client")) {
				StartClient();
			}
		}
	}

	private void StartServer() {
		_mainScreen = false;

		NetworkManager.singleton.StartServer();
		DiscoveryConnect.StartAsServer();

		LeapController.SetActive(true);
	}

	private void StartClient() {
		_mainScreen = false;

		DiscoveryConnect.StartAsClient();
	}
}
