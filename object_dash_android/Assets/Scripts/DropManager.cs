﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    //RestartManager型
    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {   //プレイヤーの位置がｙ軸に-10移動したら
        if(player.transform.position.y < -10)
        {
            restart.PrintGameOver();
        }

        if(restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }
}