    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardDisappearingBlock : MonoBehaviour
{
    //Variabler som används när blocket förstörs
    [Header("Time variables")]
    public float time;
    public float ChargesUntilDestroy;
    private bool canReduceCharge;
    private bool startDestruction;

    //Variabler som används när objektet ändrar färg
    private bool changeColor;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private float t = 0;
    private float timeElapsed;
    private bool timeStarted = false;

    //Variabler för minikub som skapas efter explosion
    private float cubeSize = 0.2f;
    private int cubesInRow = 4;
    private float cubesPivotDistance;
    Vector3 cubesPivot;
    private float explosionRadius;
    private float explosionForce;
    private float explosionUpward;
    public GameObject particleHolder;
    public int wow;
    //Sätter variabler och komponenter lika med X
    void Awake()
    {
        canReduceCharge = true;
        startDestruction = false;
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    //Sätter variabler och komponenter lika med X
    void Start()
    {
        startDestruction = false;
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        explosionForce = Random.Range(90, 115);
        explosionUpward = Random.Range(0.4f, 0.7f);
        explosionRadius = Random.Range(4, 6);
    }

    //Kör funktioner enligt parametrar som getts en gång per frame
    void Update()
    {
        if(startDestruction == true && canReduceCharge == true)
        {
            destroyBlock();
        } 
        if(changeColor == true)
        {
            ChangeColor();
        }
    }

    //Tittar om spelaren touchat objektets collider och sätter i gång destroyBlock funktionen
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startDestruction = true;
        }
    }

    //Förstör objektet inom en viss tid genom att starta "StarToDestroy" coroutinen.
    void destroyBlock()
    {
            StartCoroutine(startToDestroy());
            changeColor = true;
    }

    //Förstör objektet efter en viss tid genom att trigga "Explode" funktionen
    IEnumerator startToDestroy()
    {
        if (ChargesUntilDestroy <= 0)
        {
            Explode();
        }
        canReduceCharge = false;

        yield return new WaitForSeconds(time);

        if(ChargesUntilDestroy > 0)
        {
            ChargesUntilDestroy--;
            canReduceCharge = true;
            //Debug.Log(ChargesUntilDestroy);
        }
    }

    //Förstör objektet och skapar x antal kuber relativt till objektets storlek för att simulera en explosion där objektet delas upp
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
            if(rb != null)
            {
                //Debug.Log(explosionForce);
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    //Skapar det objekt som "Explode" funktionen spawnar in
    void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material.color = endColor;

        piece.transform.parent = particleHolder.transform;
        piece.transform.position = transform.position +  new Vector3(cubeSize*x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize,cubeSize,cubeSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.AddComponent<HazzardParticleDestroyer>();
        piece.layer = 10;
    }
   
    //Ändrar färg över tid när ChangeColor boolen är true
    void ChangeColor()
    {
        if (!timeStarted)
        {
            timeElapsed = Time.time;
            timeStarted = true;
        }
        float t =+ Time.time - timeElapsed;

        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", Color.Lerp(startColor, endColor, t/(ChargesUntilDestroy*time)));
        _renderer.SetPropertyBlock(_propBlock);
    }
}

 

   

