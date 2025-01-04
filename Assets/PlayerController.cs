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

    //Player������ϐ�
    GameObject Player;

    //asi������ϐ�
    GameObject asi;
    //Fire������ϐ�
    GameObject fire;
    //asi�̃X�N���v�g������ϐ�
    asibaController script;
    //FireGenerator�̃X�N���v�g������ϐ�
    FireGenerator Fscript;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();

        //Player�I�u�W�F�N�g�̎擾
        Player = GameObject.Find("Player");

        //asi�I�u�W�F�N�g�̎擾
        asi = GameObject.Find("asi");
        //asi�̒��̃X�N���v�g�̎擾
        script = asi.GetComponent<asibaController>();

        fire = GameObject.Find("FireGenerator");
        Fscript = fire.GetComponent<FireGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool asibool = script.asi;
        bool Firebool = Fscript.FireCheck;

        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && asibool == true) 
        {
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //����̓����蔻��ɂ��ҋ@���[�V�����ւ̈ڍs
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


        //���ړ�
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

        //���X�g�b�v
        else if(Input.GetKeyUp(KeyCode.A))
        {
            
            this.rigid2D.velocity = new Vector2(0,this.rigid2D.velocity.y);

        }

        //�E�ړ�
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
        

        //�E�X�g�b�v
        else if (Input.GetKeyUp(KeyCode.D))
        {
            
            this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);

        }

        //�����]����
        if (Input.GetKey(KeyCode.A) && Player.transform.localScale.x < 0)
        {
            this.Player.transform.localScale = new Vector3(-this.Player.transform.localScale.x, this.Player.transform.localScale.y, 0);
        }
        //�����]���E
        if (Input.GetKey(KeyCode.D) && Player.transform.localScale.x > 0)
        {
            this.Player.transform.localScale = new Vector3(-this.Player.transform.localScale.x, this.Player.transform.localScale.y, 0);
        }

        //�U�����[�V����
        if(Input.GetMouseButtonDown(0) && Firebool == false)
        {
            this.animator.SetTrigger("attacktrigger");
        }

        //HP��0�ɂȂ�����v���C���[�I�u�W�F�N�g��j��
        if(HP <= 0)
        {
            Destroy(Player);
        }
    }

    //�󒆂ő���u���b�N�ɏՓ˂����ۂɓ������~�܂�Ȃ��悤�ɂ���
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
            //�����_���[�W�̌��o
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
