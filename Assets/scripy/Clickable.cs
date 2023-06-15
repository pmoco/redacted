using UnityEngine;

public class Clickable : MonoBehaviour
{
    public Texture2D clickCursor; // Reference to the click cursor texture
    private Texture2D oldCursor;
    public Vector2 cursorHotspot ;

    private void Start()
    {

        

        if (cursorHotspot ==Vector2.zero) 
            cursorHotspot = new Vector2(clickCursor.width / 2, clickCursor.height / 2);
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(clickCursor, cursorHotspot, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}