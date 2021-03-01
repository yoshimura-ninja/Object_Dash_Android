using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

  //オブジェクトと結びつける
  public InputField inputField;

    void Start ()
    {
       
    }

    void Update ()
    {
      inputField = inputField.GetComponent<InputField> ();
      Goalmanager.username=inputField.text;
    }
}
