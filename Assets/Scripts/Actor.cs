using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public bool selected;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = GameManager.InvertRectY(camPos.y);
            Debug.Log("Width: " + GameManager.selection.width);
            Debug.Log("height: " + GameManager.selection.height);
            if (GameManager.selection.width > 0 && GameManager.selection.height > 0)
            {
                selected = GameManager.selection.Contains(camPos);
            }
            else if(GameManager.selection.width > 0 && GameManager.selection.height < 0)
            {
                Debug.Log("linksonderin");
                Debug.Log(GameManager.InvertRectY(Input.mousePosition.y) + GameManager.selection.height);
                selected = new Rect(Input.mousePosition.x, GameManager.InvertRectY(Input.mousePosition.y) + GameManager.selection.height, GameManager.selection.width, GameManager.selection.height).Contains(camPos);
            }
        }

        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
