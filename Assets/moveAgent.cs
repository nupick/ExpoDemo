using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAgent : MonoBehaviour
{
    public float movementSpeed;
    public Joystick joystick;
    public GameManager gameManager;

    public GameObject Joystick1;
    public GameObject Joystick2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isMobile())
        {
            
            if (joystick.Horizontal > 0.3)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Camera.main.transform.right.x * movementSpeed, 0, Camera.main.transform.right.z * movementSpeed), Time.deltaTime);
            }
            if (joystick.Horizontal < -0.3)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-Camera.main.transform.right.x * movementSpeed, 0, -Camera.main.transform.right.z * movementSpeed), Time.deltaTime);
            }
            if (joystick.Vertical > 0.3)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Camera.main.transform.forward.x * movementSpeed, 0, Camera.main.transform.forward.z * movementSpeed), Time.deltaTime);
            }
            if (joystick.Vertical < -0.3)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-Camera.main.transform.forward.x * movementSpeed, 0, -Camera.main.transform.forward.z * movementSpeed), Time.deltaTime);
            }

            //transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(joystick.Horizontal * movementSpeed, 0, joystick.Vertical * movementSpeed), Time.deltaTime);
            Joystick1.SetActive(true);
            Joystick2.SetActive(true);

        }
        else
        {
            Joystick1.SetActive(false);
            Joystick2.SetActive(false);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Camera.main.transform.forward.x * movementSpeed, 0, Camera.main.transform.forward.z * movementSpeed), Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Camera.main.transform.right.x * movementSpeed, 0, Camera.main.transform.right.z * movementSpeed), Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-Camera.main.transform.forward.x * movementSpeed, 0, -Camera.main.transform.forward.z * movementSpeed), Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-Camera.main.transform.right.x * movementSpeed, 0, -Camera.main.transform.right.z * movementSpeed), Time.deltaTime);
            }
        }
        
    }
}
