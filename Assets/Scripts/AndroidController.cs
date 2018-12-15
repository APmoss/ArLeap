using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour {
	public DiscoveryConnect DiscoveryConnect;

	private bool _mainScreen = true;

	private void OnGUI() {
		if (_mainScreen) {
			if (GUI.Button(new Rect(10, 10, 500, 500), "Start Client")) {
				StartClient();
			}
		}
	}

	private void StartClient() {
		_mainScreen = false;

		DiscoveryConnect.StartAsClient();
	}
}
