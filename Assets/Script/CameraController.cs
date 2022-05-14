using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputAction cameraMove;
    public GameObject player;
    private Vector2 cameraMovement;
    private Vector3 cameraPosition;
    private Vector3 cameraRotation;
    private Vector3 backCameraPosition;
    private Quaternion backTarget;
    private bool back = false;
    private bool front = false;
    
    
    void Start()
    {
         cameraPosition = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + cameraPosition; 
        toDirection();
        toMove();

    }

    void OnEnable(){
        cameraMove.Enable();
    }

    void OnDisable(){
        cameraMove.Disable();
    }

    private void toDirection(){
        if(Keyboard.current.bKey.wasPressedThisFrame && !back )
        {
            backCameraPosition = new Vector3(-15f,0f,0f);
            backTarget = Quaternion.Euler(45f, 90f, 0f);
            cameraPosition =  transform.position - player.transform.position + backCameraPosition;
            transform.rotation = Quaternion.Slerp(transform.rotation, backTarget, 2f);
            back = !back;
            front = !front;
        }
        else if(Keyboard.current.vKey.wasPressedThisFrame && front )
        {
            backCameraPosition = new Vector3(15f,0f,0f);
            backTarget = Quaternion.Euler(45f, -90f, 0f);
            cameraPosition =  transform.position - player.transform.position + backCameraPosition;
            transform.rotation = Quaternion.Slerp(transform.rotation, backTarget, 2f);
            back = !back;
            front = !front;
        }
    }

    private void toMove(){
        cameraMovement = cameraMove.ReadValue<Vector2>();
        if (Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.Translate(0,0,cameraMovement.y*Time.deltaTime *100);
            cameraPosition =  transform.position - player.transform.position;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            transform.Translate(cameraMovement.x*Time.deltaTime *100,0,0);
            cameraPosition =  transform.position - player.transform.position;
        }
    }
}
