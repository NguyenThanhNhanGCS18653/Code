using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private int carIndex;

    [SerializeField]
    private GameObject[] carModels;

    [SerializeField]
    private Button buyBtn;

    [SerializeField]
    private Text coinTxt;

    [SerializeField]
    private CarBluePrint[] cars;
    void Start()
    {
        foreach (CarBluePrint car in cars)
        {
            if (car.MyPrice == 0)
            {
                car.MyIsUnlocked = true;
            }
            else
            {
                car.MyIsUnlocked = PlayerPrefs.GetInt(car.MyName, 0) == 0 ? false : true;
            }
        }

        carIndex = PlayerPrefs.GetInt("SelectCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);
        }

        carModels[carIndex].SetActive(true);
    }

    void Update()
    {
        UpdateUI();

        coinTxt.text = "COINS: " + PlayerPrefs.GetInt("NumberOfCoins").ToString();
    }

    public void NextButton()
    {
        carModels[carIndex].SetActive(false);

        carIndex++;

        if (carIndex == carModels.Length)
        {
            carIndex = 0;
        }

        carModels[carIndex].SetActive(true);
        CarBluePrint c = cars[carIndex];
        if (!c.MyIsUnlocked)
            return;

        PlayerPrefs.SetInt("SelectCar", carIndex);
    }

    public void PreviousButton()
    {
        carModels[carIndex].SetActive(false);

        carIndex--;

        if (carIndex == -1)
        {
            carIndex = carModels.Length - 1;
        }

        carModels[carIndex].SetActive(true);

        CarBluePrint c = cars[carIndex];
        if (!c.MyIsUnlocked)
            return;

        PlayerPrefs.SetInt("SelectCar", carIndex);
    }
    public void PlayyButton()
    {
        SceneManager.LoadScene(2);
    }

    public void UnlockCar()
    {
        CarBluePrint c = cars[carIndex];
        PlayerPrefs.SetInt(c.MyName, 1);
        PlayerPrefs.SetInt("SelectCar", carIndex);
        c.MyIsUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins") - c.MyPrice);
    }

    private void UpdateUI()
    {
        CarBluePrint c = cars[carIndex];
        if (c.MyIsUnlocked)
        {
            buyBtn.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<Text>().text = "Buy - " + c.MyPrice;
            if (PlayerPrefs.GetInt("NumberOfCoins") >= c.MyPrice)
            {
                buyBtn.interactable = true;
            }
            else
            {
                buyBtn.interactable = false;
            }
        }
    }
}
