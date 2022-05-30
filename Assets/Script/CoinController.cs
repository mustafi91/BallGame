using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float xAngle = 0;
    public float yAngle = 0;
    public float zAngle = 2;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.CollectionOfManey();   
        }
    }
}
