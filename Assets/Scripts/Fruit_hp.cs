using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit_hp : MonoBehaviour
{
    public float hp;

    public GameObject f1;
    public Move player;
  
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
       
        Damage();
    }

    void Damage()
    {
       // if(Input.)
    
       {
         //  hp[0] -= player.takeDamage;
          if (hp <= 0)
           {
              // f1.SetActive(false);
                 Destroy(f1);
                player.num++;
           }
          
       }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            hp -= 5;
          
        }
    }

  
}
