using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaController : MonoBehaviour
{
    public bool asi = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asiba")
        {
            asi = true;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
