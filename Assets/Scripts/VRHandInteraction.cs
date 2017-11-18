using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandInteraction : MonoBehaviour {

    private VRHandInteractableButton currentInteractableButton = null;
    [SerializeField] private HandType handType;

    [SerializeField] private AudioClip hapticsAudioClip;



    private void OnTriggerEnter(Collider other)
    {
  
        var vrHandInterButton = other.gameObject.GetComponent<VRHandInteractableButton>();
        if (vrHandInterButton != null)
        {
            if (currentInteractableButton == null)
            {
                currentInteractableButton = vrHandInterButton;
                currentInteractableButton.Vrinter_OnOver();
            }
            else if (currentInteractableButton != vrHandInterButton)
            {
                currentInteractableButton.Vrinter_OnOut();
                currentInteractableButton = vrHandInterButton;
                currentInteractableButton.Vrinter_OnOver();
            }
            //Play haptic feedback.
            var hapticsClip = new OVRHapticsClip(hapticsAudioClip);
            if(handType == HandType.LEFT) OVRHaptics.LeftChannel.Preempt(hapticsClip);
            else if(handType == HandType.RIGHT) OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        var vrHandInterButton = other.gameObject.GetComponent<VRHandInteractableButton>();
        if (vrHandInterButton != null)
        {
            vrHandInterButton.Vrinter_OnPressedByIndexFinger();
            vrHandInterButton.Vrinter_OnOut();
            currentInteractableButton = null;


            //Play haptic feedback.
            var hapticsClip = new OVRHapticsClip(hapticsAudioClip);
            if (handType == HandType.LEFT) OVRHaptics.LeftChannel.Preempt(hapticsClip);
            else if (handType == HandType.RIGHT) OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }
}
