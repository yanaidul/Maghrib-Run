using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [SerializeField] private List<PlatformMover> _platforms = new();

    public int selectedPlatformIndex;

    public void OnStopPlatforms()
    {
        foreach (PlatformMover platform in _platforms)
        {
            platform.OnStopPlatform();
        }
    }

    private void Awake()
    {
        base.Awake();
        selectedPlatformIndex = Random.Range(0, 3);
    }

    public void RandomizeSelectedPlatformIndex()
    {
        selectedPlatformIndex = Random.Range(0, 3);
    }

}
