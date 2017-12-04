using UnityEngine;

namespace FSM
{
    public class StateMachine : MonoBehaviour
    {
        protected State CurrenState { get; set; }

        protected State PreviousState { get; set; }

        protected virtual void SetupStateHandlers()
        {
            // override this to setup all state event handlers.
        }

        protected bool EndPreviusState(State newState)
        {
            if (CurrenState != null)
            {
                return CurrenState.End(newState);
            }
            return true;
        }

        protected void UpdateState(State newState)
        {
            bool isPreviousStateSuccessfully = EndPreviusState(newState);

            if (!isPreviousStateSuccessfully)
            {
                string exMessage = string.Format("Can not make transition from CurrentState:{0} to NewState:{1}", CurrenState, newState);
                throw new System.InvalidOperationException(exMessage);
            }

            PreviousState = CurrenState;
            CurrenState = newState;

            CurrenState.Begin();
        }

        protected void UpdateToPreviousState()
        {
            UpdateState(PreviousState);
        }



        // UNITY_BEHAVIOUR_METHODS

        protected virtual void Start()
        {
            SetupStateHandlers();
        }

        protected virtual void Update()
        {
            if (CurrenState != null)
            {
                CurrenState.Update();
            }
        }

        protected virtual void FixedUpdate()
        {
            if (CurrenState != null)
            {
                CurrenState.FixedUpdate();
            }
        }
    }
}