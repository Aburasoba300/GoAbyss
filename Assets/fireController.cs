using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject player;
    //vC[ΖfireΜ£
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Ά¬΅½FireπζΎ
        GameObject[] g = GameObject.FindGameObjectsWithTag("Fire");
        //vC[ΖfireΜ£πͺθ
        distance = transform.position.x - player.transform.position.x;
        //κθ££κιΖjσ
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
