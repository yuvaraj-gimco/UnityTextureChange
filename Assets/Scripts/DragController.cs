using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour {


	public GameObject background;
	private Renderer rend;
	public Renderer block;
	public Texture texture;
	public Vector3 initialPostion;
	public Quaternion initialRotation;
	private bool dragging = false;
	//private bool change = false;
	private float distance;
	void Start() {

		block.GetComponent<Renderer> ();
		initialPostion = block.transform.position;
		Debug.Log(initialPostion);
		initialRotation = block.transform.rotation;
		Debug.Log(initialRotation);

	}

	void OnMouseEnter()
	{
		//Debug.Log("Mouse Clicked");
	}

	void OnMouseExit()
	{
		//Debug.Log("Mouse Moved");
	}

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		Debug.Log(distance);
		dragging = true;
	}

	void OnMouseUp()
	{
		//Debug.Log("drop");
		dragging = false;
		rend = background.GetComponent<Renderer> ();
		rend.material.mainTexture = texture;
		block.transform.position = initialPostion;
		block.transform.rotation = initialRotation;
		//change = true;
	}

	void Update()
	{
		if (dragging) {
			//Debug.Log("drag Started");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			transform.position = rayPoint;

		} 

	}


}
