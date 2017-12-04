using UnityEngine;
using FSM;

public class MovementExample : StateMachine
{
    public enum MovementStates
    {
        Idle = 0,
        MovingX,
        MovingY
    }

    State IdleState;
    State PingpongXState;
    State PingpongYState;

    public MovementStates CurrentStateId
    {
        get
        {
            return (MovementStates)CurrenState.Id;
        }
    }

    protected override void SetupStateHandlers()
    {
        IdleState = new State("Idle", (int)MovementStates.Idle);
        IdleState.OnBegin += IdleState_OnBegin;
        IdleState.OnEnd += IdleState_OnEnd;


        PingpongXState = new State("PingPongXState", (int)MovementStates.MovingX);
        PingpongXState.OnBegin += PingpongXState_OnBegin;
        PingpongXState.OnUpdate += PingpongXState_OnUpdate;


        PingpongYState = new State("PingPongYState", (int)MovementStates.MovingY);
        PingpongYState.OnBegin += PingpongYState_OnBegin;
        PingpongYState.OnUpdate += PingpongYState_OnUpdate;

        UpdateState(IdleState);
    }

    void IdleState_OnBegin()
    {
        Debug.Log("Idle State Begin",gameObject);

        transform.position = Vector3.zero;
    }

    bool IdleState_OnEnd(State newState)
    {
        // only allow transition to PingpongXState from IdleState.

        Debug.Log("Idle State Ended", gameObject);

        return newState == PingpongXState;
    }

    void PingpongXState_OnBegin()
    {
        Debug.Log("PingPong X Begin", gameObject);

        transform.position = Vector3.zero;
    }

    void PingpongXState_OnUpdate()
    {
        float xValue = Mathf.PingPong(Time.time * 5, 3) - 1.5f;
        transform.position = new Vector3(xValue, transform.position.y, transform.position.z);
    }

    void PingpongYState_OnBegin()
    {
        Debug.Log("PingPong Y Begin", gameObject);

        transform.position = Vector3.zero;
    }

    void PingpongYState_OnUpdate()
    {
        float yValue = Mathf.PingPong(Time.time * 5, 3) - 1.5f;
        transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
    }


    public void StopMoving()
    {
        UpdateState(IdleState);
    }

    public void MoveX()
    {
        UpdateState(PingpongXState);
    }

    public void MoveY()
    {
        UpdateState(PingpongYState);
    }
}