using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    [SerializeField] private Transform laserTr;
    [SerializeField] private Vector3 offsetTarget;
    private Transform target;
    private Life _life;

    private void Start()
    {
        target = GetComponent<TargetMoveBot>().GetTarget();
        _life = GetComponent<Life>();
    }

    private void LateUpdate()
    {
        if (_life.IsDid) return;
        laserTr.LookAt(target.position + offsetTarget);
        laserTr.Rotate(Vector3.right, 270);
    }
}
