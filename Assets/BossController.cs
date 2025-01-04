using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    int HP = 15;
    int Attack = 5;
    float VelocityX = 10;

    public bool NeedleCheck = false;
    
    //計測用の変数
    private float delta = 0;
    //抽選間隔
    private float span = 1.5f; 

    Rigidbody2D rigid2D;
    public GameObject NeedlePrefab;
    public GameObject Player;
    PlayerController PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //HPが0になったら破壊
        if(this.HP <= 0)
        {
            Destroy(this.gameObject);
            //UIControllerのGameClear関数を呼び出して画面上にGameClearを表記
            GameObject.Find("Canvas").GetComponent<UIController>().GameClear();
        }

        //時間計測
        this.delta += Time.deltaTime;

        //プレイヤーが近づいたら行動開始
        if (Player.transform.position.y - this.transform.position.y <= 3)
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                //行動パターンの抽選
                int num = Random.Range(1, 10);
                if (num <= 5)
                {
                      Needle();

                }

                if (num >= 6)
                {
                      Dash();
                }
                
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Fire")
        {
            Debug.Log(this.HP);
            this.HP -= 2;
            this.rigid2D.velocity = new Vector2(3, 0);
        }

        if(other.gameObject.tag == "Player")
        {
            PlayerScript.HP -= Attack;
            this.rigid2D.velocity = new Vector2(3, 0);
        }
    }

    //とげを飛ばす攻撃
    void Needle()
    {
            NeedleCheck = true;         
    }
    //突進攻撃
    void Dash()
    {
        this.rigid2D.velocity = new Vector2(-VelocityX, 0);           
    }

}
