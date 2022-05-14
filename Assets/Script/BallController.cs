using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody rg;
    public InputAction move;
    private Vector2 movement;
    private Vector3 startPoint;
    public float moveSpeed = 100f;
    private float mainThrust = 500f;
    private float wandThrust = 300f;
    private bool toJump = false;
    private bool frontDirection = true;
    public GameObject frontWharf;
    public GameObject backWharf;
    public GameObject panal;
    public GameObject panalLoss;
    public GameObject panalMain;
    
    
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        startPoint = transform.position;
        panal.SetActive(false);
        panalLoss.SetActive(false);
    }

    void Update()
    {
        ToMove();
        ToReversing();
        ToJumpOnGround(mainThrust);
        ToFreeze(); 
    }

    void OnEnable()
    {
        move.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }

    private void ToMove()
    {
        var input = move.ReadValue<Vector2>();
       
        if (frontDirection)
        {
            var vector = new Vector3(-input.y, 0, input.x);
            rg.AddForce(vector * moveSpeed * Time.deltaTime); 
        }
        else
        {
            var vector = new Vector3(input.y, 0, -input.x);
            rg.AddForce(vector * moveSpeed * Time.deltaTime); 
        }
    }

    private void ToReversing()
    {
        if(Keyboard.current.vKey.wasPressedThisFrame)
        {
            frontDirection = true;
        }
        else if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            frontDirection = false;
        }
    }

    private void ToJumpOnGround(float thrust)
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && toJump)
        {
            rg.AddForce(0, thrust, 0);
            toJump = false;
        }
    }

    private void ToJumpOnLeftWall(float thrust)
    {
        if (frontDirection)
        {
           rg.AddForce(-thrust, thrust, thrust);  
        }
        else
        {
           rg.AddForce(+thrust, thrust, +thrust);   
        }
    }

    private void ToJumpOnRightWall(float thrust)
    {
        if (frontDirection)
        {
            rg.AddForce(-thrust, thrust, -thrust);
        }
        else
        {
            rg.AddForce(+thrust, thrust, -thrust);   
        }
    }


    private void ToFreeze()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            GameManager.instance.Freeze = !GameManager.instance.Freeze;
        }
        if (GameManager.instance.Freeze)
        {
            rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
            rg.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }
        else if (!GameManager.instance.Freeze)
        {
            rg.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrontGround"))
        {
            toJump = true;
            GameManager.instance.FrontGround = true;
            GameManager.instance.BackGround = false;
        }
        else if (collision.gameObject.CompareTag("BackGround"))
        {   
            toJump = true;
            GameManager.instance.FrontGround = false;
            GameManager.instance.BackGround = true;
        }
        else if (collision.gameObject.CompareTag("Stalk"))
        {
            toJump = true;
        }
        else if (collision.gameObject.CompareTag("LeftWall") && !toJump)
        {
            ToJumpOnLeftWall(wandThrust);
        }
        else if (collision.gameObject.CompareTag("RightWall") && !toJump)
        {
            ToJumpOnRightWall(wandThrust);
        }
        else if (collision.gameObject.CompareTag("Spinner"))
        {
            GameManager.instance.LossToPosition = true;
            GameManager.instance.ToLoss();
             if (GameManager.instance.GameOver)
            {
                panalLoss.SetActive(true);
                transform.position = startPoint;
                GameManager.instance.GameOver = false;
                GameManager.instance.Freeze =true;
                panalMain.SetActive(false);
            }
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.instance.WaterLoss = true;
           
            GameManager.instance.ToLoss();
            if (GameManager.instance.FrontGround)
            {  
                transform.position = frontWharf.transform.position;   
            }
            else if (GameManager.instance.BackGround)
            {  
                transform.position = backWharf.transform.position;   
            }
            if (GameManager.instance.GameOver)
            {
                panalLoss.SetActive(true);
                transform.position = startPoint;
                GameManager.instance.GameOver = false;
                GameManager.instance.Freeze =true;
                panalMain.SetActive(false);
            }
            
        }
        else if (collision.gameObject.CompareTag("firstLevelWin"))
        {
            GameManager.instance.ToWinLevelOne();
            panal.SetActive(true);
            panalMain.SetActive(false);
            GameManager.instance.EndLevel = true;
             // transform.position = startPoint;
        }
         else if (collision.gameObject.CompareTag("twoLevelWin"))
        {
            GameManager.instance.ToWinLevelTwo();
        }


        
    }
}