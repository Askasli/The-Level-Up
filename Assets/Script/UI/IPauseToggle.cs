using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPauseToggle
{
    /// <summary>
    /// Checks if the pause menu is currently activated.
    /// </summary>
    bool IsPauseActivated(Transform pauseMenu);

}
