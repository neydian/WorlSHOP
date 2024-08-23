using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float inputX;
    public bool inputJump;
    

    public float speed;    
    public float forceJump;

    public bool inGround;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        JumpLogic();
        Flip();
        Animations();
    }

    private void FixedUpdate()
    {
	    MoveLogic();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            inGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            inGround = false;
        }
    }

    public void Animations()
    {
        anim.SetFloat("Horizontal", rb.velocity.x);
    }

    public void Inputs()
    {
        inputX = Input.GetAxisRaw("Horizontal");
	    inputJump = Input.GetKeyDown(KeyCode.Space);
    }

    public void JumpLogic()
    {
        if(inputJump == true && inGround == true)
	    {
	    	rb.velocity = new Vector2(rb.velocity.x, forceJump);
	    }
    }

    public void MoveLogic()
    {
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
    }

    public void Flip()
    {
        if (inputX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (inputX > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

}
