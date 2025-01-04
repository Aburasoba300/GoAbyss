using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerator : MonoBehaviour
{
    public GameObject NeedlePrefab;
    GameObject Boss;
    BossController BossScript;
    //�v���p�̕ϐ�
    private float delta = 0;
    //���I�Ԋu
    private float span = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.Find("Boss");
        BossScript = Boss.GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        //BossController��NeedleCheck��bool�l�m�F
        bool NeedleChecker = BossScript.NeedleCheck;

        if (NeedleChecker == true)
        {
            //���Ԍv��
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                //Needle�̐���
                GameObject Needle = Instantiate(NeedlePrefab);
                Needle.transform.position = new Vector2(Boss.transform.localPosition.x - 3f, Boss.transform.localPosition.y);
                Needle.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);

                NeedleChecker = false;

            }
        }
    }
}
