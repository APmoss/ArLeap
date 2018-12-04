using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFloat : MonoBehaviour {
	private void Update () {
		transform.Rotate(0f, 30f * Time.deltaTime, 0f);
		transform.localPosition = new Vector3(0f, (Mathf.Sin(Time.time) + 1) / 6, 0f);

		Debug.Log($"wew {Time.deltaTime}");
	}
}
