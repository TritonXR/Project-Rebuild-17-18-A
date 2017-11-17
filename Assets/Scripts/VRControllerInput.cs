using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public enum HandType
{
    LEFT,
    RIGHT
}

namespace VRUtils
{
    // This class encapsulates all the input required for most VR games.
    // It has events that can be subscribed to by classes that need specific input.
    public class VRControllerInput : MySingleton<VRControllerInput>
    {
        /// <summary>
        /// References to transforms of both controller.
        /// </summary>
        [SerializeField] private Transform leftControllerTrans;
        [SerializeField] private Transform rightControllerTrans;


        
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

        /// <summary>
        /// Get the world position of the controllers.
        /// </summary>
        /// <param name="hand">Left/right controller.</param>
        /// <returns>The position of the controller.</returns>
        public Vector3 GetControllerPosition(HandType hand)
        {
            Vector3 pos = Vector3.zero;
            if (hand == HandType.LEFT)
            {
                pos = leftControllerTrans.transform.position;
            }
            else if (hand == HandType.RIGHT)
            {
                pos = rightControllerTrans.transform.position;
            }
            return pos;
        }


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