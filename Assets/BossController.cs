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
        //HP��0�ɂȂ�����j��
        if(this.HP == 0)
        {
            Destroy(this.gameObject);
        }

        //�v���C���[���߂Â�����s���J�n
        if (Player.transform.position.y - this.transform.position.y <= 3)
        {
            if (MoveCheck == false)
            {

                MoveCheck = true;
                
                //�s���p�^�[���̒��I
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

    //�Ƃ����΂��U��
    void Needle()
    {
        if (MoveCheck == true)
        {
            NeedleCheck = true;
            MoveCheck = false;
        }
    }
    //�ːi�U��
    void Dash()
    {
        if (MoveCheck == true)
        {
            this.rigid2D.velocity = new Vector2(-VelocityX, 0);
            MoveCheck = false;
        }
    }

}
