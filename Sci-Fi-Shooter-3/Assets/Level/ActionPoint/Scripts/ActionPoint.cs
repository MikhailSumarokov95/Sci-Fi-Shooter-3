using UnityEngine;
using UnityEngine.Events;

public class ActionPoint : MonoBehaviour
{
    public UnityEvent OnWentToActionPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnWentToActionPoint?.Invoke();
            Destroy(gameObject);
            print("OnTriggerEnter");
        }
    }
}
