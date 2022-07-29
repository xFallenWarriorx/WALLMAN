using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public AudioSource WallCrash;
    public Animator PopGameOver;
    public Sprite Heart;
    public PlayerCollision playercol;
    public float InvincibilityTime;
    public GameObject player;
    public GameObject model;
    public GameObject destroyer;
    public GameObject portal1;
    public GameObject portal2;


    public float invincibilityDeltaTime;

    void Start()
    {
        numOfHearts = PlayerPrefs.GetInt("numOfHearts", 3);
    }
    void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
            if (playercol.isCrashed == true)
        {
            Dead();
        }
    }
    void Dead()
    {
        playercol.TheScore.scoreIncreasing = false;
        playercol.restart.SetActive(true);
        playercol.alive.enabled = false;
        playercol.Music.SetActive(false);
        playercol.animator.Play("BasicMotions@Idle01");
        playercol.alive.rb.velocity = new Vector3(0, 0, 0);
        playercol.destroyer.rb.velocity = new Vector3(0, 0, 0);
        playercol.buttons.SetActive(false);
        playercol.level.StopAllCoroutines();
        playercol.PauseButton.SetActive(false);
        PopGameOver.SetTrigger("Game Over");

    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "WallClone")
        {
            Debug.Log("Damaged");
            TakeDamage(1);
            playercol.isHit = true;
            WallCrash.Play();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyer")
        {
            Debug.Log("isCrashed");
            Dead();
            numOfHearts = 0;
        }
    }
   public void TakeDamage(int d)
    {
        if (playercol.isInvincible) return;
        if (numOfHearts >= 1)
        {
            numOfHearts -= d;
            if (numOfHearts < 1)
            {
                playercol.isCrashed = true;
                return;
            }
        }
        StartCoroutine(BecomeTemporarilyInvincible());
    }
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        playercol.isInvincible = true;
        gameObject.layer = 8;
        portal1.layer = 8;
        portal2.layer = 8;
        //destroyer.layer = 8;
        Physics.IgnoreLayerCollision(0,8,true);
        for (float i = 0; i < InvincibilityTime; i += invincibilityDeltaTime)
        {

            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }
      
        Debug.Log("Player is not invincible!");
        ScaleModelTo(Vector3.one);
        Physics.IgnoreLayerCollision(0, 8, false);
        gameObject.layer = 0;
        portal1.layer = 0;
        portal2.layer = 0;
        //destroyer.layer = 0;
        playercol.isHit = false;
        playercol.isInvincible = false;
    }
}
 
