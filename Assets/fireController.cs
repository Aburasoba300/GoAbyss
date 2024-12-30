using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject player;
    //プレイヤーとfireの距離
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //生成したFireを取得
        GameObject[] g = GameObject.FindGameObjectsWithTag("Fire");
        //プレイヤーとfireの距離を測定
        distance = transform.position.x - player.transform.position.x;
        //一定距離離れると破壊
        for (int i = 0; i < g.Length; i++)
        {
            if (distance > 3)
            {
                Debug.Log("destroy");
                Destroy(g[i]);
            }
        }
    }
}
