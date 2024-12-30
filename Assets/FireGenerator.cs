using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject player;

    private Rigidbody2D myRigidbody;
    private float velocityX = 10f;

    //ƒvƒŒƒCƒ„[‚Æfire‚Ì‹——£
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x > 0)
        {
            GameObject fire = Instantiate(firePrefab);
            fire.transform.position = new Vector2(this.player.transform.localPosition.x - 1f, this.player.transform.localPosition.y + 1.5f);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX, 0);
        }

        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x < 0)
        {
            GameObject fire = Instantiate(firePrefab);
            fire.transform.position = new Vector2(this.player.transform.localPosition.x + 1f, this.player.transform.localPosition.y + 1.5f);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, 0);
        }

       
    }
}
