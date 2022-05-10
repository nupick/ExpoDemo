using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cipal_Move_Towards_End : MonoBehaviour
{
    public Vector3 direction;
    private GameObject player;
    public bool isThrough = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrough)
        {
            player.transform.Translate(direction*Time.deltaTime,Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            if (isThrough == false)
            {
                //other.GetComponent<CameraMovement>().enabled = false;
                var parent = other.transform.parent;
                parent.GetComponent<moveAgent>().enabled = false;
                parent.GetComponent<NavMeshAgent>().enabled = false;
                isThrough = true;
                player = parent.gameObject;
            }
            else
            {
                isThrough = false;
            }
        }
    }
}
