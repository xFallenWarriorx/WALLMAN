using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVis : MonoBehaviour
{
    public GameObject Wall;
    void OnBecameVisible()
    {
        Debug.Log("vis");
    }
    void OnBecameInvisible()
    {
        Debug.Log("Invis");
        Wall.SetActive(false);
    }
}
