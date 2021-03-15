using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    float speed;
    Rigidbody rb;
    public float t;
    public bool hasStartedT;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        rb = gameObject.GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
        if (!hasStartedT)
        {
            StartCoroutine(timedDestroy());
            hasStartedT = true;
        }
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
