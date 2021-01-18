using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardShootingBlock : MonoBehaviour
{
    public GameObject projectile;
    public float t;
    private bool canShoot;
    public Transform projectileOrigin;
    public BoxCollider trigCol;
    [Header("Range variables")]
    public bool overrideDistanceVariable;
    public float shootDistance;

    private void Start()
    {
        if(overrideDistanceVariable == false)
        {
            trigCol.size = new Vector3(shootDistance, shootDistance, shootDistance);
        }
    }
    private void Update()
    {
        if (canShoot == true)
        {
            StartCoroutine(ShootProjectile());
        }
    }
    IEnumerator ShootProjectile()
    {
        StopCoroutine(ShootProjectile());
        GameObject shot = GameObject.Instantiate(projectile, projectileOrigin.position, this.transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canShoot = false;
        }
    }
}
