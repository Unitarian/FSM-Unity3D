using System;

namespace FSM
{
    public class State
    {
        int _id;
        public int Id
        {
            get { return _id; }
        }

        string _name;
        public string Name
        {
            get { return _name; }
        }

        public State()
        {

        }

        public State(string name)
        {
            _name = name;
        }

        public State(string name, int id)
        {
            _name = name;
            _id = id;
        }

        public override string ToString()
        {
            return string.Format("[{0}][{1}]", Id, Name);
        }

        public event Action OnBegin;
        public event Action OnUpdate;
        public event Action OnFixedUpdate;
        public event Func<State, bool> OnEnd;

        internal void Begin()
        {
            if (OnBegin != null)
            {
                OnBegin();
            }
        }

        internal void Update()
        {
            if (OnUpdate != null)
            {
                OnUpdate();
            }
        }

        internal void FixedUpdate()
        {
            if (OnFixedUpdate != null)
            {
                OnFixedUpdate();
            }
        }

        internal bool End(State newState)
        {
            if (OnEnd != null)
            {
                return OnEnd(newState);
            }
            return true;
        }
    }
}