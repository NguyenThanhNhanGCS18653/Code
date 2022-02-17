using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;
    private void Start()
    {
        int levelLoad = PlayerPrefs.GetInt("levelLoad", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > levelLoad)
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void SelectLv(int index)
    {
        SceneManager.LoadScene(index);
    }
}
