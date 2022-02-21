using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    [SerializeField]
    private float damage;
    
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject smallExplosionPrefab;


    private float timeExist = .75f;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timeExist -= Time.deltaTime;
        if (timeExist <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 dir = (target.transform.position - transform.position).normalized;
        rb.velocity = new Vector3(dir.x * speed, 0, dir.z * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ApplyDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Instantiate(smallExplosionPrefab, transform.position, transform.rotation);
        }
    }
}
