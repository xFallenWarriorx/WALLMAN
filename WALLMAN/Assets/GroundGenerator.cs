using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform WallClone;
    private Vector3 nextWallClone;
    public GameObject Wall;
    // Start is called before the first frame update

    void Start()
    {
        nextWallClone.y = 1;
        nextWallClone.x = 59.9f;
        StartCoroutine(spawnWallClone());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnWallClone()
    {
        yield return new WaitForSeconds(0.5f);
        Wall = Instantiate(Wall, nextWallClone, WallClone.rotation);
        Wall.tag = "RoadClone";
        Wall.name = "CloneRoad";
        nextWallClone.x += 30f;
        StartCoroutine(spawnWallClone());
    }
    void OnBecameVisible()
    {
        Debug.Log("vis");
    }
    void OnBecameInvisible()
    {
        Debug.Log("Invis");
    }
}


