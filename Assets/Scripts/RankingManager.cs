using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    //各位ランキング指定
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;

    public RankingData rankingData = new RankingData();

    public string ranking_name="";
    public double ranking_time=0.1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ranking_name=(string)(Goalmanager.ri.r1.name);
        ranking_time=(double)(Goalmanager.ri.r1.time);
        Debug.Log(ranking_time);
        Text text_1 = text1.GetComponent<Text> ();
        Text text_6 = text6.GetComponent<Text> ();
        text_1.text="1, name: "+ranking_name;
        text_6.text=" time: "+ranking_time;

        ranking_name=(string)(Goalmanager.ri.r2.name);
        ranking_time=(double)(Goalmanager.ri.r2.time);
        //text2.GetComponent<Text>().text = "2, name: " +(ranking_time)+" time: "+(ranking_time)+"";
        Text text_2 = text2.GetComponent<Text> ();
        Text text_7 = text7.GetComponent<Text> ();
        text_2.text="2, name: "+ranking_name;
        text_7.text=" time: "+ranking_time;

        ranking_name=(string)(Goalmanager.ri.r3.name);
        ranking_time=(double)(Goalmanager.ri.r3.time);
        Text text_3 = text3.GetComponent<Text> ();
        Text text_8 = text8.GetComponent<Text> ();
        text_3.text="3, name: "+ranking_name;
        text_8.text=" time: "+ranking_time;

        ranking_name=(string)(Goalmanager.ri.r4.name);
        ranking_time=(double)(Goalmanager.ri.r4.time);
        Text text_4 = text4.GetComponent<Text> ();
        Text text_9 = text9.GetComponent<Text> ();
        text_4.text="4, name: "+ranking_name;
        text_9.text=" time: "+ranking_time;

        ranking_name=(string)(Goalmanager.ri.r5.name);
        ranking_time=(double)(Goalmanager.ri.r5.time);
        Debug.Log(ranking_name);
        Debug.Log(ranking_time);
        Text text_5 = text5.GetComponent<Text> ();
        Text text_10 = text10.GetComponent<Text> ();
        text_5.text="5, name: "+ranking_name;
        text_10.text=" time: "+ranking_time;
    }
}
