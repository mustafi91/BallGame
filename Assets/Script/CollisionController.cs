using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
  
    public GameObject waterPosition;
    public GameObject firePosition;
    private Vector3 startPoint;
    private Rigidbody rg;
    void Start()
    {
        startPoint = transform.position;
        rg = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spinner") ||
         collision.gameObject.CompareTag("LossGround"))
        {
            GameManager.instance.ToLoss();
            transform.position = startPoint;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.instance.ToLoss();
            transform.position = waterPosition.transform.position;
           
        }
         else if (collision.gameObject.CompareTag("Fire"))
        {
            GameManager.instance.ToLoss();
            transform.position = firePosition.transform.position;
           
        }
        else if (collision.gameObject.CompareTag("Missile") ||
                collision.gameObject.CompareTag("Bomb"))
        {
            GameManager.instance.ToLoss();
        }
        else if (collision.gameObject.CompareTag("firstLevelWin"))
        {
            GameManager.instance.ToWinLevelOne();
        }
        else if (collision.gameObject.CompareTag("twoLevelWin"))
        {
            GameManager.instance.ToWinLevelTwo();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            CannonPlayerController.throwLocation = false;  
        }
    }
}
