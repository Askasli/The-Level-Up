using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Implementation of ISlashAttack interface for handling slash attacks.
/// </summary>
public class SlashAttack : ISlashAttack
{
    private IRotationEnable _rotationEnable;
    
    [Inject]
    public void Construct(IRotationEnable rotationEnable)
    {
        _rotationEnable = rotationEnable;
        _rotationEnable.SetRotationValue(true);
    }
    
    /// <summary>
    /// Initiates a slash attack when the right button is clicked
    /// </summary>
    public void AttackBySlash(Transform colliderTransform)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CoroutineRunner.Instance.StartCoroutine(ActivateSlash(colliderTransform));
        }
    }
    
    /// <summary>
    /// Activates the slash, temporarily disabling rotation during the attack.
    /// </summary>
    IEnumerator ActivateSlash(Transform colliderTransform)
    {
        if (colliderTransform != null)
        {
            _rotationEnable.SetRotationValue(false);
            yield return new WaitForSeconds(0.1f);
            colliderTransform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            _rotationEnable.SetRotationValue(true);
            colliderTransform.gameObject.SetActive(false);
        }
    }
}
