using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asibaController : MonoBehaviour
{
    public bool asi = false;

    void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.tag == "asiba")
        {
            asi = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "asiba")
        {
            asi = false;

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
