using UnityEngine;
using UnityEngine.AI;
using System;

public class Life : MonoBehaviour
{
    public Action OnDid;
    [SerializeField] private GameObject effectDid;
    public bool IsDid { private set; get;} 

    public void Did()
    {
        if (IsDid) return;
        IsDid = true;
        OnDid?.Invoke();
        if (CompareTag("Player"))
        {
            FindObjectOfType<LevelManager>().Did();
        }
        else
        {
            foreach (var component in GetComponents<MonoBehaviour>())
            {
                component.enabled = false;
            }
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if (effectDid != null)
            {
                Instantiate(effectDid, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Did");
            }
        }
    }

    public void Respawn()
    {
        IsDid = false;
        var healthPoint = GetComponent<HealthPoints>();
        healthPoint.TakeHealth(healthPoint.MaxHealth);
    }
}
