    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardDisappearingBlock : MonoBehaviour
{
    //Variabler som används när blocket förstörs
    public float time;
    public float ChargesUntilDestroy;
    private bool canReduceCharge;
    bool startDestruction;

    //Variabler som används när objektet ändrar färg
    bool changeColor;
    public float speed;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
  
    //Variabler för minikub som skapas efter explosion
    float cubeSize = 0.2f;
    int cubesInRow = 5;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public float explosionRadius;
    public float explosionForce;
    public float explosionUpward;
    public GameObject particleHolder;
    
    //Sätter variabler och komponenter lika med X
    void Awake()
    {
        canReduceCharge = true;
        startDestruction = false;
        _propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        //_renderer.material = new Material(Shader.Find("Standard"));
        //_renderer.material.color = startColor;
    }

    //Sätter variabler och komponenter lika med X
    void Start()
    {
        startDestruction = false;
        Debug.Log(cubesInRow);
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
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
            Debug.Log(startDestruction);
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
            Debug.Log(ChargesUntilDestroy);
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
                Debug.Log(explosionForce);
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
        
    }
   
    //Ändrar färg över tid när ChangeColor boolen är true
    void ChangeColor()
    {
        float t = Time.time / (ChargesUntilDestroy * time);
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("_Color", Color.Lerp(startColor, endColor, t));
        _renderer.SetPropertyBlock(_propBlock);
       // _renderer.material.color = Color.Lerp(startColor, endColor, t);
    }
 
}

 

   

