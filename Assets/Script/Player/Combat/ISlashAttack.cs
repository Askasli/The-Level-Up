using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for slash attack.
/// </summary>
public interface ISlashAttack
{
    public void AttackBySlash(Transform colliderTransform);
}