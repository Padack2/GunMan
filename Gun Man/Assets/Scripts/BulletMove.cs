using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMove : MonoBehaviour
{
    public float DestoryPos=10.0f;

    private float BulletSpeed;
    private bool BullArrow = true;
    private Vector2 OriginPos;


    // Start is called before the first frame update
    void Start()
    {
        if (MovePlayer.playerleri == true)
        {
            transform.localScale = new Vector3(-5.0f, 5.0f, 0);
            BullArrow = true;
        }
        else
        {
            transform.localScale = new Vector3(5.0f, 5.0f, 0);
            BullArrow = false;
        }

        OriginPos = new Vector2(transform.position.x, transform.position.y);
    }





    private void Update()
    {
        if(BullArrow == true)
        {
            transform.Translate(Vector2.left * 5.0f * Time.deltaTime);
            
            
        }
        else
        {
            transform.Translate(Vector2.right * 5.0f * Time.deltaTime);
           
        }
        //총알 지우는 건 나중에....
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            //알아서 지워라.
            gameObject.SetActive(false);
        }
    }






}
