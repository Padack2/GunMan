using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float movePower = 1f;
    Vector2 moveVelocity = Vector2.zero;
    int movementFlag = 0; //0:idle 1:left 2:right
    private bool move = true;//true = do move false = don't move
    public GameObject target;//house
    // Start is called before the first frame update
    void Start()
    {
        if (target.transform.position.x < transform.position.x)
            movementFlag = 1;
        else if(target.transform.position.x > transform.position.x)
            movementFlag = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (move == true)
        {
            Vector3 moveVelocity = Vector3.zero;
            if (movementFlag == 1)
            {
                moveVelocity = Vector2.left;
                transform.localScale = new Vector2(4, 4);
            }
            else if (movementFlag == 2)
            {
                moveVelocity = Vector2.right;
                transform.localScale = new Vector2(-4, 4);
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="House")
        {
            move = false;
        }
    }

   
}
