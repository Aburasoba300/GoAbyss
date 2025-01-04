using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerator : MonoBehaviour
{
    public GameObject NeedlePrefab;
    GameObject Boss;
    BossController BossScript;
    //計測用の変数
    private float delta = 0;
    //抽選間隔
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
        //BossControllerのNeedleCheckのbool値確認
        bool NeedleChecker = BossScript.NeedleCheck;

        if (NeedleChecker == true)
        {
            //時間計測
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                //Needleの生成
                GameObject Needle = Instantiate(NeedlePrefab);
                Needle.transform.position = new Vector2(Boss.transform.localPosition.x - 3f, Boss.transform.localPosition.y);
                Needle.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);

                NeedleChecker = false;

            }
        }
    }
}
