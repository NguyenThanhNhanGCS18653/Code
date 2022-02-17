using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip coin, engineSound, brake;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        coin = Resources.Load<AudioClip>("Coin");
        engineSound = Resources.Load<AudioClip>("Engine");
        brake = Resources.Load<AudioClip>("Brake");
    }


    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case ("coin"):
                audioSource.clip = coin;
                audioSource.PlayOneShot(coin, 0.6f);
                break;

            case ("engine"):
                audioSource.clip = engineSound;
                audioSource.PlayOneShot(engineSound, .6f);
                break;

            case ("brake"):
                audioSource.clip = brake;
                audioSource.PlayOneShot(brake, 1f);
                break;
        }
    }
}
