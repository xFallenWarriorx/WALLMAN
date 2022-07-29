using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDeactivator : MonoBehaviour
{
    public float DeleteSpeed;
    public Rigidbody rb;
    
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(DeleteSpeed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playercol.isInvincible == true)
        {
            gameObject.layer = 8;
        } else
        {
            gameObject.layer = 0;
        }*/
    }
}
