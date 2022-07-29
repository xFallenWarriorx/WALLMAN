using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject Player;
    public PlayerController playercont;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = TeleportTarget.transform.position;
        playercont.rb.velocity = playercont.rb.velocity = new Vector3(playercont.speed, 0, 0);
        //Debug.Log("teleported");
    }
    void Update()
    {
        /*if (playercol.isInvincible == true)
        { 
            gameObject.layer = 8;
        } else
        {
            gameObject.layer = 0;
        }*/
    }
}
