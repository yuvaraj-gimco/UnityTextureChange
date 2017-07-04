using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity=5.0f;
	public float smoothing = 2.0f;
	public float lf = 10.0f;
	Vector2 mouseLook;
	Vector2 smoothV;


	GameObject character;

	// Use this for initialization
	void Start () {
		character = this.transform.parent.gameObject;


	}

	// Update is called once per frame
	void Update () {
		var md = new Vector2 (Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x,lf/ smoothing);
		smoothV.y=Mathf.Lerp (smoothV.y, md.y,lf/ smoothing);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x,character.transform.up);
	}
}
