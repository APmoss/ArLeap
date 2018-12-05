using UnityEngine;

public class EnableAndroid : MonoBehaviour {
	private void Awake() {
		var activate =
			Application.platform == RuntimePlatform.Android;

		gameObject.SetActive(activate);
	}
}
