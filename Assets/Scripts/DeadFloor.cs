using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;


public class DeadFloor : MonoBehaviour
{    
      //プレイヤー格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    //RestartManager型
    private RestartManager restart;
 
    //ゲームオーバー判定
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    void Update()
    {
        //ゲームオーバーしていて画面がクリックされたとき
        if (restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }

     //プレイヤーの当たり判定部分
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがプレイヤーの時
        if(other.gameObject.name == player.name)
        {
            //RestartManagerに処理を任せる
            restart.PrintGameOver();
        }
    }
}