using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody rg;
    public InputAction move;
    private Vector2 movement;
    public float moveSpeed = 100f;
    private float mainThrust = 500f;
    private float wandThrust = 300f;
    private bool toJump = false;
    private bool frontDirection = true;
    
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        // GameManager.instance.freezeActive.AddListener(ToFreezeActive);
        // GameManager.instance.freezeInactive.AddListener(ToFreezeInactive); 
    }

    void Update()
    {
        ToMove();
        ToReversing();
        ToJumpOnGround(mainThrust);
        ToChangeFreezeActive();
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

    public void ToJumpOnLeftWall(float thrust)
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

     public void ToChangeFreezeActive(){
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
           rg.isKinematic = !rg.isKinematic;
        }
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Stalk"))
        {
            toJump = true;
        }
        else if (collision.gameObject.CompareTag("LeftWall") && toJump == false)
        {
            ToJumpOnLeftWall(wandThrust);
        }
        else if (collision.gameObject.CompareTag("RightWall") && toJump == false)
        {
            ToJumpOnRightWall(wandThrust);
        }
    }
}