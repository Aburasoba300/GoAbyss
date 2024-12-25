using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    private float dump = 0.8f;
    float jumpVelocity = 5;
    float VelocityX = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ÉWÉÉÉìÉvÇ∑ÇÈ
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            this.animator.SetTrigger("jumptrigger");
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }

        //ç∂à⁄ìÆ
        if(Input.GetKey(KeyCode.A))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(-this.VelocityX, this.rigid2D.velocity.y);
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.animator.SetTrigger("jumptrigger");
                this.rigid2D.velocity = new Vector2(-this.VelocityX, this.jumpVelocity);

            }

        }

        //âEà⁄ìÆ
        if (Input.GetKey(KeyCode.D))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(this.VelocityX, this.rigid2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.animator.SetTrigger("jumptrigger");
                this.rigid2D.velocity = new Vector2(this.VelocityX, this.jumpVelocity);

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asiba")
        {
            this.animator.SetTrigger("taikitrigger");

        }

    }
}
