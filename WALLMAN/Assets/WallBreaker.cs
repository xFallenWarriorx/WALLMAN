using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallBreaker : MonoBehaviour
{
    public Button WallBreakerUse;
    public int WallBreakerBought;
    public float speed;
    public GameObject instWallBreakerObj;
    public GameObject WallBreakerObj;
    public AudioSource WallBreakerActivate;
    public bool isHere = true;
    // Start is called before the first frame update
    void Start()
    {
        WallBreakerBought = PlayerPrefs.GetInt("WallBreaker", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (WallBreakerBought == 0)
        {
            WallBreakerUse.interactable = false;
        }
    }
    public void WallBreakerUsed()
    {   if (WallBreakerBought >= 1)
        {
        WallBreakerActivate.Play();
        WallBreakerBought = WallBreakerBought - 1;
        instWallBreakerObj = Instantiate(WallBreakerObj, new Vector3(transform.position.x + 1,1.2f, transform.position.z), Quaternion.identity);
        Rigidbody instWallBreakerRB = instWallBreakerObj.GetComponent<Rigidbody>();

        instWallBreakerRB.AddForce(gameObject.transform.forward * speed);
        Destroy(instWallBreakerObj, 0.5f);
        }
    }

}
