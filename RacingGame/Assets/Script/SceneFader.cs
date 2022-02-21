using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField]
    private Image blackBG;

    [SerializeField]
    private AnimationCurve animationCurve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            blackBG.color = new Color(0, 0, 0, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(int scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            blackBG.color = new Color(0, 0, 0, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
