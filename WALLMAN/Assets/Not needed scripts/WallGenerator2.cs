using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator2 : MonoBehaviour
{
    public Transform WallClone;
    private Vector3 nextWallClone;
    public GameObject Wall;
    // Start is called before the first frame update

    void Start()
    {
        nextWallClone.z = Random.Range(-1f, 1f);
        nextWallClone.y = 2;
        nextWallClone.x = 12;
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
        WallClone.tag = "WallClone";
        WallClone.name = "CloneWall";
        nextWallClone.x += 3;
        nextWallClone.z = Random.Range(-1f, 1f);
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

