using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Player�̃I�u�W�F�N�g
    private GameObject Player;
    //Player�Ƃ̃J�����̃J�����̋���
    //private float difference;

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
        this.transform.position = 
            
            new Vector3(this.Player.transform.position.x,this.Player.transform.position.y,-20);
    }
}
