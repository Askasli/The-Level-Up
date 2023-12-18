using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implementation of the IPauseToggle interface to handle the activation state of the pause menu.
/// </summary>
public class PauseToggle : IPauseToggle
{
    private bool _isMenuActivated;
    
    /// <summary>
    /// Checks if the pause menu should be activated or deactivated based on the  input.
    /// </summary>
    public bool IsPauseActivated(Transform pauseMenu)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isMenuActivated = !_isMenuActivated;
            pauseMenu.gameObject.SetActive(_isMenuActivated);
            TimeControl();
        }

        return _isMenuActivated;
    }

    /// <summary>
    /// Controls the time scale
    /// </summary>
    private void TimeControl()
    {
        Time.timeScale = _isMenuActivated ? 0 : 1;
    }
}
