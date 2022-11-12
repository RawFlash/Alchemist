using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    float timeLeft;
    public void Collection()
    {
        Debug.Log("Кристал добыт");
        gameObject.SetActive(false);
    }

}
