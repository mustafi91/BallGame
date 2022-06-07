using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
   public GameObject samallBomb;

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water") 
        || collision.gameObject.CompareTag("Fire")
        || collision.gameObject.CompareTag("Ground")
        || collision.gameObject.CompareTag("Stalk")
        || collision.gameObject.CompareTag("Spinner")
        || collision.gameObject.CompareTag("BackWall"))
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject smallBombInstance = Instantiate(samallBomb,transform.position,transform.rotation);
                Destroy(this);
                Destroy(smallBombInstance, 3f); 
            }    
        }
    }
   
}
