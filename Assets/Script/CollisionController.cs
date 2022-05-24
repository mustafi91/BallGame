using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
  
    public GameObject frontWharf;
    private Vector3 startPoint;
    private Rigidbody rg;
    void Start()
    {
        startPoint = transform.position;
        rg = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spinner"))
        {
            GameManager.instance.ToLoss();
            rg.isKinematic = !rg.isKinematic;
            transform.position = startPoint;
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            GameManager.instance.ToLoss();
            rg.isKinematic = !rg.isKinematic;
            transform.position = frontWharf.transform.position;
           
        }
        else if (collision.gameObject.CompareTag("firstLevelWin"))
        {
            GameManager.instance.ToWinLevelOne();
        }

    }
}
