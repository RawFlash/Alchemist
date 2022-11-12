using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRandomObjectRotation : MonoBehaviour
{
    public List<GameObject> gameObjects;

    GameObject gameObjectNow;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        gameObjectNow = Instantiate(gameObjects[rnd.Next(gameObjects.Count)], gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObjectNow.transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
    }
}
