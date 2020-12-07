using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardShootingBlock : MonoBehaviour
{
    public GameObject projectile;
    GameObject player;
    Transform playerPos;
    public float t;
    public float shootForce;
    bool canShoot;
    public float maxDistance;
    private static float distanceAB;
    public Transform projectileOrigin;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canShoot = true;
    }
    private void FixedUpdate()
    {
        //distanceAB = Vector3.Distance(transform.position, playerPos.position);
    }

    private void Update()
    {
        playerPos = player.transform;
        //distanceBA = Vector3.Distance(playerPos.position, transform.position);
        //Debug.Log(distanceBA);
        if (canShoot == true)
        {
            StartCoroutine(ShootProjectile());
        }

        DrawRaycast();
    }
    IEnumerator ShootProjectile()
    {
        StopCoroutine(ShootProjectile());
        GameObject shot = GameObject.Instantiate(projectile, projectileOrigin.position, this.transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(t);
        canShoot = true;
    }

    private void DrawRaycast()
    {
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        Debug.DrawLine(transform.position, player.transform.position, Color.green, maxDistance);

    }
}
