    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardDisappearingBlock : MonoBehaviour
{
    public float time;
    public float ChargesUntilDestroy;
    private bool canReduceCharge;
    bool startDestruction;

    bool changeColor;
    public float speed;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    Renderer renderer;
    bool createMaterial;


    
    float cubeSize = 0.2f;
    int cubesInRow = 5;
   float cubesPivotDistance;
    Vector3 cubesPivot;
    public float explosionRadius;
    public float explosionForce;
    public float explosionUpward;
    public GameObject particleHolder;

  
    
    void Awake()
    {
        canReduceCharge = true;
        startDestruction = false;
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;
    }

    void Start()
    {
        createMaterial = true;
        startDestruction = false;
        Debug.Log(cubesInRow);
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startDestruction = true;
        }
    }

    void destroyBlock()
    {
            Debug.Log(startDestruction);
            StartCoroutine(startToDestroy());
            changeColor = true;
    }

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
   
    void ChangeColor()
    {
        if(createMaterial == true)
        {
            renderer.material = new Material(Shader.Find("Standard"));
            createMaterial = true;
        }
        float t = Time.time / (ChargesUntilDestroy * time);
        renderer.material.color = Color.Lerp(startColor, endColor, t);
      ///////
    }
  /*  void EmissionColor()
    {
        float emissionTime = 0.8f;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        float t = Time.time / emissionTime;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(endColor, startColor, emissionTime)); 
        if(t > emissionTime)
        {
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }

    }*/
}

 

   

