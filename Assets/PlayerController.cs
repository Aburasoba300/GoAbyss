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

    //Player������ϐ�
    GameObject Player;

    //asi������ϐ�
    GameObject asi;
    //asi�̃X�N���v�g������ϐ�
    asibaController script;

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
    }

    // Update is called once per frame
    void Update()
    {
        bool asibool = script.asi;

        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && asibool == true) 
        {
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //����̓����蔻��ɂ��ҋ@���[�V�����ւ̈ڍs
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


        //���ړ�
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

        //���X�g�b�v
        else if(Input.GetKeyUp(KeyCode.A))
        {
            this.animator.SetTrigger("walktrigger");
            this.rigid2D.velocity = new Vector2(0,this.rigid2D.velocity.y);

        }

        //�E�ړ�
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
        

        //�E�X�g�b�v
        else if (Input.GetKeyUp(KeyCode.D))
        {
            this.animator.SetTrigger("walktrigger");
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
    }

    //�󒆂ő���u���b�N�ɏՓ˂����ۂɓ������~�܂�Ȃ��悤�ɂ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "asiba")
        {
            Debug.Log("AshibaDayo");
            this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);
        }
    }

}
