using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    float timeLeft=10f;

    void Update()
    {
        if(!transform.Find("Crystal").gameObject.activeSelf)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 10f;
                transform.Find("Crystal").gameObject.SetActive(true);
            }
        }
    }
}
