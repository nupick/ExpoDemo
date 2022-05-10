using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickVerticalScaler : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform joyStick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((float)Screen.width / Screen.height < 1)
        {
            joyStick.localScale = new Vector3(1,1,1);
            joyStick.anchoredPosition = new Vector3(0,160,0);
        }
        else
        {
            joyStick.localScale = new Vector3(0.5f,0.5f,1);
            //Debug.Log(joyStick.localPosition);
            joyStick.anchoredPosition = new Vector3(0,80,0);
        }
    }
}
