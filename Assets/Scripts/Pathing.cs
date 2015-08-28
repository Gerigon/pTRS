using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathing : MonoBehaviour {

	public float moveSpeed = 5;
	public Transform marker;
	public Camera cam;
	public Vector3 movePoint;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		GetInput();
		MoveToPos();
	}

	void GetInput() {
		if(Input.GetMouseButtonDown(1)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.transform.tag == "ground") {
				Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
				movePoint = hit.point;
				Instantiate(marker,movePoint,Quaternion.identity);
			}
		}
	}

	void MoveToPos() {
		//transform.LookAt(movePoint);
		Ray myRay = new Ray(transform.position, movePoint-transform.position);
		
		RaycastHit myHit;
		if (Physics.Raycast (myRay, out myHit,5)) {
			if(myHit.transform != transform)
				Debug.DrawRay(transform.position, myRay.direction * 20, Color.yellow);
		}
		//transform.position = Vector3.MoveTowards(transform.position,movePoint,Time.deltaTime *moveSpeed);
	}
}
