using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if(other.gameObject.tag == "Dog")
        {
            //Debug.Log("false");
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
