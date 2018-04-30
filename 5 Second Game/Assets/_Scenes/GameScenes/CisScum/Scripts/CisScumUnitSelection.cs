﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CisScumUnitSelection : MonoBehaviour {

    public Texture2D selectionHighlight = null;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one; 
    
	// Update is called once per frame
	void Update ()
    {
        CheckCamera();
	}

    public void CheckCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (selection.width < 0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;
            }
            if (selection.height < 0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }

            startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y; 
    }
}
