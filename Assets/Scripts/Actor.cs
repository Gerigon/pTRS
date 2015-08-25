using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public bool selected;

    private Rect temp = new Rect(0, 0, 0, 0);
    private bool selectedByClick;


	void Start ()
    {
	
	}
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (!selectedByClick)
            {
                Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
                camPos.y = GameManager.InvertRectY(camPos.y);
                selected = GameManager.selection.Contains(camPos);
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

    private void OnMouseDown()
    {
        selectedByClick = true;
        selected = true;
    }
    private void OnMouseUp()
    {
        if (selectedByClick)
            selected = true;

        selectedByClick = false;
    }
}
