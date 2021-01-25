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
    Transform player;
    [Header("Range variables")]
    public bool overrideSetDistanceVariable;
    public float shootDistance;

    private void Start()
    {
        canShoot = true;
        player = GameObject.Find("Player Holder").transform;
        if(overrideSetDistanceVariable == false)
        {
            shootDistance = 20f;
        }
    }
    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < shootDistance && canShoot == true)
        {
            StartCoroutine(ShootProjectile());
        }
        Debug.DrawLine(projectileOrigin.position, projectileOrigin.forward * shootDistance, Color.blue);
    }
    IEnumerator ShootProjectile()
    {
        StopCoroutine(ShootProjectile());
        GameObject shot = GameObject.Instantiate(projectile, projectileOrigin.position, this.transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
}
