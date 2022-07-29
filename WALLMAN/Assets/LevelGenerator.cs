using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float l;
    public Transform Obstacles;
    public Transform Roads;
    public Transform RoadTriggers;
    public Transform WallClone;
    //public Transform WallCloneMoving;
    public Transform BrokenWallClone;
    private Vector3 nextBrokenWall;
    public GameObject BrokenWall;
    private Vector3 nextWallClone;
    public GameObject Wall;
    //private Vector3 nextWallCloneMoving;
    //public GameObject WallMoving;
    public Transform RoadClone;
    private Vector3 nextRoadClone;
    public GameObject Road;
    public Transform RoadTriggerClone;
    private Vector3 nextRoadTriggerClone;
    public GameObject RoadTrigger;
    // Start is called before the first frame update

    void Start()
    {
        l = 0.8f;
        nextWallClone.z = Random.Range(-1.10f, 1.10f);
        nextWallClone.y = 1.59f;
        nextWallClone.x = 12;
        StartCoroutine(spawnWallClone());
        nextRoadClone.y = 1;
        nextRoadClone.x = 59.9f;
        StartCoroutine(spawnRoadClone());
        nextRoadTriggerClone.z = 0;
        nextRoadTriggerClone.y = 3;
        nextRoadTriggerClone.x = 45f;
        StartCoroutine(spawnRoadTriggerClone());
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnWallClone()
    {
        
        yield return new WaitForSeconds(l);
        Wall = Instantiate(Wall, nextWallClone, WallClone.rotation);
        //BrokenWall = Instantiate(BrokenWall, nextWallClone, WallClone.rotation);
        //Vector3 randomSize = new Vector3(0.3f, 1, Random.Range(1f, 2f));
        //Wall.transform.localScale = randomSize;
        Wall.transform.SetParent(Obstacles);
        Wall.tag = "WallClone";
        Wall.name = "CloneWall";
        //BrokenWall.SetActive(false);
        //BrokenWall.tag = "BrokenWallClone";
        //BrokenWall.name = "CloneBrokenWall";
        nextWallClone.x += 3;
        nextWallClone.z = Random.Range(-1f, 1f);
        nextBrokenWall.x += 3;
        nextBrokenWall.z = Random.Range(-1f, 1f);
        StartCoroutine(spawnWallClone());
    }
    IEnumerator spawnRoadClone()
    {
        yield return new WaitForSeconds(l);
        Road = Instantiate(Road, nextRoadClone, RoadClone.rotation);
        Road.transform.SetParent(Roads);
        Road.tag = "RoadClone";
        Road.name = "CloneRoad";
        nextRoadClone.x += 30f;
        StartCoroutine(spawnRoadClone());
    }
    IEnumerator spawnRoadTriggerClone()
    {
        yield return new WaitForSeconds(l);
        RoadTrigger = Instantiate(RoadTrigger, nextRoadTriggerClone, RoadTriggerClone.rotation);
        RoadTrigger.transform.SetParent(RoadTriggers);
        RoadTrigger.tag = "TriggerClone";
        RoadTrigger.name = "CloneTrigger";
        nextRoadTriggerClone.x += 30f;
        StartCoroutine(spawnRoadTriggerClone());
    }
    
}
