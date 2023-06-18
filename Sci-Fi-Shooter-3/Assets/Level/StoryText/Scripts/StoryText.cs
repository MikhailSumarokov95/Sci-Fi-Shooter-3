using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StoryText : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    public UnityEvent OnDisableText;

    private void OnEnable()
    {
        StartCoroutine(LifeCycle());
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        OnDisableText?.Invoke();
        gameObject.SetActive(false);
    }
}
