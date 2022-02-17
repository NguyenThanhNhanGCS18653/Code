using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the Player
    /// </summary>
    private static PlayerController instance;
    public static PlayerController MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }

    [SerializeField]
    private float health;
    public float MyHealth 
    {
        get
        {
            return health;
        }
    }

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Text statTxt;
    private float maxHealth = 10f;


    [SerializeField]
    private float energy;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private Image energyBar;
    [SerializeField]
    private Text statTxt2;
    private float maxEnergy = 10f;

    [SerializeField]
    private int coin;
    public int MyCoin 
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;

        }
    }

    [SerializeField]
    private Text coinTxt;
    
    private string tagCoin = "Coin";
    private string tagEnergyPotion = "EnergyPotion";
    private string tagHealthPotion = "HealthPotion";
    private string tagWinLevel = "Win";
    private string tagWinLevel2 = "WinLv2";

    [SerializeField]
    private PlayerMotor motor;

    [SerializeField]
    private int unlockLevel = 2;
    [SerializeField]
    private int unlockLevel3 = 3;

    [SerializeField]
    private Sounds sound;
    private void Awake()
    {
        coin = 100;
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = maxHealth;

        energy = maxEnergy;
        energyBar.fillAmount = maxEnergy;

        
        coinTxt.text = "COINS: " + PlayerPrefs.GetInt("NumberOfCoins").ToString();
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            health = 0f;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            health -= 2f;
            energy -= 2f;
        }
        float currentFillHealth= health / maxHealth;
        if (currentFillHealth != healthBar.fillAmount)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentFillHealth, Time.deltaTime * lerpSpeed);
        }
        statTxt.text = health.ToString();


        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if (energy <= 0f)
        {
            energy = 0f;
        }
        float currentFillEnergy = energy / maxEnergy;
        if (currentFillEnergy != energyBar.fillAmount)
        {
            energyBar.fillAmount = Mathf.Lerp(energyBar.fillAmount, currentFillEnergy, Time.deltaTime * lerpSpeed);
        }
        statTxt2.text = energy.ToString();
        
        PlayerPrefs.SetInt("NumberOfCoins", coin);

        UseEnergy();
    }

    void UseEnergy()
    {
        if (Input.GetKeyDown(KeyCode.E) && energy >= 5f)
        {
            energy -= 5f;
            StartCoroutine(UpdateMotorForce());
        }
    }
    IEnumerator UpdateMotorForce()
    {
        motor.MyMotorForce += 200f;
        yield return new WaitForSeconds(2f);
        motor.MyMotorForce -= 200f;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagCoin)
        {
            coin += 2;
            sound.PlaySound("coin");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == tagEnergyPotion)
        {
            energy += 2.5f;
            sound.PlaySound("coin");
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == tagHealthPotion)
        {
            health += 2;
            sound.PlaySound("coin");
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == tagWinLevel)
        {
            SceneManager.LoadScene(4);
            PlayerPrefs.SetInt("levelLoad", unlockLevel);
        }

        if (other.gameObject.tag == tagWinLevel2)
        {
            SceneManager.LoadScene(5);
            PlayerPrefs.SetInt("levelLoad", unlockLevel3);
        }
    }
}
