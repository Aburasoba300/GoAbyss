using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Playerのオブジェクト
    private GameObject Player;
    
    //カメラの最大値
    float MaxCameraPosi = 0.2f;
    //カメラの最小値
    float MinCameraPosi = -0.1f;
    //カメラのyの最小値
    float MinCameraPosiY = -30;
    //カメラのスクロールスピード
    float CameraScrollSpeed = 50f;
    //時間計測の判定
    bool CountWatch = false;
    //経過時間のカウント
    float TimeCount = 0;
    //カメラを下げる位置の制限
    float LimitCameraDown = 20;

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
        if (this.Player.transform.position.x >= MinCameraPosi && this.Player.transform.position.x <= MaxCameraPosi)
        {
            this.transform.position = new Vector3(this.Player.transform.position.x, this.Player.transform.position.y, -20); 
        }

        if(this.Player.transform.position.x < MinCameraPosi)
        {
            this.transform.position = new Vector3(MinCameraPosi, this.Player.transform.position.y, -20);
        }

        if (this.Player.transform.position.x > MaxCameraPosi)
        {
            this.transform.position = new Vector3(MaxCameraPosi, this.Player.transform.position.y, -20);
        }

        

        //カメラ移動
        if (Input.GetMouseButton(1) && transform.position.y > MinCameraPosiY)
        {
            OnStart();
            if(CountWatch == true)
            {
                TimeCount += Time.deltaTime;
                this.transform.Translate(0, -CameraScrollSpeed * TimeCount, 0);

                //下げられる限界値まで来たらStop
                if(CameraScrollSpeed * TimeCount >= LimitCameraDown)
                {
                    this.transform.position = new Vector3(transform.position.x, Player.transform.position.y - LimitCameraDown, transform.position.z);
                    
                }
                //最下層でのカメラ移動の処理
                if (Player.transform.position.y - LimitCameraDown == MinCameraPosiY)
                {
                    this.transform.position = new Vector3(transform.position.x, MinCameraPosiY, transform.position.z);

                }

            }
            
        }
        else if(Input.GetMouseButtonUp(1))
        {
            Reset();
        }

        
    }
    
    //時間計測開始
    public void OnStart()
    {
        CountWatch = true;
    }
    //時間計測終了
    public void Reset()
    {
        CountWatch = false;
        TimeCount = 0;
    }
}
