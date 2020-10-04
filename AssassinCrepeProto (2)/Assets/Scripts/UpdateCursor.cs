using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCursor : MonoBehaviour
{
    // Start is called before the first frame update
    CursorImage cursor;
    bool holding;
    void Start()
    {
        cursor = Camera.main.GetComponent<CursorImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {            
            cursor.setGrab();
        }        
    }

    public void OnMouseEnter()
    {
        cursor.setPoint();
    }
   
    public void OnMouseExit()
    {
        cursor.setBasic();
    }

    void OnMouseDown()
    {
        holding = true;
    }

    void OnMouseUp()
    {
        holding = false;
        cursor.setBasic();
    }

    void OnDisable()
    {        
        cursor.setBasic();
    }
}
