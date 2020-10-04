using UnityEngine;
using System.Collections;

public class CursorImage : MonoBehaviour
{
    public Texture2D basic;
    public Texture2D point;
    public Texture2D grab;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setBasic()
    {
        Cursor.SetCursor(basic, hotSpot, cursorMode);
    }

    public void setPoint()
    {
        Cursor.SetCursor(point, hotSpot, cursorMode);
    }
    public void setGrab()
    {
        Cursor.SetCursor(grab, hotSpot, cursorMode);
    }
}