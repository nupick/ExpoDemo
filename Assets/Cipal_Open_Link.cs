using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipal_Open_Link : MonoBehaviour
{
    public string id;
    public GameObject gameManager;
    private GameObject _gameObject;

    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
