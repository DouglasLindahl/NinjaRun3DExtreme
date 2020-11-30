﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardRotatingPillar : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime);

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent.parent.gameObject.GetComponent<PlayerDeath>().dead = true;
        }
    }
}
