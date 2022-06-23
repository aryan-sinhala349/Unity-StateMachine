using UnityEngine;

/// <summary>
/// A basic container for a <see cref="Decision"/> and two <see cref="State">States</see>
/// </summary>
[System.Serializable]
public class StateDecisionTree
{
    [SerializeField, Tooltip("The conditions that must be met")] internal Decision[] m_Decisions;
    [SerializeField, Tooltip("What state to go to when the condition is true")] internal State m_TrueState;
    [SerializeField, Tooltip("What state to go to when the condition is false")] internal State m_FalseState;
}