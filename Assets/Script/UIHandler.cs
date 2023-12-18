using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// Handles UI interactions, 
public class UIHandler : MonoBehaviour
{
    [SerializeField] private Transform pauseMenu;
    private IPauseToggle _pauseToggle;
    
    
    /// Injects dependencies
    [Inject]
    private void Construct(IPauseToggle pauseToggle)
    {
        _pauseToggle = pauseToggle;
    }

    private void Update()
    {
        _pauseToggle.IsPauseActivated(pauseMenu); 
    }
}
