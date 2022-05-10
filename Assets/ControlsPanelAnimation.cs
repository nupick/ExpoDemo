using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ControlsPanelAnimation : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public float speed = 0;

    float transparency = 0;
    public Image transparentbackground;
    public TextMeshProUGUI elapsed;
    public TextMeshProUGUI length;
    public TextMeshProUGUI slash;

    public bool isInsideRect;
    // Start is called before the first frame update
    void Start()
    {
        transparency = transparentbackground.color.a;
        isInsideRect = false;
        StartCoroutine(ControlsFade());
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(Image img in GetComponentsInChildren<Image>())
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (speed * Time.deltaTime));
            elapsed.color = new Color(elapsed.color.r, elapsed.color.g, elapsed.color.b, elapsed.color.a - (speed * Time.deltaTime));
            length.color = new Color(length.color.r, length.color.g, length.color.b, length.color.a - (speed * Time.deltaTime));
            slash.color = new Color(slash.color.r, slash.color.g, slash.color.b, slash.color.a - (speed * Time.deltaTime));

        }



    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("GOING IN!");
        isInsideRect = true;
        speed = 0;
        foreach (Image img in GetComponentsInChildren<Image>())
        {
            if(img != transparentbackground)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
                elapsed.color = new Color(elapsed.color.r, elapsed.color.g, elapsed.color.b, 1);
                length.color = new Color(length.color.r, length.color.g, length.color.b, 1);
                slash.color = new Color(slash.color.r, slash.color.g, slash.color.b, 1);
            }
            else
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, transparency);
            }
        }
        
    }

    public void OnPointerStay(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("GOING Out!");

        StartCoroutine(ControlsFade());
    }

    IEnumerator ControlsFade()
    {
        isInsideRect = false;
        yield return new WaitForSeconds(3f);
        if (!isInsideRect)
        {
            speed = 3;
        }
        
    }
}
