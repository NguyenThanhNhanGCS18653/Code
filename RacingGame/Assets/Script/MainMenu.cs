using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneFader fader;

    public void Play()
    {
        fader.FadeTo(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
