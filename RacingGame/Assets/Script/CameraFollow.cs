using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Camera Follow Code For Newbie
    //[SerializeField]
    //private Transform car;

    //private Vector3 carCamera;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    carCamera = car.transform.position - transform.position;
    //}
    //private void Update()
    //{
    //    transform.position = (car.transform.position - car.transform.rotation * carCamera);

    //    transform.LookAt(car);
    //}
    #endregion
    #region Camera Follow Code For Pro
    [SerializeField]
    private Transform[] target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedRotate;

    [SerializeField]
    private int carIndex;

    void Start()
    {
        carIndex = PlayerPrefs.GetInt("SelectCar", 0);

        foreach (Transform car in target)
        {
            car.gameObject.SetActive(false);
        }

        target[carIndex].gameObject.SetActive(true);
    }
    private void Update()
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i] == null)
                return;
        }
    }
    private void FixedUpdate()
    {
        HandTranslation();
        HandRotation();
    }

    private void HandRotation()
    {
        Vector3 dir = target[carIndex].position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speedRotate * Time.deltaTime);
    }

    private void HandTranslation()
    {
        Vector3 targetPosition = target[carIndex].TransformPoint(offset);
        transform.position = Vector3.Slerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    #endregion
}
