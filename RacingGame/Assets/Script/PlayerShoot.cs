using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float nextFirerate;
    private float fireRate = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (nextFirerate < Time.time)
            {
                Shoot();
                nextFirerate = fireRate + Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}
