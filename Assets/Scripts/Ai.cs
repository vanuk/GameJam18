using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public float speed = 5;
   public bool isFase = true;
    public Transform[] points;

    public int i;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.fixedDeltaTime);
        if(Vector2.Distance(transform.position,points[i].position)<0.2f)
        {
            if (i > 0)
            {
                i = 0;
            }
            else
            {

                i = 1;
            }
        }

        if (i == 0 && isFase)
        {
            Flip();
        }
        if(i == 1 && !isFase)
        {
            Flip();
        }
    }
    void Flip()
    {
       isFase = !isFase;
        transform.Rotate(0,180,0);
        
       
    }
}
