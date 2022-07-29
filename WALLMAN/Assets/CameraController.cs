using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    public float CamSpeed;
    public Transform target;
    public Transform CamTransform;
    public Rigidbody rb;
    public PlayerController player;
    public bool isDead = false;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 targetpos = new Vector3(target.position.x + 4f, CamTransform.position.y, CamTransform.position.z);
        CamTransform.position = Vector3.Lerp(CamTransform.position, targetpos, Time.fixedDeltaTime * CamSpeed);
        //rb.velocity = new Vector3(CamSpeed, 0, 0);
        if (player.enabled == false)
        {
            isDead = true;
            CamSpeed = 0;
            rb.velocity = new Vector3(CamSpeed, 0, 0);
        }
        
    }
}