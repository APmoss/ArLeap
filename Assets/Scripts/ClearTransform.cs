using UnityEngine;

public class ClearTransform : MonoBehaviour {
	private void Update () {
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}
}
