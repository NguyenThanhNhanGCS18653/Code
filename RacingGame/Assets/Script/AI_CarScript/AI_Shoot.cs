using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletAIPrefab;
    [SerializeField]
    private GameObject shootPointAI;
    [SerializeField]
    private float shootRange;
    [SerializeField]
    private GameObject[] target;
    [SerializeField]
    private float nextFireRate;
    private float fireRate = 1f;
    void Update()
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == null)
                return;
        }

        float distance = Vector3.Distance(target[PlayerPrefs.GetInt("SelectCar")].transform.position, transform.position);
        if (nextFireRate <= Time.time && distance <= shootRange)
        {
            AIShoot();
            nextFireRate = fireRate + Time.time;
        }
    }
    void AIShoot()
    {
        GameObject bulletAI = Instantiate(bulletAIPrefab, shootPointAI.transform.position, shootPointAI.transform.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
