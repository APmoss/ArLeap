using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpinFloat : NetworkBehaviour {
	private void Update() {
		if (isServer) {
			transform.Rotate(0f, 30f * Time.deltaTime, 0f);
			transform.localPosition = new Vector3(0f, (Mathf.Sin(Time.time) + 1) / 6, 0f);
		}
	}
}
