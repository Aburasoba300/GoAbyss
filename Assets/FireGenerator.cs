using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject player;

    private Rigidbody2D myRigidbody;
    private float velocityX = 10f;

    public bool FireCheck = false;
    float FireRate = 0.4f;

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
        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x > 0 && FireCheck == false)
        {
            GameObject fire = Instantiate(firePrefab);
            fire.transform.position = new Vector2(this.player.transform.localPosition.x - 2f, this.player.transform.localPosition.y + 1.2f);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocityX, 0);
            
            StartCoroutine(FireRating());
        }

        if (Input.GetMouseButtonDown(0) && player.transform.localScale.x < 0 && FireCheck == false)
        {
            GameObject fire = Instantiate(firePrefab);
            fire.transform.position = new Vector2(this.player.transform.localPosition.x + 2f, this.player.transform.localPosition.y + 1.2f);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, 0);

            StartCoroutine(FireRating());
        }

        
    }

    public IEnumerator FireRating()
    {
        FireCheck = true;
        yield return new WaitForSeconds(FireRate);
        FireCheck = false;
    }
}
