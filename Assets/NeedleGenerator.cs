using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerator : MonoBehaviour
{
    public GameObject NeedlePrefab;
    GameObject Boss;
    BossController BossScript;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.Find("Boss");
        BossScript = Boss.GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        //BossControllerÇÃNeedleCheckÇÃboolílämîF
        bool NeedleChecker = BossScript.NeedleCheck;

        if (NeedleChecker == true)
        {

            //NeedleÇÃê∂ê¨
            GameObject Needle = Instantiate(NeedlePrefab);
            Needle.transform.position = new Vector2(Boss.transform.localPosition.x - 2f, Boss.transform.localPosition.y);
            Needle.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);

            NeedleChecker = false;
        }
    }
}
