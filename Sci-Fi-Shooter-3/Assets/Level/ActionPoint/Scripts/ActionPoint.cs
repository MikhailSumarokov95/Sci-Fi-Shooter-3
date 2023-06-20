using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActionPoint : MonoBehaviour
{
    [SerializeField] protected string triggerTag;
    [SerializeField] private ActionEvents onEnterToActionPoint;
    [SerializeField] private ActionEvents onStayToActionPoint;
    [SerializeField] private ActionEvents onExitToActionPoint;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onEnterToActionPoint);
    }

    protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onStayToActionPoint);
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
            DoEvent(onExitToActionPoint);
    }

    protected virtual void DoEvent(ActionEvents actionEvents)
    {
        actionEvents.Event?.Invoke();
        if (actionEvents.DestroyPointAfterEvent) Destroy(gameObject);
    }

    [Serializable]
    public class ActionEvents
    {
        public UnityEvent Event;
        public bool DestroyPointAfterEvent;
    }
}
