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

    //Playerが入る変数
    GameObject Player;

    //asiが入る変数
    GameObject asi;
    //asiのスクリプトが入る変数
    asibaController script;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();

        //Playerオブジェクトの取得
        Player = GameObject.Find("Player");

        //asiオブジェクトの取得
        asi = GameObject.Find("asi");
        //asiの中のスクリプトの取得
        script = asi.GetComponent<asibaController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool asibool = script.asi;

        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && asibool == true) 
        {
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //足場の当たり判定による待機モーションへの移行
        if(asibool == false)
        {
            Debug.Log("jump");
            this.animator.SetTrigger("jumptrigger");
        }
        else if (asibool == true)
        {
            Debug.Log("taiki");
            this.animator.SetTrigger("taikitrigger");
        }


        //左移動
        if (Input.GetKey(KeyCode.A))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(-this.VelocityX, this.rigid2D.velocity.y);
    

            if (Input.GetKeyDown(KeyCode.Space) && asibool == true)
            {
                this.animator.SetTrigger("jumptrigger");
                this.rigid2D.velocity = new Vector2(-this.VelocityX, this.jumpVelocity);

            }

        }

        //左ストップ
        else if(Input.GetKeyUp(KeyCode.A))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(0,this.rigid2D.velocity.y);

        }

        //右移動
        if (Input.GetKey(KeyCode.D))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(this.VelocityX, this.rigid2D.velocity.y);
            

            if (Input.GetKeyDown(KeyCode.Space) && asibool == true)
            {
                this.animator.SetTrigger("jumptrigger");
                this.rigid2D.velocity = new Vector2(this.VelocityX, this.jumpVelocity);
            }

        }
        

        //右ストップ
        else if (Input.GetKeyUp(KeyCode.D))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);

        }

        //方向転換左
        if (Input.GetKey(KeyCode.A) && Player.transform.localScale.x < 0)
        {
            this.Player.transform.localScale = new Vector3(-this.Player.transform.localScale.x, this.Player.transform.localScale.y, 0);
        }
        //方向転換右
        if (Input.GetKey(KeyCode.D) && Player.transform.localScale.x > 0)
        {
            this.Player.transform.localScale = new Vector3(-this.Player.transform.localScale.x, this.Player.transform.localScale.y, 0);
        }
    }

    //空中で足場ブロックに衝突した際に動きが止まらないようにする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "asiba")
        {
            Debug.Log("AshibaDayo");
            this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);
        }
    }

}
