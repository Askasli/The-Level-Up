
    using System;
    
    /// <summary>
    /// Interface for enabling and controlling rotation behavior.
    /// </summary>
    public interface IRotationEnable
    {
        /// <summary>
        /// Event triggered when the rotation state changes.
        /// </summary>
        event Action<bool> OnRotationChange;
        
        /// <summary>
        /// Checks whether rotation is allowed, after attack
        /// </summary>
        bool CanRotate();
        
        /// <summary>
        /// Sets the rotation value.
        /// </summary>
        void SetRotationValue(bool value);
    }
