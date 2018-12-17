using UnityEngine;

public class CopyTransform : MonoBehaviour {
	public Transform Target;

	void Update () {
		transform.localPosition = Target.localPosition;
		transform.localRotation = Target.localRotation;
		transform.localScale = Target.localScale;
	}
}
