using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTriggersGenerator : MonoBehaviour
{
    public Transform WallClone;
    private Vector3 nextWallClone;
    public GameObject Wall;
    // Start is called before the first frame update

    void Start()
    {
        nextWallClone.z = 0;
        nextWallClone.y = 3;
        nextWallClone.x = 45f;
        StartCoroutine(spawnWallClone());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnWallClone()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Wall, nextWallClone, WallClone.rotation);
        WallClone.tag = "TriggerClone";
        WallClone.name = "CloneTrigger";
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
