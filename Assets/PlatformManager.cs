using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private List<PlatformMover> _platforms = new();

    public void OnStopPlatforms()
    {
        foreach (PlatformMover platform in _platforms)
        {
            platform.OnStopPlatform();
        }
    }

}
