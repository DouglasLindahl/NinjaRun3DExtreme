using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    float speed;
    Rigidbody rb;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        if(t == 0)
        {
            t = 2;
        }
        StartCoroutine(timedDestroy());
        speed = 10;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
    IEnumerator timedDestroy()
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
