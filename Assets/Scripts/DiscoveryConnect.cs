using System;
using UnityEngine;
using UnityEngine.Networking;

public class DiscoveryConnect : NetworkDiscovery {
	public Action<string, string> OnReceived;

	private void Start() {
		Initialize();
	}

	public override void OnReceivedBroadcast(string fromAddress, string data) {
		// TODO: remove this
		Debug.Log($"fromAddress: {fromAddress}");
		Debug.Log($"data: {data}");

		StopBroadcast();
		NetworkManager.singleton.networkAddress = fromAddress;
		NetworkManager.singleton.StartClient();

		OnReceived?.Invoke(fromAddress, data);
	}
}
