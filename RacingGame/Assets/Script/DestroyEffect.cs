using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private GameObject bottle;

    // Update is called once per frame
    void Update()
    {
        if (bottle == null)
            Destroy(effect);
    }
}
