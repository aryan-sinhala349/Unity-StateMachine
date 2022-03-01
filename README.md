# What is this project?
This is a very basic state machine for use inside Unity. It uses `ScriptableObject`s to help make this extremely modular and non-programmer friendly. I primarily made this because I use State Machines in a lot of projects, and don't want to keep rewriting them over and over again.

# How do I use it?
Because this state machine is built off of `Action`s and `Decision`s, you do not have to make custom state scripts for each state your object will go through. Instead, you create an action, which can be reused by multiple states. An example action that just applys gravity to a `CharacterController` would look like this:
```cs
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Actions/Gravity Action")]
public class GravityAction : Action
{
    private float m_YVelocity;
    private CharacterController m_Controller;
    
    [SerializeField] private float m_TerminalVelocity;
    [SerializeField] private float m_GravityScale;
    
    public override void OnAdded(StateMachine stateMachine, State state)
    {
        m_Controller = stateMachine.GetComponent<CharacterController>();
        m_YVelocity = m_Controller.velocity;y
    }
    
    public override void OnUpdate()
    {
        if (m_Controller.isGrounded)
            m_YVelocity = 0.0f;
    
        m_YVelocity += Physics.gravity.y * Time.deltaTime * m_GravityScale;
        m_YVelocity = Mathf.Clamp(m_YVelocity, -m_TerminalVelocity, m_TerminalVelocity);
        
        m_Controller.Move(Vector3.up * m_YVelocity * Time.deltaTime);
    }
}
```

Then, in the editor, you can go to the Create menu, and go to "Game > Actions > Gravity Action" and add it to a State (which is created by going to "Game > State Machine > State").

To create a decision, it's largely similar, but there is one thing that is different. Here's an example decision that checks to see if the `CharacterController` is grounded.

```cs
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Decisions/Character Controller Grounded Decision")]
public class CharacterControllerGroundedDecision : Decision
{
    private CharacterController m_Controller;
    
    public override void OnAdded(StateMachine stateMachine, State state)
    {
        m_Controller = stateMachine.GetComponent<CharacterController>();
    }
    
    public override bool Decide()
    {
        return m_Controller.isGrounded;
    }
}
```

As you can see, the `OnUpdate` function from the `Action` class was replaced with a `Decide` function. `OnUpdate` doesn't need to be overridden in a class that extends `Action`, but `Decide` must be overridden in every class that extends `Decision`.

To change states to somethign outside of the current network of states, just call `ChangeState` on the `StateMachine` and choose your new state. If you change to a `null` state, the current state will be cleared.
