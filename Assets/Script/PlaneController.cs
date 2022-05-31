using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private int timer = 1;
    private float thrustX = 0f;
    private float thrustY = 0f;
    private float thrustZ = 1f;
    private Vector3 startPoint;
    public GameObject bomb;
    private Rigidbody rb;
    private Rigidbody planeRigidBody;
    // public GameObject bigExplosion;
    // public GameObject fire;
    // GameObject bigExplosionInstace;
    // GameObject fireInstace;
   
    void Start()
    {
        startPoint = transform.position; 
        rb = bomb.GetComponent<Rigidbody>();
        planeRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ++timer;
        transform.Translate(thrustX,thrustY,thrustZ);  
        rb.isKinematic = false;
        if (timer % 183 == 0)
        {
           BombInstantiated();    
        }

        // if (bigExplosionInstace != null && fireInstace != null)
        // {
        //     fireInstace.transform.position = transform.position;
        //     bigExplosionInstace.transform.position = transform.position;
        // }

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
            // bigExplosionInstace = Instantiate(bigExplosion,transform.position,transform.rotation);
            // // fireInstace = Instantiate(fire,transform.position,transform.rotation);
            // Destroy(bigExplosionInstace, 5f); 
            // Destroy(fireInstace, 5f);
            Destroy(this, 5f);
        }
    }
}
