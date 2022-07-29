using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public int ShieldBought;
    public int ShieldsUsedInt;
    public GameObject shield;
    public GameObject player;
    public GameObject model;
    public Material mat;
    public Renderer rend;
    public HealthSystem health;
    public float ShieldTime;
    public float ShieldDeltaTime;
    public float ShieldSize;
    public bool ShieldisOn;
    public Button ShieldUse;
    public Image ShieldBar;
    public GameObject ShieldBarCanvas;
    public AudioSource ShieldTurnOn;

    // Start is called before the first frame update
    void Start()
    {
        ShieldsUsedInt = PlayerPrefs.GetInt("ShieldsUsed");
        ShieldBought = PlayerPrefs.GetInt("Shield");
        shield.SetActive(false);
        ShieldBarCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShieldBought == 0)
        {
            ShieldUse.interactable = false;
        }
        shield.transform.position = new Vector3(player.transform.position.x, 2, transform.position.z);
        if (ShieldisOn == true)
        {
            ShieldBarCanvas.SetActive(true);
          if (ShieldTime >= 0)
            { 
            ShieldBar.fillAmount -= 0.23f*Time.deltaTime;
            }
            if (ShieldBar.fillAmount == 0)
            {
                ShieldBar.fillAmount = 1;
            } else if (ShieldTime == 0)
            {
                ShieldBarCanvas.SetActive(false);
                ShieldBar.fillAmount = 1;
            }
         ShieldSize += 0.15f * Time.deltaTime;
        rend.material.SetFloat("_Displacement", ShieldSize);
        if (ShieldSize >= 0.650f)
            {
                ShieldisOn = false;
                shield.SetActive(false);
                ShieldSize = 0;
            }
        }

    }
    public void ShieldOn()
    {
        if (ShieldBought >= 1)
        {
        ShieldTurnOn.Play();
        ShieldsUsedInt = ShieldsUsedInt + 1;
        PlayerPrefs.SetInt("ShieldsUsed", ShieldsUsedInt);
        ShieldBought = ShieldBought - 1;
        shield.SetActive(true);
        ShieldisOn = true;
        StartCoroutine(ShieldTurn());
        rend.material.shader = Shader.Find("IndieChest/ForceShield");
        ShieldSize = 0f;
        rend.material.SetFloat("_Displacement", ShieldSize);
        }
    }
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    private IEnumerator ShieldTurn()
    {
        ShieldBar.fillAmount = 1;
        ShieldisOn = true;
        ShieldUse.interactable = false;
        health.gameObject.layer = 8;
        health.portal1.layer = 8;
        health.portal2.layer = 8;
        //health.destroyer.layer = 8;
        Physics.IgnoreLayerCollision(0, 8, true);
        

        /*for (float i = 0; i < ShieldTime; i += ShieldDeltaTime)
        {

                if (model.transform.localScale == new Vector3(2.2f, 2.2f, 2.2f))
                {
                    ScaleModelTo(Vector3.zero);
                }
                else
                {
                    ScaleModelTo(new Vector3(2.2f, 2.2f, 2.2f));
                }*/
        yield return new WaitForSeconds(ShieldTime);
            ScaleModelTo(new Vector3(2.2f, 2.2f, 2.2f));
            Physics.IgnoreLayerCollision(0, 8, false);
            gameObject.layer = 0;
            health.portal1.layer = 0;
            health.portal2.layer = 0;
            //health.destroyer.layer = 0;
            health.playercol.isHit = false;
            ShieldisOn = false;
            shield.SetActive(false);
            ShieldUse.interactable = true;
            ShieldBarCanvas.SetActive(false);

    }
    }

