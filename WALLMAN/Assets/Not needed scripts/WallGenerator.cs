using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject Wall;
    public GameObject WallClone;
    public Transform Player;
    public float z;
    public float y;
    public float distance;
    void Start()
    {
        transform.position = Player.position;
        distance = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(Player.position, transform.position);
       
        if (distance > 5f) { 
            for (int i = 1; i < 5; i++)
            {
                WallClone = Instantiate(Wall, new Vector3(2 + i * 2.0F, y, Random.Range(-1f, 1f)), Quaternion.identity);
                Wall.SetActive(false);
                WallClone.SetActive(true);
            }
        }
    }
}
