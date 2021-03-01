using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    //プレイヤーを格納する変数
    public GameObject player;
    //エネミーを格納する変数
    public GameObject enemy;
    //テキストを格納する変数
    public GameObject text;
 
    //RestartManager型
    private RestartManager restart;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        //インスタンス生成
        restart = new RestartManager(player, text);
    }
    //目的地となるオブジェクトのトランスフォーム格納用
    public Transform target;
    //enemyのトランスフォーム格納用
    public Transform enemy_trance;
    //エージェントとなるオブジェクトのNavMeshAgent格納用
    public NavMeshAgent agent;
    //エネミーの索敵範囲格納用
    public float _distance=10.0f;

    // Use this for initialization
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
		return;
	    }
        
        float distance=Vector3.Distance(enemy_trance.position, target.position);
        
        //目的地となる座標を設定する
        if(distance < _distance)
        {
            //目的地となる座標を設定する
            agent.destination = target.transform.position;
        }
        if(restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトがプレイヤーの場合
        if (other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
        }
    }
}