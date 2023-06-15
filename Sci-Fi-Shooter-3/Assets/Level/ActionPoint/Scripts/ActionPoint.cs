using System;
using UnityEngine;
using UnityEngine.Events;

public class ActionPoint : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    [SerializeField] private ActionEvents onEnterToActionPoint;
    [SerializeField] private ActionEvents onStayToActionPoint;
    [SerializeField] private ActionEvents onExitToActionPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onEnterToActionPoint);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onStayToActionPoint);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onExitToActionPoint);
    }

    private void DoEvent(ActionEvents actionEvents)
    {
        actionEvents.Event.Invoke();
        if (actionEvents.DestroyPointAfterEvent) Destroy(gameObject);
    }

    [Serializable]
    public class ActionEvents
    {
        public UnityEvent Event;
        public bool DestroyPointAfterEvent;
    }
}
