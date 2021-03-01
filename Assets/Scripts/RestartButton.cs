using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClick1()
    {
        // メインシーンへ移動
        Debug.Log (Goalmanager.username);
        SceneManager.LoadScene("object_dash");
    }
}
