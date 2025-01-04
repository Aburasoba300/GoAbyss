using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    int HP = 5;
    int Attack = 4;

    float VelocityX = 3;
    Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        this.rigid2D.velocity = new Vector2(VelocityX, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.HP == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TurnPoint")
        {
            //Debug.Log("A");
            this.rigid2D.velocity = -this.rigid2D.velocity;
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Debug.Log(this.HP);
            this.HP -= 1;
            this.rigid2D.velocity = -this.rigid2D.velocity;
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }

        if (other.gameObject.tag == "Player")
        {
            this.rigid2D.velocity = -this.rigid2D.velocity;
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}