using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightColorChanges : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    private Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
        _light.DOBlendableColor(_targetColor, 60);
    }

}
