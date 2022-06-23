using UnityEngine;

public class DelayDecision : Decision
{
    private float m_StartTime;

    [SerializeField, Min(0.0f)] private float m_DelayTime;

    public override void OnAdded(StateMachine stateMachine, State state) => m_StartTime = Time.time;

    public override bool Decide()
    {
        float currentTime = Time.time;
        float deltaTime = currentTime - m_StartTime;

        return deltaTime >= m_DelayTime;
    }
}