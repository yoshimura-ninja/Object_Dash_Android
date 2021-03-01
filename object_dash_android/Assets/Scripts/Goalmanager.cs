using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;
using System;
using System.Runtime.Serialization;
using UnityEngine.Networking;
using System.Text;

 
public class Goalmanager : MonoBehaviour
{
    //プレイヤーキャラクターを格納するための変数
    public GameObject player;
    //テキストを格納するための変数
    public GameObject text;
    //goalされたかの判定
    private bool isGoal = false;

    public ReceieveUserInfoData receieveUserInfoData = new ReceieveUserInfoData();
    public static string username;

    //リザルトデータ管理のための変数
    public string url1 = "http://localhost:8000/time_regist";
    public string url2 = "http://localhost:8000/get_ranking";

    public double result_time;

    private RestartManager restart;

    //レスポンス受け取り格納class
    [Serializable]
    public class UserInfo
    {
        public string uuid;
        public string name;
        public double time;
        //public string time;
    }

    [Serializable]
    public class RankInfo
    {
        public UserInfo r1;
        public UserInfo r2;
        public UserInfo r3;
        public UserInfo r4;
        public UserInfo r5;
    }
    public static RankInfo ri=new RankInfo();

    private IEnumerator Coroutine1()
    {
        Debug.Log("スタート");
        yield return new WaitForSeconds(0.1f);
        //シーン移動
        //ゲームの一時停止を解除
        //Time.timeScale = 1f;
        Debug.Log("スタートから0.1秒後");
        SceneManager.LoadScene("ranking_display");
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }
     // Update is called once per frame
    void Update()
    {
        if(isGoal && Input.GetMouseButton(0))
        {
            StartCoroutine("Coroutine1");
        }
    }
    
    //当たり判定関数
    IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.name == player.name)
        {
            text.GetComponent<Text>().text="Goal !!!\nLoad終了後にリザルト画面へ移行します";
            //テキストをオンにしてゴール判定を変更
            text.SetActive(true);
            isGoal = true;

            //ゲーム全体を一時停止
            Time.timeScale = 0f;

            result_time=(double)(40.0f-TimeManager.limit);
            //string sresult_time=result_time.ToString();

            if (username==null)
            {
                username="default";
            }

            //ここからサーバーへのリザルト送信部分
            receieveUserInfoData.uuid="testtesttest";
            receieveUserInfoData.name=username;
            receieveUserInfoData.time=result_time.ToString("0.000");
            
        
            //string jsondata = JsonMapper.ToJson(receieveUserInfoData);
            string jsondata = JsonUtility.ToJson(receieveUserInfoData);
            Debug.Log(jsondata);
        
            WWWForm form = new WWWForm();
            //form.AddField("jsondata", jsondata);
            byte[] postBytes = Encoding.Default.GetBytes (jsondata);

            /*過去の遺物
            //form.AddField("jsondata", jsondata);
            var www = new WWW(url1, form);
            yield return www;
            Debug.Log("debug" +www.text);
            */

            //通信暗号化部分
            postBytes=EncryptManager.XorEncrypt(postBytes);
            Debug.Log("postBytes : " + postBytes);

            Dictionary<string, string> headers = new Dictionary<string,string>();
            headers.Add("Content-type", "application/json");
            WWW www = new WWW(url1, postBytes,headers);
            yield return www;
            

            //ここからサーバーへのランキング受信部分
            form.AddField("jsondata", jsondata);

            var www0 = new WWW(url2, form);
            yield return www0;
            //Debug.Log("{\"r1\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r2\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r3\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r4\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r5\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}}");
            Debug.Log(www0.text);
            //検証用            
            //string jstring="{\"r1\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": 0.01}, \"r2\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": 0.01}, \"r3\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": 0.01}, \"r4\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": 0.01}, \"r5\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": 0.01}}";
            //string jstring="{\"r1\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r2\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r3\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r4\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}, \"r5\": {\"uuid\": \"uuuuuuuuu\", \"name\": \"neko\", \"time\": \"0.01\"}}";
            //RankInfo resData = JsonUtility.FromJson<RankInfo> (jstring);
            string jstring=(www0.text);
            ri= JsonUtility.FromJson<RankInfo> (jstring);
            //ri=JsonMapper.ToObject<RankInfo> (jstring);
            Debug.Log("debug" +ri.r1.time);

            //ゲームの一時停止を解除
            Time.timeScale = 1f;
        }
    }
    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの再読み込み
        SceneManager.LoadScene(loadScene.name);
    }
}
