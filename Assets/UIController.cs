using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //ゲームオーバーテキスト
    private GameObject GameOverText;
    //クリアテキスト
    private GameObject GameClearText;

    //ゲームオーバーの判定
    public bool isGameOver = false;
    //ゲームクリアの判定
    public bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからオブジェクト取得
        this.GameOverText = GameObject.Find("GameOver");
        this.GameClearText = GameObject.Find("Clear");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isGameOver == true || this.isGameClear == true)
        {
            //Enterをクリックされたらシーンをロード
            if(Input.GetKey(KeyCode.Return))
            {
                //SampleSceneを読み込む
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        //ゲームオーバーで画面上にGameOverを表示
        this.GameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }

    public void GameClear()
    {
        //Boss撃破時に画面上にGameClearを表示
        this.GameClearText.GetComponent<Text>().text = "Game Clear!!";
        this.isGameClear = true;
    }
}
