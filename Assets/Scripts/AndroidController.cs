using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GoogleARCore;
using UnityEngine;

public class AndroidController : MonoBehaviour {
	public DiscoveryConnect DiscoveryConnect;
	public Transform ManipHandsTransform;
	public Transform FloorTransform;
	public GameObject BallPrefab;

	private System.Random _rand = new System.Random();
	private bool _mainScreen = true;

	private Transform _floorOriginalParent;
	private string _msg;
	private List<AugmentedImage> _augImgBuffer = new List<AugmentedImage>();
	private Anchor _anchor;

	private GUIStyle _largeStyle;

	private void Start() {
		_floorOriginalParent = FloorTransform.parent;

		_largeStyle = new GUIStyle(GUI.skin.box);
		_largeStyle.fontSize = 72;
	}

	private void Update() {
		_msg = "";

		if (Session.Status != SessionStatus.Tracking) {
			return;
		}

		Session.GetTrackables(_augImgBuffer, TrackableQueryFilter.Updated);

		if (_augImgBuffer.Any()) {
			var augImg = _augImgBuffer.First();

			if (augImg.TrackingState == TrackingState.Tracking && _anchor == null) {
				_anchor = augImg.CreateAnchor(augImg.CenterPose);

				ManipHandsTransform.gameObject.SetActive(true);
				ManipHandsTransform.SetParent(_anchor.transform, false);
				FloorTransform.gameObject.SetActive(true);
				FloorTransform.SetParent(_anchor.transform, false);
			}
			else if (augImg.TrackingState == TrackingState.Stopped && _anchor != null) {
				ManipHandsTransform.gameObject.SetActive(false);
				ManipHandsTransform.parent = null;
				FloorTransform.gameObject.SetActive(false);
				FloorTransform.parent = _floorOriginalParent;
				_anchor = null;
			}
		}
	}

	private void OnGUI() {
		if (_mainScreen) {
			if (GUI.Button(new Rect(10, 10, 500, 500), "Start Client")) {
				StartClient();
			}
		}
		else {
			//GUI.Box(new Rect(10, 10, 500, 500), _msg, _largeStyle);

			if (_anchor != null) {
				if (GUI.Button(new Rect(1510, 10, 1000, 500), "Spawn Ball")) {
					var ball = GameObject.Instantiate(BallPrefab, _anchor.transform);
					ball.transform.Translate(new Vector3(0f, 0.5f, 0f));
					var randScale = _rand.Next(0, 5) / 100f + 0.05f;
					ball.transform.localScale = new Vector3(randScale, randScale, randScale);
				}
			}
		}
	}

	private void StartClient() {
		_mainScreen = false;

		DiscoveryConnect.StartAsClient();
	}
}
