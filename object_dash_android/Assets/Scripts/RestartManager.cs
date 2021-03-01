using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class RestartManager : MonoBehaviour
{
    private GameObject player;
    private GameObject text;

    private bool isGameOver = false;

    //コンストラクタ
    public RestartManager(GameObject player,GameObject text)
    {
        this.player = player;
        this.text = text;
    }

    public void PrintGameOver()
    {
        //ゲームオーバーを表示する
        text.GetComponent<Text>().text = "GameOver...\n画面クリックでリスタート！";
        text.SetActive(true);

        //プレイヤーを動けなくする
        player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
        //アニメーションをオフにする
        player.GetComponent<Animator>().enabled = false;

        //ゲームオーバー
        isGameOver = true;
    }

    //シーンを再読み込みする
    public void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
        //時間の再設定
        TimeManager.limit=40.0f;
    }

    //ゲームオーバーしているかどうか確認
    public bool IsGameOver()
    {
        return isGameOver;
    }
}