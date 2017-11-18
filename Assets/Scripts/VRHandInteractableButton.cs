using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class VRHandInteractableButton : MonoBehaviour {

    private Button button;
    private PointerEventData pointer = new PointerEventData(EventSystem.current); // pointer event for Execute

    private void Awake()
    {
        button = this.GetComponent<Button>();
    }

    public void Vrinter_OnOver()
    {
        //Simulate pointer enter event.
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerEnterHandler);

    }

    public void Vrinter_OnPressedByIndexFinger()
    {
        //Simulate clicked event.
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.submitHandler);

    }

    public void Vrinter_OnOut()
    {
        //Simulate pointer leaving button event.
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerExitHandler);
    }
}
