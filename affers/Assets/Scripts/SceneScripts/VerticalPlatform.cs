using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                waitTime = 0.1f;
            }
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180;
                waitTime = 0.1f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Z))
        {
            effector.rotationalOffset = 0;
        }
    }
}
