using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    int HP = 15;
    int Attack = 5;
    float VelocityX = 10;

    public bool NeedleCheck = false;
    
    //�v���p�̕ϐ�
    private float delta = 0;
    //���I�Ԋu
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
        //HP��0�ɂȂ�����j��
        if(this.HP <= 0)
        {
            Destroy(this.gameObject);
            //UIController��GameClear�֐����Ăяo���ĉ�ʏ��GameClear��\�L
            GameObject.Find("Canvas").GetComponent<UIController>().GameClear();
        }

        //���Ԍv��
        this.delta += Time.deltaTime;

        //�v���C���[���߂Â�����s���J�n
        if (Player.transform.position.y - this.transform.position.y <= 3)
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                //�s���p�^�[���̒��I
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

    //�Ƃ����΂��U��
    void Needle()
    {
            NeedleCheck = true;         
    }
    //�ːi�U��
    void Dash()
    {
        this.rigid2D.velocity = new Vector2(-VelocityX, 0);           
    }

}
