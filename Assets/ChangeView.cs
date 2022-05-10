using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
public class ChangeView : MonoBehaviour
{

    public GameObject nextCamera;
    public GameObject currCamera;
    public GameObject currIndicator;
    public GameObject nextIndicator;

    public Texture2D defaultCursor;
    public Texture2D handCursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currCamera.SetActive(false);
            currIndicator.SetActive(false);
            nextIndicator.SetActive(true);
            nextCamera.SetActive(true);

        }
    }

    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        }

    }
    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
