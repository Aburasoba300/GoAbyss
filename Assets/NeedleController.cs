using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    int NeedleAttack = 3;
    public GameObject Player;
    PlayerController PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);

        if (other.gameObject.tag == "Player")
        {
            PlayerScript.HP -= NeedleAttack;
        }
    }
}
