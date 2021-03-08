using System;
using UnityEngine;
using System.Collections.Generic;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {
        GameObject unitychan; //シーン内のUnityちゃんを格納
        //UnityChanControlScriptWithRgidBody script; //UnityChanScriptを格納
        public GameObject player;

        public string Name;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown("Jump");
        }


        public void SetUpState()
        {
            //CrossPlatformInputManager.SetButtonUp("Jump");
        }


        public void SetAxisPositiveState()
        {
            //CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            //CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            //CrossPlatformInputManager.SetAxisNegative("jump");
        }

        public void Update()
        {/*
            if(CrossPlatformInputManager.SetButtonDown("Jump"))
            {
                Debug.Log ("Input.getButtonDown jump");
            }*/
        }
        public void OnClick()
        {
            CrossPlatformInputManager.SetAxisNegative("jump");
        }
    }
}