using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmanager : MonoBehaviour
{
    //オブジェクトの速度
    public float speedx = 0.05f;
    public float speedz = 0.05f;
    //オブジェクトの横移動の最大距離
    public float max_x = 100.0f;

    public float max_time = 5.00f; // 往復時間設定

    private float step_time; // 経過時間カウント用

    void Start()
    {
        step_time = 0.0f;  // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speedx,0,speedz);
        // 経過時間をカウント
        step_time += Time.deltaTime;
        // 
        if (step_time >= max_time)
        {
            speedx = speedx*(-1);
            speedz = speedz*(-1);
            step_time = 0.0f;  // 経過時間初期化
        }
    }
}

