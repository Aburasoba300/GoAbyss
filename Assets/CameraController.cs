using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Playerのオブジェクト
    private GameObject Player;
    //Playerとのカメラのカメラの距離
    //private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Playerのオブジェクトの取得
        this.Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Playerの位置に合わせてカメラを移動
        this.transform.position = 
            
            new Vector3(this.Player.transform.position.x,this.Player.transform.position.y,-20);
    }
}
