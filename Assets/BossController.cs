using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    int HP = 15;
    int Attack = 5;
    float VelocityX = 5;

    public bool NeedleCheck = false;
    bool MoveCheck = false;
    float MoveRate = 1;

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
        if(this.HP == 0)
        {
            Destroy(this.gameObject);
        }

        //プレイヤーが近づいたら行動開始
        if (Player.transform.position.y - this.transform.position.y <= 3)
        {
            if (MoveCheck == false)
            {

                MoveCheck = true;
                
                //行動パターンの抽選
                int num = Random.Range(1, 10);
                if (num <= 5 )
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
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Fire")
        {
            this.rigid2D.velocity = new Vector2(3,0);
        
        }

        if(other.gameObject.tag == "Fire")
        {
            this.HP -= 2;
        }

        if(other.gameObject.tag == "Player")
        {
            PlayerScript.HP -= Attack;
        }
    }

    //とげを飛ばす攻撃
    void Needle()
    {
        if (MoveCheck == true)
        {
            NeedleCheck = true;
            MoveCheck = false;
        }
    }
    //突進攻撃
    void Dash()
    {
        if (MoveCheck == true)
        {
            this.rigid2D.velocity = new Vector2(-VelocityX, 0);
            MoveCheck = false;
        }
    }

}
