using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject player;

    private Rigidbody2D myRigidbody;
    private float velocityX = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject fire = Instantiate(firePrefab);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX,0);

            fire.transform.position = player.transform.position;
        }
    }
}
