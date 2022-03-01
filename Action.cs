using UnityEngine;

/// <summary>
/// A basic action class that tells each <see cref="State"/> what to do
/// </summary>
public class Action : ScriptableObject
{
    /// <summary>
    /// Called whenever this action is added to a state
    /// </summary>
    /// <param name="stateMachine">The state machine the state was added to</param>
    /// <param name="state">The state this action was added to</param>
    public virtual void OnAdded(StateMachine stateMachine, State state)
    {

    }

    /// <summary>
    /// Called once every frame this action is active
    /// </summary>
    public virtual void OnUpdate()
    {

    }

    /// <summary>
    /// Called whenever this action is removed from its state
    /// </summary>
    public virtual void OnRemoved()
    {

    }
}