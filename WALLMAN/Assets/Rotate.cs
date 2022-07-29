using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotSpeed = 80;
    public GameObject Platform;
    public bool rotateLeft = false;
    public bool rotateRight = false;

    void Update()
    {
        if (rotateLeft == true)
        {
            float rotX = rotSpeed * Mathf.Deg2Rad * Time.deltaTime * 60;
            Platform.transform.Rotate(0, rotX, 0);
        }
        if (rotateRight == true)
        {
            float rotX = rotSpeed * Mathf.Deg2Rad * Time.deltaTime * 60;
            Platform.transform.Rotate(0, -rotX, 0);
        }
    }
    public void RotateLeft()
    {
        rotateLeft = true;
    }
    public void RotateRight()
    {
        rotateRight = true;
    }
    public void RotateReset()
    {
        Platform.transform.rotation = Quaternion.identity;
    }
    public void RotateStop()
    {
        rotateLeft = false;
        rotateRight = false;
        Platform.transform.Rotate(0, 0, 0);
    }
}
