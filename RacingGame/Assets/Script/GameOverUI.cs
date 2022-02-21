using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private SceneFader fader;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        fader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        fader.FadeTo(0);
    }
}
