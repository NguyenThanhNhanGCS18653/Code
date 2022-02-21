using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float timeExist;

    [SerializeField]
    private float damage;

    [SerializeField]
    private GameObject smallExlosion;
    public float MyBulletDamage 
    {
        get
        {
            return damage;
        }
    }

    private void Update()
    {
        timeExist -= Time.deltaTime;
        if (timeExist <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AI_Car aI_Car = other.GetComponent<AI_Car>();
        if (aI_Car != null)
        {
            aI_Car.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "bulletAI")
        {
            Destroy(gameObject);
            Instantiate(smallExlosion, transform.position, transform.rotation);
        }
    }
}
