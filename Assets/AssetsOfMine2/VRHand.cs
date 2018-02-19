using UnityEngine;

public enum HandType
{
    LEFT,
    RIGHT
}
public class VRHand : MonoBehaviour
{
    private VRHandInteractable currentInteractableButton = null;
    //Handedness.
    [SerializeField] private HandType handType;
    //Stores the audio clip for haptics.
    [SerializeField] private AudioClip hapticsAudioClip;
    //Handles when another collider enters this trigger(collider).
    private void OnTriggerEnter(Collider other)
    {
        //Deal with this triggerEnter only when the othe object has
        //VRInteractable.
         var vrHandInterButton =
        other.gameObject.GetComponent<VRHandInteractable>();
        if (vrHandInterButton != null)
        {
            //If the current interactable is not assigned.
            if (currentInteractableButton == null)
            {
                //assign the interactable.
                currentInteractableButton = vrHandInterButton;
                //call the OnHandOver method on the current interactable as
                //the hand is touching the object now.
 currentInteractableButton.OnHandOver();
            }
            //If the user touches another interactable
            else if (currentInteractableButton != vrHandInterButton)
            {
                //Call the OnHandOut method on the previous interactable as
                //the hand has left the previous object.
                 currentInteractableButton.OnHandOut();
                //Update the current interactable reference.
                currentInteractableButton = vrHandInterButton;
                //Call the OnHandOver method on the newly touched
                //interactable as the hand is touching the new object now.
                 currentInteractableButton.OnHandOver();
            }
            //Play haptic feedback.
            var hapticsClip = new OVRHapticsClip(hapticsAudioClip);
            if (handType == HandType.LEFT)
                OVRHaptics.LeftChannel.Preempt(hapticsClip);
            else if (handType == HandType.RIGHT)
                OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }
    //Handles when another collider exits this trigger(collider).
    private void OnTriggerExit(Collider other)
    {
        //Deal with this triggerExit only when the othe object has
        //VRInteractable.
         var vrHandInterButton =
        other.gameObject.GetComponent<VRHandInteractable>();
        //If the current vr interactable is not empty
        if (vrHandInterButton != null)
        {
            //This is for the task of next week.
            //When the hand leaves the interactable's collider, a "pressed"
            //action is triggered.
            //vrHandInterButton.OnPressed();
            //Call the OnHandOut method on the current interactable is the
            //hand is leaving the other object.
             vrHandInterButton.OnHandOut();
            //Clears the current interactable as the hand is not touching
            //anything now.
 currentInteractableButton = null;
            //Play haptic feedback.
            var hapticsClip = new OVRHapticsClip(hapticsAudioClip);
            if (handType == HandType.LEFT)
                OVRHaptics.LeftChannel.Preempt(hapticsClip);
            else if (handType == HandType.RIGHT)
                OVRHaptics.RightChannel.Preempt(hapticsClip);
        }
    }
}