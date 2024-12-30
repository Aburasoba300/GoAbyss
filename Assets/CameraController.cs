using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Player�̃I�u�W�F�N�g
    private GameObject Player;
    
    //�J�����̍ő�l
    float MaxCameraPosi = 0.2f;
    //�J�����̍ŏ��l
    float MinCameraPosi = -0.1f;
    //�J������y�̍ŏ��l
    float MinCameraPosiY = -30;
    //�J�����̃X�N���[���X�s�[�h
    float CameraScrollSpeed = 50f;
    //���Ԍv���̔���
    bool CountWatch = false;
    //�o�ߎ��Ԃ̃J�E���g
    float TimeCount = 0;
    //�J������������ʒu�̐���
    float LimitCameraDown = 20;

    // Start is called before the first frame update
    void Start()
    {
        //Player�̃I�u�W�F�N�g�̎擾
        this.Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player�̈ʒu�ɍ��킹�ăJ�������ړ�
        if (this.Player.transform.position.x >= MinCameraPosi && this.Player.transform.position.x <= MaxCameraPosi)
        {
            this.transform.position = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y, -20); 
        }

        if(this.Player.transform.position.x < MinCameraPosi)
        {
            this.transform.position = new Vector3(MinCameraPosi, this.Player.transform.position.y, -20);
        }

        if (this.Player.transform.position.x > MaxCameraPosi)
        {
            this.transform.position = new Vector3(MaxCameraPosi, this.Player.transform.position.y, -20);
        }

        

        //�J�����ړ�
        if (Input.GetMouseButton(1) && transform.position.y > MinCameraPosiY)
        {
            OnStart();
            if(CountWatch == true)
            {
                TimeCount += Time.deltaTime;
                this.transform.Translate(0, -CameraScrollSpeed * TimeCount, 0);

                //����������E�l�܂ŗ�����Stop
                if(CameraScrollSpeed * TimeCount >= LimitCameraDown)
                {
                    this.transform.position = new Vector3(transform.position.x, Player.transform.position.y - LimitCameraDown, transform.position.z);
                    
                }
                //�ŉ��w�ł̃J�����ړ��̏���
                if (Player.transform.position.y - LimitCameraDown == MinCameraPosiY)
                {
                    this.transform.position = new Vector3(transform.position.x, MinCameraPosiY, transform.position.z);

                }

            }
            
        }
        else if(Input.GetMouseButtonUp(1))
        {
            Reset();
        }

        
    }
    
    //���Ԍv���J�n
    public void OnStart()
    {
        CountWatch = true;
    }
    //���Ԍv���I��
    public void Reset()
    {
        CountWatch = false;
        TimeCount = 0;
    }
}
