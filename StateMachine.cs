using UnityEngine;

/// <summary>
/// A basic but modular state machine that operates off of <see cref="State">States</see>.
/// </summary>
public class StateMachine : MonoBehaviour
{
    //A reference to the current state
    private State m_CurrentState = null;

    [SerializeField, Tooltip("The state this State Machine starts in")] private State m_StartState = null;

    private void Start()
    {
        //On startup change the current state to the start state
        ChangeState(m_StartState);
    }

    private void OnEnable()
    {
        m_CurrentState?.OnAdded(this);
    }

    private void OnDisable()
    {
        m_CurrentState?.OnRemoved();
    }

    private void Update()
    {
        m_CurrentState?.OnUpdate();
    }

    /// <summary>
    /// Changes the current state to a new one and calls the necessary functions involved with that
    /// </summary>
    /// <param name="state">The new state</param>
    public void ChangeState(State state)
    {
        //If m_CurrentState is not null, remove it
        m_CurrentState?.OnRemoved();

        //Change m_CurrentState to the new state
        m_CurrentState = state;

        //If m_CurrentState is not null, add it
        m_CurrentState?.OnAdded(this);
    }
}