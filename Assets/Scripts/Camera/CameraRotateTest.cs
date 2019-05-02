using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateTest : MonoBehaviour
{

    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
