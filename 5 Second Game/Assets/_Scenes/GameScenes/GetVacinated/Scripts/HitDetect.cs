using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private SceneManagement scene;

    private void OnMouseDown()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("HITTTTTT");
            scene = GetComponent<SceneManagement>();
            scene.LoadGameScene();
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(10f,0f), cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
      
    }
}
