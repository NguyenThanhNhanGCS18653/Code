using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        if (PlayerController.MyInstance.MyHealth <= 0)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
