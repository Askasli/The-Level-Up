using System;


/// <summary>
/// Show attribute with a level, allowing updates to its parameters.
/// </summary>
public interface IAttribute 
{
    /// <summary>
    /// Gets or sets the level of the attribute.
    /// </summary>
    int Level { get; set; }
    
    /// <summary>
    /// Updates the parameters of the attribute based on its level.
    /// </summary> 
    void UpdateParameters();
    
    /// <summary>
    /// Event triggered when the attribute changes, providing the new value.
    /// </summary>
    event Action<float> AttributeChanged;

}
