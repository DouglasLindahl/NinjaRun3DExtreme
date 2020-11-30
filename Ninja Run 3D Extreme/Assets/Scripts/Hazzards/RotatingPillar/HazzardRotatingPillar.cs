using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardRotatingPillar : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime);

        
    }

    void OnCollisionEnter(Collider other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            
            other.transform.parent.parent.gameObject.GetComponent<PlayerDeath>().dead = true;
        }
    }
}
