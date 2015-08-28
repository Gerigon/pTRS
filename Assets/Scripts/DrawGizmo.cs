using UnityEngine;
using System.Collections;

public class DrawGizmo : MonoBehaviour {

	Camera cam;
	
	void Start() {
		cam = GetComponent<Camera>();
	}
	
	void Update() {
		Ray ray = cam.ViewportPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
		if (Physics.Raycast(ray, out hit))
			print("I'm looking at " + hit.transform.name);
		else
			print("I'm looking at nothing!");
	}
}