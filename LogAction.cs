using UnityEngine;

[CreateAssetMenu(menuName = "Game/State Machine/Log Action")]
public class LogAction : Action
{
    [SerializeField] private string m_Message;

    public override void OnAdded(StateMachine stateMachine, State state) => Debug.Log(m_message);
}