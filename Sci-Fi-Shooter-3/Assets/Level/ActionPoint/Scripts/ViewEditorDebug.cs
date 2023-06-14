using UnityEngine;

public class ViewEditorDebug : MonoBehaviour
{
    [SerializeField] private float radius = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere (transform.position, radius);
    }
}
