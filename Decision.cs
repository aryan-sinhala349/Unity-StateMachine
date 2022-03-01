using UnityEngine;

/// <summary>
/// A basic decision class that tells each <see cref="State"/> when to change
/// </summary>
public abstract class Decision : ScriptableObject
{
    /// <summary>
    /// Called whenever this decision is added to a state
    /// </summary>
    /// <param name="stateMachine">The state machine the state was added to</param>
    /// <param name="state">The state this decision was added to</param>
    public virtual void OnAdded(StateMachine stateMachine, State state)
    {

    }

    /// <summary>
    /// Called whenever this decision is removed from a state
    /// </summary>
    public virtual void OnRemoved()
    {

    }

    /// <summary>
    /// Checks the condition and returns accordingly
    /// </summary>
    /// <returns>True if the condition is met, false otherwise</returns>
    public abstract bool Decide();
}