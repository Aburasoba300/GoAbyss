using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //�Q�[���I�[�o�[�e�L�X�g
    private GameObject GameOverText;
    //�N���A�e�L�X�g
    private GameObject GameClearText;

    //�Q�[���I�[�o�[�̔���
    public bool isGameOver = false;
    //�Q�[���N���A�̔���
    public bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[���r���[����I�u�W�F�N�g�擾
        this.GameOverText = GameObject.Find("GameOver");
        this.GameClearText = GameObject.Find("Clear");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == true || this.isGameClear == true)
        {
            //Enter���N���b�N���ꂽ��V�[�������[�h
            if(Input.GetKey(KeyCode.Return))
            {
                //SampleScene��ǂݍ���
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        //�Q�[���I�[�o�[�ŉ�ʏ��GameOver��\��
        this.GameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }

    public void GameClear()
    {
        //Boss���j���ɉ�ʏ��GameClear��\��
        this.GameClearText.GetComponent<Text>().text = "Game Clear!!";
        this.isGameClear = true;
    }
}
