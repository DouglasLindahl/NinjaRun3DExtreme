using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private GameObject particleHolder;
    public bool dead;
    private float cubeSize = 0.2f;
    private int cubesInRow = 4;
    private float cubesPivotDistance;
    Vector3 cubesPivot;
    private float explosionRadius;
    private float explosionForce;
    private float explosionUpward;

    public GameObject sceneManager;
    

    void Start()
    {
        particleHolder = GameObject.FindGameObjectWithTag("ParticleHolder");

        dead = false;

        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        explosionForce = Random.Range(70, 90);
        explosionUpward = Random.Range(0.4f, 0.7f);
        explosionRadius = Random.Range(4, 6);
    }
    void Update()
    {
        if(transform.position.y <= -8 || dead)
        {
            sceneManager.GetComponent<PlayerFall>().shouldStartTimer = true;
            Die();
        }
    }

    //Förstör objektet och skapar x antal kuber relativt till objektets storlek för att simulera en explosion där objektet delas upp

    public void Die()
    {
        Explode();
    }

    public void Explode()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    //Skapar det objekt som "Explode" funktionen spawnar in
    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material.color = Color.yellow;

        piece.transform.parent = particleHolder.transform;
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.AddComponent<HazzardParticleDestroyer>();
        piece.layer = 10;
    }


}
