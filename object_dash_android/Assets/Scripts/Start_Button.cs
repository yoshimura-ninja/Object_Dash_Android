using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour
{
    public void OnClick()
    {
        if(Goalmanager.username!=null)
        {
        // メインシーンへ移動
        Debug.Log (Goalmanager.username);
        SceneManager.LoadScene("object_dash");
        }
    }
}
