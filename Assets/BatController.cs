using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    int HP = 2;
    int Attack = 2;

    float VelocityX = 3;
    Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rigid2D.velocity = new Vector2(VelocityX, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TurnPoint")
        {
            this.rigid2D.velocity = new Vector2(-VelocityX, 0);
            this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
