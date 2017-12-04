using System;

namespace FSM
{
    public class State
    {
        private int _id;
        public int Id
        {
            get { return _id; }
        }

        private string _name;
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

        public Action OnBegin;
        public Action OnUpdate;
        public Action OnFixedUpdate;
        public Func<State, bool> OnEnd;
    }
}