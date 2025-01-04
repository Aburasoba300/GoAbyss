using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGaugeController : MonoBehaviour
{
    //HP�Q�[�W
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;
    //HP�Q�[�W�̃C���[�W�ϐ�
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;


    //�v���C���[�̃X�N���v�g������ϐ�
    PlayerController script;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerController> ();
        

        HP1 = GameObject.Find("HP1");
        HP2 = GameObject.Find("HP2");
        HP3 = GameObject.Find("HP3");
        HP4 = GameObject.Find("HP4");
        HP5 = GameObject.Find("HP5");

        image1 = HP1.GetComponent<Image>();
        image2 = HP2.GetComponent<Image>();
        image3 = HP3.GetComponent<Image>();
        image4 = HP4.GetComponent<Image>();
        image5 = HP5.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //HP�Q�[�W�̃C���[�W�̔z��
        Image[] Images = new Image[5];
        Images[0] = image1;
        Images[1] = image2;
        Images[2] = image3;
        Images[3] = image4;
        Images[4] = image5;

        //HP�̕ϐ�
        float HP = script.HP;
        int MaxHP = script.MaxHP;
        float HPhalf = HP / 2;

        for (int i = 0; i < Images.Length; i++)
        {
            //HP�������̎�
            if (HP % 2 == 0)
            {
                //�e�z���HP�摜��fillAmount�𑀍�
                if (i + 1 <= HPhalf)
                {
                    Images[i].fillAmount = 1;
                    //Debug.Log("1");
                }

                else if (i + 1 > HPhalf)
                {
                    Images[i].fillAmount = 0;
                    //Debug.Log("0");
                }
            }
            //HP����̎�
            else if (HP % 2 == 1)
            {
                //�e�z���HP�摜��fillAmount�𑀍�
                if (i + 1 <= HPhalf)
                {
                    Images[i].fillAmount = 1;
                    //Debug.Log("2");
                }

                else if (i + 1 == HPhalf + 0.5)
                {
                    Images[i].fillAmount = 0.5f;
                    //Debug.Log("0.5");
                }

                else if(i+1 > HPhalf + 0.5)
                {
                    Images[i].fillAmount = 0;
                }

            }
        }
    }
}
