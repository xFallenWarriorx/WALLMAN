using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public GameObject cube;
    private GameObject ground;
    public bool isHere = true;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Destroyer")
        {
            ground = GameObject.FindGameObjectWithTag("RoadClone");
            Debug.Log("destroyed");
            isHere = false;
            ground.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
