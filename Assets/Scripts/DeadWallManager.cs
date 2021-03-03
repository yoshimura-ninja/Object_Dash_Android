using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;


public class DeadWallManager : MonoBehaviour
{
    
      //プレイヤー格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    //RestartManager型
    private RestartManager restart;
 
    //ゲームオーバー判定
    private bool isGameOver = false;

    //オブジェクトの速度
    public float speedx = 0.00f;
    public float speedz = 0.00f;
    //オブジェクトの横移動の最大距離
    public float max = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    void Update()
    {
    
        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speedx,0,speedz);
        //Transformのxの値が一定値を超えたときに向きを反対にする
        if(this.gameObject.transform.position.x > max || this.gameObject.transform.position.x < (-max))
        {
            speedx = speedx*(-1);
        }
        if(this.gameObject.transform.position.z > max || this.gameObject.transform.position.z < (-max))
        {
            speedz = speedz*(-1);
        }
    
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
 
    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
}