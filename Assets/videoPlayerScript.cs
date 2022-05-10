using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayerScript : MonoBehaviour
{
    VideoPlayer player;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying)
        {
            if(Input.GetMouseButtonDown(0))
            {
                player.Stop();
            }
        }
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < Distance)
        {
            player.Play();
        }
    }
}
