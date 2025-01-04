using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    float jumpVelocity = 5;
    float VelocityX = 5;
    public int HP = 10;
    public int MaxHP = 10;
    public int RakkaDamage = 1;
    public int RakkaDamage1 = 5;
    public int RakkaDamage2 = 10;

    //Playerが入る変数
    GameObject Player;

    //asiが入る変数
    GameObject asi;
    //Fireが入る変数
    GameObject fire;
    //asiのスクリプトが入る変数
    asibaController script;
    //FireGeneratorのスクリプトが入る変数
    FireGenerator Fscript;

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

        fire = GameObject.Find("FireGenerator");
        Fscript = fire.GetComponent<FireGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool asibool = script.asi;
        bool Firebool = Fscript.FireCheck;

        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && asibool == true) 
        {
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //足場の当たり判定による待機モーションへの移行
        if(asibool == false)
        {
            //Debug.Log("jump");
            this.animator.SetTrigger("jumptrigger");
        }
        else if (asibool == true)
        {
            //Debug.Log("taiki");
            this.animator.SetTrigger("taikitrigger");
        }


        //左移動
        if (Input.GetKey(KeyCode.A))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(-this.VelocityX, this.rigid2D.velocity.y);
    

            //if (Input.GetKeyDown(KeyCode.Space) && asibool == true)
            //{
                //this.animator.SetTrigger("jumptrigger");
                //this.rigid2D.velocity = new Vector2(-this.VelocityX, this.jumpVelocity);

            //}

        }

        //左ストップ
        else if(Input.GetKeyUp(KeyCode.A))
        {
            
            this.rigid2D.velocity = new Vector2(0,this.rigid2D.velocity.y);

        }

        //右移動
        if (Input.GetKey(KeyCode.D))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(this.VelocityX, this.rigid2D.velocity.y);
            

            //if (Input.GetKeyDown(KeyCode.Space) && asibool == true)
            //{
               // this.animator.SetTrigger("jumptrigger");
               // this.rigid2D.velocity = new Vector2(this.VelocityX, this.jumpVelocity);
            //}

        }
        

        //右ストップ
        else if (Input.GetKeyUp(KeyCode.D))
        {
            
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

        //攻撃モーション
        if(Input.GetMouseButtonDown(0) && Firebool == false)
        {
            this.animator.SetTrigger("attacktrigger");
        }

        //HPが0になったらプレイヤーオブジェクトを破壊
        if(HP <= 0)
        {
            Destroy(Player);
        }
    }

    //空中で足場ブロックに衝突した際に動きが止まらないようにする
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "asiba")
        {
            //Debug.Log("AshibaDayo");
            this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);
        }
    }

    void FixedUpdate()
    {
        bool asibool = script.asi;

        if (asibool == true)
        {
            //落下ダメージの検出
            if (-20 < rigid2D.velocity.y && rigid2D.velocity.y < -10)
            {
                this.animator.SetTrigger("damagetrigger");
                HP -= RakkaDamage;
                Debug.Log(HP);
            }

            else if (-30 < rigid2D.velocity.y && rigid2D.velocity.y <= -20)
            {
                this.animator.SetTrigger("damagetrigger");
                HP -= RakkaDamage1;
                Debug.Log(HP);
            }

            else if (rigid2D.velocity.y <= -30)
            {
                this.animator.SetTrigger("damagetrigger");
                HP -= RakkaDamage2;
                Debug.Log(HP);
            }
            
        }

    }

}
