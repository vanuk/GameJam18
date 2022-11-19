using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Move : MonoBehaviour
{
    public int MoveSpeed=0;
    public int MoveSpeedUp=0;

    public GameObject dialog;

    public bool isClimb=false;
   // public Rigidbody2D rb;

public int takeDamage=5;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private float move;

  
    private bool isFase = true;
   
    
    public float jumpingPower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    public Fruit_hp d;

    public Fruit_hp d1;
    
    public Fruit_hp d2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * MoveSpeed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
          
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

       
        Flip();

      
    }

    void Flip()
    {
        if (isFase && move < 0f || !isFase && move > 0f)
        {
            isFase = !isFase;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

 
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
      
        //takeDamage=5;
        foreach (Collider2D enemy  in hitEnemy )
        {
            
                d.hp[0] -= 5;
                if (d.hp[0] <= 0)
                {
                    Destroy(d.f1[0]);
                }
               

            Debug.Log("we hit");
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
            return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
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
      
        }

        if (col.CompareTag("Dialogs"))
        {
            dialog.SetActive(true);
        }
        if (col.CompareTag("enemy"))
        {
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isClimb = false;
        dialog.SetActive(false);
    }
}
