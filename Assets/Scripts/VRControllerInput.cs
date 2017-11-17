using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace VRUtils
{
    // This class encapsulates all the input required for most VR games.
    // It has events that can be subscribed to by classes that need specific input.
    public class VRControllerInput : MonoBehaviour
    {
        public enum HandType
        {
            LEFT,
            RIGHT
        }
        
        /// <summary>
        /// Action for when the select button is pressed down. 
        /// bool -- true if it is left hand, false otherwise.
        /// </summary>
        public Action<HandType> OnSelectButtonDown;
        /// <summary>
        /// Action for when the select button is released. 
        /// bool -- true if it is left hand, false otherwise.
        /// </summary>
        public Action<HandType> OnSelectButtonUp;


        void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                if (OnSelectButtonDown != null) OnSelectButtonDown(HandType.LEFT);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                if (OnSelectButtonDown != null) OnSelectButtonDown(HandType.RIGHT);
            }
            if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
            {
                if (OnSelectButtonUp != null) OnSelectButtonUp(HandType.LEFT);
            }
            if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
            {
                if (OnSelectButtonUp != null) OnSelectButtonUp(HandType.RIGHT);
            }
        }
    }
}