using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody rg;
    public InputAction move;
    private Vector2 movement;
    public float moveSpeed;
    private float mainThrust = 500f;
    private bool toJump = false;
    private bool frontDirection = true;
    private bool slowDown = false;
    
    void Start()
    {
        rg = GetComponent<Rigidbody>();
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
            if (slowDown)
            {
                moveSpeed = 50f;
                var vector = new Vector3(input.x/4, 0, input.y/4);
                rg.AddForce(vector * moveSpeed * Time.deltaTime);    
            }
            else
            {
                moveSpeed = 100f;
                var vector = new Vector3(input.x, 0, input.y);
                rg.AddForce(vector * moveSpeed * Time.deltaTime);  
            }
        }
        else
        {
            if (slowDown)
            {
                moveSpeed = 50f;
                var vector = new Vector3(-input.x/4, 0, -input.y/4);
                rg.AddForce(vector * moveSpeed * Time.deltaTime);    
            }
            else
            {
                moveSpeed = 100f;
                var vector = new Vector3(-input.x, 0, -input.y);
                rg.AddForce(vector * moveSpeed * Time.deltaTime);  
            }
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

     public void ToChangeFreezeActive(){
        if (Keyboard.current.enterKey.wasPressedThisFrame && toJump)
        {
           rg.isKinematic = !rg.isKinematic;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Stalk"))
        {
            toJump = true;
            slowDown = false;  
        }
        else if (collision.gameObject.CompareTag("SlowDown"))
        {
            slowDown = true;
        }
    }
}
    



