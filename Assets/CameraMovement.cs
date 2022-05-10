using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float movementSpeed;
    private float X;
    private float Y;

    Vector3 pointA;
    Vector3 pointB;
    bool touchstart;
    public GameManager gameManager;


    public Joystick joystick;
    public float xrot;
    public float yrot;

    public GameObject Controller;
    //new movement method

    // Start is called before the first frame update
    void Start()
    {
        //xrot = 180;
        xrot = transform.rotation.eulerAngles.y;
        yrot = Mathf.Clamp(yrot,-70,90);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.isMobile())
        {
            yrot = Mathf.Clamp(yrot, -70, 90);
            xrot += joystick.Horizontal * speed * Time.deltaTime * -35;
            Controller.transform.rotation = Quaternion.Euler(0, xrot, 0);
            yrot += joystick.Vertical * speed * Time.deltaTime * 35;
            transform.rotation = Quaternion.Euler(yrot, xrot, 0);
        }

        else
        {

            if (Input.GetMouseButtonDown(0)) 
            {
                pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Camera.main.transform.position.z, Input.mousePosition.y));
            }

            if (Input.GetMouseButton(0))
            {

                transform.Rotate(
                    new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
                X = transform.rotation.eulerAngles.x;
                Y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(X, Y, 0);

                    //transform.rotation = Quaternion.Euler(joystick.Horizontal * speed, joystick.Vertical * speed, 0);


            }

        }
        if(Input.GetMouseButtonUp(0))
        {
            touchstart = false;
        }
        //if(Input.GetKey(KeyCode.W))
        //{
        //    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(transform.forward.x * movementSpeed,0,transform.forward.z * movementSpeed), Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(transform.right.x * movementSpeed, 0, transform.right.z * movementSpeed), Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-transform.forward.x * movementSpeed, 0, -transform.forward.z * movementSpeed), Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-transform.right.x * movementSpeed, 0, -transform.right.z * movementSpeed), Time.deltaTime);
        //}
    }
    void FixedUpdate()
    {
        if(touchstart)
        {
            Vector3 offset = pointB - pointA;
            offset.y = 0;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            Debug.Log(direction);
            MoveCharacter(direction);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + direction*movementSpeed,Time.deltaTime);
    }
}
