using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;
public class textheightcheck : MonoBehaviour
{
    public RTLTextMeshPro text;
    public RectTransform container;
    public Scrollbar scrollbar;
    public Texture2D cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(9,3), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (text.IsActive()==true)
        {

            if (text.GetRenderedValues(true).y > 40)
            {
                container.sizeDelta = new Vector2(container.rect.width, text.GetRenderedValues(true).y + 450);
            }
        }

    }

     
}
