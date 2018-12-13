using UnityEngine;
using UnityEngine.Networking;

public class DesktopController : MonoBehaviour {
	public DiscoveryConnect DiscoveryConnect;

	private bool _mainScreen = true;

	private void Start () {

	}

	private void Update () {

	}

	private void OnGUI() {
		if (_mainScreen) {
			if (GUI.Button(new Rect(10, 10, 100, 100), "Start Server")) {
				_mainScreen = false;

				NetworkManager.singleton.StartServer();
				DiscoveryConnect.StartAsServer();
			}
			else if (GUI.Button(new Rect(110, 10, 100, 100), "Start Client")) {
				_mainScreen = false;

				DiscoveryConnect.StartAsClient();
			}
		}
	}
}
