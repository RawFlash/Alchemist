using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    public AnimationClip atack;
    public AnimationClip walk;
    public AnimationClip taunt;

    public float speed;
    public float reversTime;

    float leftTimeWalk;
    float leftTimeStop;




    // Start is called before the first frame update
    void Start()
    {
        leftTimeWalk = reversTime;
        gameObject.GetComponent<Animation>().clip = walk;
        gameObject.GetComponent<Animation>().AddClip(walk, "walk");
        gameObject.GetComponent<Animation>().Play();

        leftTimeStop = 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("walk: " + leftTimeWalk.ToString() + "stop: " + leftTimeStop.ToString());
        if(leftTimeWalk>0)
        {
            leftTimeWalk -= Time.deltaTime;
            transform.position += transform.forward * speed;
            leftTimeStop = 2;
        }
        else
        {
            if(leftTimeStop<0)
            {
                //анимация поворота и ходьбы обратно
                transform.Rotate(new Vector3(0, 1, 0), 180);
                leftTimeWalk = reversTime;
                gameObject.GetComponent<Animation>().clip = walk;
                gameObject.GetComponent<Animation>().AddClip(walk, "walk");
                gameObject.GetComponent<Animation>().Play();
            }
            if(leftTimeStop==2)
            {
                //анимация остановки и понтования
                gameObject.GetComponent<Animation>().clip = taunt;
                gameObject.GetComponent<Animation>().AddClip(taunt, "idle");
                gameObject.GetComponent<Animation>().Play();
            }
            leftTimeStop -= Time.deltaTime;
        }
        
    }
}
