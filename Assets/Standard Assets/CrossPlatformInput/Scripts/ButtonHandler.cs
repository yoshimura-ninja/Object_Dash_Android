using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

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
            CrossPlatformInputManager.SetButtonUp("Jump");
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative("jump");
        }

        public void Update()
        {
            if(CrossPlatformInputManager.GetButton ("Jump"))
            {
                Debug.Log ("Input.getButtonDown jump");
            }
        }
    }
}