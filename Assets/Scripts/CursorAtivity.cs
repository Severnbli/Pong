using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D _selectCursorTexture;

    private Vector2 _cursorHotspot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cursorHotspot = new Vector2(0, 0);
    }
    
    public void SelectCursor()
    {
        Cursor.SetCursor(_selectCursorTexture, _cursorHotspot, CursorMode.Auto);
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}