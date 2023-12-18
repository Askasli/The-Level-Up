using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

/// <summary>
/// Handles the UI for managing character attributes.
/// </summary>
public class AttributeUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text currentLevel;
    
    
    private PlayerAttributes _playerAttributes;
    private ICoinCounter _coinCounter;
       
    [Inject]
    private void Construct(ICoinCounter coinCounter, PlayerAttributes playerAttributes)
    {
        _coinCounter = coinCounter;
        _playerAttributes = playerAttributes;
    }

    /// <summary>
    /// Represents a pair of UI elements associated with an attribute type.
    /// </summary>
    [Serializable]
    private class AttributePair
    {
        public AttributeType attributeType;
        public Button increaseButton;
        public Button decreaseButton;
        public TMP_Text currentAmount;
    }

    [SerializeField] private List<AttributePair> attributePairs = new List<AttributePair>();

    private void Start()
    {
        InitializeUI();
    }

    /// <summary>
    /// Initializes the UI, with decrease and increase buttons attributeType
    /// </summary>
    private void InitializeUI()
    {
      
        foreach (var pair in attributePairs)
        {
            pair.increaseButton.onClick.AddListener(() => TryIncreaseLevel(pair.attributeType));
            pair.decreaseButton.onClick.AddListener(() => DecreaseLevel(pair.attributeType));
        }

        UpdateUI();
    }

    /// <summary>
    /// Increase the level of the specified attribute.
    /// </summary>
    private void TryIncreaseLevel(AttributeType attributeType)
    {
        int levelUpCost = _coinCounter.GetLevelUpCost(attributeType);

        if (_coinCounter.SpendCoins(levelUpCost))
        {
            _playerAttributes.LevelUpAttribute(attributeType, 1);
            _coinCounter.LevelUp(attributeType); // Обновляем стоимость увеличения уровня в CoinCounter
            UpdateUI();
            UpdateCharacterLevel();
        }
        else
        {
            Debug.Log("Not enough coins to level up!");
        }
    }

    
    /// <summary>
    /// Decreases the level of the specified attribute.
    /// </summary>
    private void DecreaseLevel(AttributeType attributeType)
    {
        _playerAttributes.LevelUpAttribute(attributeType, -1); 
        UpdateUI();
    }

    
    /// <summary>
    /// Updates the UI elements displaying attribute values.
    /// </summary>
    private void UpdateUI()
    {
        foreach (var pair in attributePairs)
        {
            pair.currentAmount.text = $"{_playerAttributes.GetCurrentAttributeValue(pair.attributeType)}";
        }
    }
    
    /// <summary>
    /// Updates the character level display.
    /// </summary>
    private void UpdateCharacterLevel()
    {
        int characterLevel = _playerAttributes.GetCharacterLevel(); 
        currentLevel.text = $"Level {characterLevel }";
    }

}
