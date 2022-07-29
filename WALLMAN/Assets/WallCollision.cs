using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public int BrokenWalls;
    public LevelGenerator level;
    public WallBreaker breaker;
    public GameObject cube;
    public GameObject BrokenWall;
    private Vector3 nextBrokenWall;
    public Transform BrokenWallRot;
    public bool isHere = true;
    // Start is called before the first frame update

    void Start()
    {
        BrokenWalls = PlayerPrefs.GetInt("BrokenWalls");
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Destroyer")
        {
            //Debug.Log("destroyed");
            isHere = false;
            gameObject.SetActive(false);

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "WallBreaker")
        {
            //Debug.Log("destroyed");
            Destroy(gameObject);
            BrokenWalls = BrokenWalls + 1;
            PlayerPrefs.SetInt("BrokenWalls", BrokenWalls);
            BrokenWall = Instantiate(BrokenWall, gameObject.transform.position, BrokenWallRot.rotation);
            BrokenWall.tag = "BrokenWallClone";
            BrokenWall.name = "BrokenWall";
            Destroy(BrokenWall, 0.3f);
            Destroy(breaker.instWallBreakerObj);
            
        }
    }
}