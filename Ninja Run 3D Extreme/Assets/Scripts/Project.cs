using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    public float t;
    bool hasStartedT;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    void Update()
    {
        if (!hasStartedT)
        {
            Debug.Log(t);
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
