using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardShootingBlock : MonoBehaviour
{
    public GameObject projectile;
    public float t;
    private bool canShoot;
    public Transform projectileOrigin;
    Transform player;
    [Header("Range variables")]
    public bool overrideSetDistanceVariable;
    public float shootDistance;
    public float projectileLifeTime;

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
        if(shot.GetComponent<Project>().t != projectileLifeTime && projectileLifeTime > 0)
        {
            Debug.Log("Hello");
            shot.GetComponent<Project>().t = projectileLifeTime;
        }
        else
        {
            shot.GetComponent<Project>().t = 2;
        }
        canShoot = false;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }
}
