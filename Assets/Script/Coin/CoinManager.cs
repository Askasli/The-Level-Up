using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;


/// <summary>
/// Manages the display of current coin count using a TextMeshPro text field.
/// </summary>
public class CoinManager : MonoBehaviour
{
    /// <summary>
    /// Displaying the current coin count.
    /// </summary>
   [SerializeField] private TMP_Text currentCoins;
    
    private ICoinCounter _coinCounter;
    
    /// <summary>
    /// Injects the ICoinCounter dependency during construction.
    /// </summary>
    [Inject]
    private void Construct(ICoinCounter coinCounter)
    {
        _coinCounter = coinCounter;
    }
    
    /// <summary>
    /// Subscribes to the OnCoinsChanged event when the object is enabled.
    /// </summary>
    private void OnEnable()
    {
        _coinCounter.OnCoinsChanged += HandleCoinsChanged;
    }

    /// <summary>
    /// Unsubscribes from the OnCoinsChanged event when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
        _coinCounter.OnCoinsChanged -= HandleCoinsChanged;
    }
    
    /// <summary>
    /// When the number of coins changes, updating the displayed count.
    /// </summary>
    private void HandleCoinsChanged(int amount, bool isCollection)
    {
        if (currentCoins != null)
        {
            currentCoins.text = "Coins: " + _coinCounter.GetCurrentCoins();
        }
    }
}
