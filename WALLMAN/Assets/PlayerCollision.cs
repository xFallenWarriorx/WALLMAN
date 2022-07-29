using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isCrashed = false;
    public bool isHit = false;
    public bool isInvincible = false;
    public PlayerController alive;
    public GameObject restart;
    public ScoreBoard TheScore;
    public Restart RestartButton;
    public GameObject Music;
    public Animator animator;
    public WallDeactivator destroyer;
    public LevelGenerator level;
    public GameObject buttons;
    public GameObject PauseButton;
   

    void Start()
    {
        animator = GetComponent<Animator>();
        TheScore = FindObjectOfType<ScoreBoard>();
    }
    // Start is called before the first frame update
    /*void OnCollisionEnter(Collision collisioninfo)
    {
        
        if (collisioninfo.collider.tag == "WallClone")
        {
            Debug.Log("Dead");
            isCrashed = true;
            if (isCrashed == true)

            {
                TheScore.scoreIncreasing = false;
                restart.SetActive(true);
                alive.enabled = false;
                Music.SetActive(false);
                animator.Play("BasicMotions@Idle01");
                destroyer.rb.velocity = new Vector3(0, 0, 0);
                level.StopAllCoroutines();
            }
        }
    }*/
    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyer")
        {
            Debug.Log("Dead");
            isCrashed = true;
            if (isCrashed == true)

            {
                TheScore.scoreIncreasing = false;
                restart.SetActive(true);
                alive.enabled = false;
                Music.SetActive(false);
                animator.Play("BasicMotions@Idle01");
                destroyer.rb.velocity = new Vector3(0, 0, 0);
                level.StopAllCoroutines();
            }
        }
    }*/
}
