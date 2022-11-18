using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Move : MonoBehaviour
{
    public int MoveSpeed=0;
    public int MoveSpeedUp=0;

    public bool isClimb=false;
    public Rigidbody2D rb;
        //public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        rb = new Rigidbody2D();
        //   g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var move = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * MoveSpeed;
       

    }

    public void FixedUpdate()
    {
        if (isClimb == true)
        {
            
            var move1 = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, move1, 0) * Time.deltaTime * MoveSpeedUp;
        }
     
         
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.CompareTag("Finish"))
        {
            isClimb = true;
          //  rb.gravityScale = 0;
           
          //  g.SetActive(true);
           // FixedUpdate();
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isClimb = false;
    }
}
