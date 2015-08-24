using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Texture2D selectionColor;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one;

    public Player[] players = new Player[1];

	// Use this for initialization
	void Start () 
	{
        players[0] = new Player();
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputManager();
        //Debug.Log(startClick);

    }
    void InputManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (selection.width < 0)
            {
                Debug.Log("lower width");
                selection.x += selection.width;
                selection.width = -selection.width;
            }
            if (selection.height < 0)
            {
                Debug.Log("lower height");
                selection.y += selection.height;
                selection.height = -selection.height;
            }
            startClick = -Vector3.one;
        }
        if (Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, InvertRectY(startClick.y), Input.mousePosition.x - startClick.x, InvertRectY(Input.mousePosition.y) - InvertRectY(startClick.y));
        }
    }
    public static float InvertRectY(float y)
    {
        return Screen.height - y;
    }
    private void OnGUI()
    {
        if (startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, .5f);
            GUI.DrawTexture(selection, selectionColor);
        }
    }
    void SelectUnits()
    {
    }
}
 