using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject player;
    //�v���C���[��fire�̋���
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //��������Fire���擾
        GameObject[] g = GameObject.FindGameObjectsWithTag("Fire");
        //�v���C���[��fire�̋����𑪒�
        distance = transform.position.x - player.transform.position.x;
        //��苗�������Ɣj��
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
