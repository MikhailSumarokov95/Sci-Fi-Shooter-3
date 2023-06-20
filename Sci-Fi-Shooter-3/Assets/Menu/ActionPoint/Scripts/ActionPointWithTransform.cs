using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class ActionPointWithTransform : ActionPoint
{
    protected override void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag(triggerTag)) return;
        base.OnTriggerEnter(collision);
        FindObjectOfType<MenuManager>().OnPause(true);
        collision.GetComponent<Character>().SetPositionAndRotation(transform);
    }
}
