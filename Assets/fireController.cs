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
        //�v���C���[��fire�̋����𑪒�
        distance = Mathf.Abs(transform.position.x - player.transform.position.x);

        if (distance > 10)
        {
            Debug.Log("destroy");
            Destroy(this.gameObject);

        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        Destroy(this.gameObject);
    }
}
