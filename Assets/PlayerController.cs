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

    //asi������ϐ�
    GameObject asi;
    //asi�̃X�N���v�g������ϐ�
    asibaController script;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();

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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            this.animator.SetTrigger("jumptrigger");
            this.rigid2D.velocity = new Vector2(0,this.jumpVelocity);
        
        }
        //����̓����蔻��ɂ��ҋ@���[�V�����ւ̈ڍs
        if(asibool == true)
        {
            Debug.Log("taiki");
            this.animator.SetTrigger("taikitrigger");
        }

        //���ړ�
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

        //�E�ړ�
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
