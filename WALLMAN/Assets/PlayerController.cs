using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float arspeed;
    public float joyspeed;
    public float gravity;
    public string htmlValue;
    [SerializeField]
    Material PlayerMat;
    public Color newPlayerColor;
    //public FixedJoystick joystick;
    public bool isRunningBackwards = false;
    public bool moveLeft = false;
    public bool moveRight = false;
    void Awake()
    {
        htmlValue = PlayerPrefs.GetString("CharacterColor");
        switch (htmlValue)
        {
            case "red":
                PlayerMat.color = Color.red;
                break;
            case "blue":
                PlayerMat.color = Color.blue;
                break;
            case "green":
                PlayerMat.color = Color.green;
                break;
            case "yellow":
                PlayerMat.color = Color.yellow;
                break;
            case "cyan":
                PlayerMat.color = Color.cyan;
                break;
            case "pink":
                PlayerMat.color = Color.magenta;
                break;
            case "white":
                PlayerMat.color = Color.white;
                break;
            case "black":
                PlayerMat.color = Color.black;
                break;
        };
    }
    void Start()
    {
        // joystick = FindObjectOfType<FixedJoystick>();
        
    }
    void Update()
    {
        newPlayerColor = PlayerMat.color;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0, 0);  // передвижение персонажа по вектору в сторону(speed, 0, 0);
        var animator = GetComponent<Animator>();
        //animator.applyRootMotion = true; 
        /*if (Input.GetKey(KeyCode.W))
        {
            isRunningBackwards = false;
            var movementup = new Vector3(2, 0, 0);
            rb.AddForce(movementup * speed, ForceMode.Impulse);
            animator.Play("BasicMotions@Run01");
        } //else*/
        //{
        //rb.velocity = new Vector3(joystick.Vertical * joyspeed, rb.velocity.y, -joystick.Horizontal * joyspeed);
        //animator.applyRootMotion = false;
        //} 
        if (Input.GetKey(KeyCode.S))
        {
            isRunningBackwards = true;
            var movementdown = new Vector3(-2, 0, 0);
            rb.AddForce(movementdown * speed, ForceMode.Impulse);
            animator.Play("BasicMotions@RunBackwards01");
        }
        if (Input.GetKey(KeyCode.A))
        {
            isRunningBackwards = false;
            var movementleft = new Vector3(0, 0, 2);
            rb.AddForce(movementleft * speed, ForceMode.Impulse);
            if (Input.GetKey(KeyCode.W))
            {
                animator.Play("BasicMotions@Run01");
            }
            else if (Input.GetKey(KeyCode.S))
            { 
                animator.Play("BasicMotions@RunBackwards01");
            }

        } 
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(Input.GetAxis("Horizontal"));
            Vector3 dirVector = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")).normalized;
            rb.MovePosition(transform.position + dirVector * arspeed * Time.deltaTime);
            rb.AddForce(-transform.up * gravity, ForceMode.Acceleration);
            //isRunningBackwards = false;
            //var movementright = new Vector3(0, 0, -2);
            //rb.AddForce(movementright * speed, ForceMode.Impulse);
            if (Input.GetKey(KeyCode.W))
            {
                animator.Play("BasicMotions@Run01");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.Play("BasicMotions@RunBackwards01");
            }
          
        }
        
        if (moveLeft == true)
        {
            Vector3 dirVector = new Vector3(0, 0, 1).normalized; // присвоение направлению нормализованного вектора в сторону (0,0,1)
            rb.MovePosition(transform.position + dirVector * arspeed *Time.deltaTime); // передвижение объекта в этом направление с установленной скоростью*время между последним кадром
        }
        
        if (moveRight == true)
        {
            Vector3 dirVector = new Vector3(0, 0, -1).normalized; // присвоение направлению нормализованного вектора в сторону (0,0,-1)
            rb.MovePosition(transform.position + dirVector * arspeed * Time.deltaTime); // передвижение объекта в этом направление с установленной скоростью*время между последним кадром
        }
    }
    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }
    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector3.zero;
    }


}
    