using System;
using Probability;

namespace Control
{
    public abstract class Action
    {
        protected static int _value;
    
        public Action(Distribution distribution)
        {
            _value = (int) distribution.F(RandomSingleton.Instance.GetRandom());
        }

        public int GetValue()
        {
            return _value;
        }

    }

    public class Strike : Action
    {
        public Strike(Distribution distribution) : base(distribution)
        {
        }
    }


    public class Healing : Action
    {
        public Healing(Distribution distribution) : base(distribution)
        {
        }
    }
}