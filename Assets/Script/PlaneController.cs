using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private float thrustX = 0f;
    private float thrustY = 0f;
    private float thrustZ = 1f;
    private Vector3 startPoint;
    public GameObject bomb;
    private Rigidbody rb;
    private Rigidbody planeRigidBody;
    private int randnum;
   
    void Start()
    {
        startPoint = transform.position; 
        rb = bomb.GetComponent<Rigidbody>();
        planeRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(thrustX,thrustY,thrustZ);  
        rb.isKinematic = false;
        randnum = Random.Range(0, 100);
        if (randnum ==5)
        {
           BombInstantiated();    
        }

    }

    void BombInstantiated(){
        GameObject bombInstance = Instantiate(bomb, transform.position, transform.rotation);
        Destroy(bombInstance, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FrontWall") || collision.gameObject.CompareTag("BackWall"))
        {
            transform.position = startPoint;
        }
        else  if (collision.gameObject.CompareTag("MissilePlayer"))
        {
            for (int i = 0; i < 10; i++)
            {
                GameManager.instance.CollectionOfManey();    
            }
            planeRigidBody.isKinematic = false;
            Destroy(this, 5f);
        }
    }
}
