using UnityEngine;

public class EnableWindows : MonoBehaviour {
	private void Awake() {
		var activate =
			Application.platform == RuntimePlatform.WindowsEditor ||
			Application.platform == RuntimePlatform.WindowsPlayer;

		gameObject.SetActive(activate);
	}
}
