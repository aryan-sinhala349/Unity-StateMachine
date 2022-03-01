using UnityEngine;

/// <summary>
/// A basic State class implementation that uses <see cref="Action">Actions</see> and <see cref="StateDecisionTree">State Decision Trees</see>.
/// </summary>
[CreateAssetMenu(menuName = "Game/State Machine/State")]
public class State : ScriptableObject
{
    //A reference to the state machine that currently holds this state (which means a State can only be used on one StateMachine at a time)
    private StateMachine m_StateMachine;

    [SerializeField, Tooltip("A list of all actions associated with this state")] private Action[] m_Actions;
    [SerializeField, Tooltip("A list of all state decisions and their associated states")] private StateDecisionTree[] m_Decisions;

    /// <summary>
    /// Called whenever this state is added to a state machine
    /// </summary>
    /// <param name="stateMachine">The state machine that contains this state</param>
    public void OnAdded(StateMachine stateMachine)
    {
        m_StateMachine = stateMachine;

        //Add all the actions to this statte
        for (int i = 0; i < m_Actions.Length; i++)
            m_Actions[i].OnAdded(stateMachine, this);

        //Add all the decisions to this state
        for (int i = 0; i < m_Decisions.Length; i++)
            m_Decisions[i].m_Decision.OnAdded(stateMachine, this);
    }

    /// <summary>
    /// Called once every frame this state is active
    /// </summary>
    public void OnUpdate()
    {
        //Update all the actions on this state
        for (int i = 0; i < m_Actions.Length; i++)
            m_Actions[i].OnUpdate();

        //Go through every state decision tree
        for (int i = 0; i < m_Decisions.Length; i++)
        {
            //Decide what the new state should be
            bool decision = m_Decisions[i].m_Decision.Decide();
            State newState = decision ? m_Decisions[i].m_TrueState : m_Decisions[i].m_FalseState;

            //If it is a valid state, change to that state and exit this loop
            if (newState != null)
            {
                m_StateMachine.ChangeState(newState);
                break;
            }
        }
    }

    /// <summary>
    /// Called whenever the state machine no longer has a reference to this state
    /// </summary>
    public void OnRemoved()
    {
        //Remove all the actions
        for (int i = 0; i < m_Actions.Length; i++)
            m_Actions[i].OnRemoved();

        //Remove all the state decision trees
        for (int i = 0; i < m_Decisions.Length; i++)
            m_Decisions[i].m_Decision.OnRemoved();
    }
}