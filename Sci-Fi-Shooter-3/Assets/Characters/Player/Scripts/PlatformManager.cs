using GameScore;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private bool isMobile;
    public static bool IsMobile { get; private set; }

    private void OnEnable()
    {
        GSLoader.OnLoaded += SetIsMobile;
    }

    private void OnDisable()
    {
        GSLoader.OnLoaded -= SetIsMobile;
    }

    private void SetIsMobile()
    {
        if (!Application.isEditor) IsMobile = GS_Device.IsMobile();
        else IsMobile = isMobile;
    }
}
