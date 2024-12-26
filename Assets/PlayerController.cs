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

    //asiが入る変数
    GameObject asi;
    //asiのスクリプトが入る変数
    asibaController script;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();

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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            this.animator.SetTrigger("jumptrigger");
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //足場の当たり判定による待機モーションへの移行
        if(asibool == true)
        {
            Debug.Log("taiki");
            this.animator.SetTrigger("taikitrigger");
        }

        //左移動
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

        //右移動
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

}
