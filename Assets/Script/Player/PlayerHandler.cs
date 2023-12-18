using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


/// <summary>
/// Player handler controlling movement, attack, and rotation.
/// </summary>

public class PlayerHandler : MonoBehaviour
{
    // DI from Zenject
    private IMoveSettings _moveSettings;
    private IRotationSlashHandler _slashRotation;
    private ISlashAttack _slashAttack;
    // Rigidbody component for controlling character physics.
    private Rigidbody2D _rigidbody2D;

    // Transforms for rotation and attack.
    [SerializeField] private Transform rotationSlash;
    [SerializeField] private Transform slashFXColliderTransform;
    
    
    /// <summary>
    /// DI
    /// </summary>
    [Inject]
    private void Construct(IMoveSettings moveSettings, IRotationSlashHandler slashRotation, ISlashAttack slashAttack)
    {
        _moveSettings = moveSettings;
        _slashRotation = slashRotation;
        _slashAttack = slashAttack;
    }

    /// <summary>
    /// Initialization of the Rigidbody component.
    /// </summary>
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handles slash rotation and attack.
    /// </summary>
    
    private void Update()
    {
        _slashRotation.SlashRotation(rotationSlash, transform);
        _slashAttack.AttackBySlash(slashFXColliderTransform);
    }

    /// <summary>
    /// Handles character movement.
    /// </summary>
    private void FixedUpdate()
    {
        _moveSettings.MoveBody(_rigidbody2D);
    }
}
    

