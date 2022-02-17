using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField]
    private int carIndex;

    [SerializeField]
    private GameObject[] cars;

    void Start()
    {
        carIndex = PlayerPrefs.GetInt("SelectCar", 0);

        foreach (GameObject car in cars)
        {
            car.SetActive(false);
        }

        cars[carIndex].SetActive(true);
    }
}
