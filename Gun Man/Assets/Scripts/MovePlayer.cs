using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movePower = 1f;
    public float jumpPower = 1f;
    private int jumplimit = 1;
    private float posx, posy;
    private Animator ani;
    public static bool playerleri=false;//left = true  right = false;
    Rigidbody2D rigid;
    
    Vector3 movement;
    bool isJumping = false;

    //---------------------------------------------------[Override Function]
    //Initialization
    void Start()
    {
        ani = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    //Graphic & Input Updates	

    
    void Update()
    {
        //transform.position += new Vector3(-0.05f, 0, 0);
        if (Input.GetAxisRaw("Vertical")>0&&jumplimit>0)
        {
            isJumping = true;
        }
    }

    //Physics engine Updates
    void FixedUpdate()
    {
        Move();
        Jump();
      // PlayerAndMouse();
    }

    //---------------------------------------------------[Movement Function]

    void Move()
    {
        
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            ani.SetBool("Running", true);
            playerleri = true;
            transform.localScale = new Vector3(-5f, 5f, 5f);
            
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            ani.SetBool("Running", true);
            ani.SetFloat("PosX", 1.0f);
            playerleri = false;
            transform.localScale = new Vector3(5f, 5f, 5f);
            
        }
        else
        {
            ani.SetBool("Running", false);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    
    void Jump()
    {

        if (jumplimit > 0)
        {

            if (!isJumping)
                return;
            ani.SetBool("Jumpping", true);
            //Prevent Velocity amplification.
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            jumplimit--;
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Attach : " + collision.gameObject.layer);
        if (collision.gameObject.layer == 11|| collision.gameObject.layer == 13)
        {

            ani.SetBool("Jumpping", false);
            jumplimit = 1;
        }
    }
    

}