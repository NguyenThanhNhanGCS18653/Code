using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    private Transform[] targets;

    private void Update()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] == null)
                return;
        }
    }

    private void LateUpdate()
    {
        Vector3 newPos = targets[PlayerPrefs.GetInt("SelectCar")].position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90f, targets[PlayerPrefs.GetInt("SelectCar")].eulerAngles.y, 0f);
    }
}
