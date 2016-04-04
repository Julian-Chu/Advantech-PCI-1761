using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCI_1761Control
{
    abstract public class State
    {
        string state;

        public abstract void Work(StateMachine stateMachine);
        public string GetState()
        {
            return this.GetType().ToString();
        }
    }

    public class State_DoorIsOpen : State
    {
        override public void Work(StateMachine stateMachine)
        {
            if (stateMachine.DoorIsClosed)
            {
                stateMachine.SetState(new State_DoorIsClosed());
            }
        }
    }

    public class State_DoorIsClosed : State
    {
        override public void Work(StateMachine stateMachine)
        {
            if (stateMachine.DoorIsLock)
            {
                stateMachine.SetState(new State_DoorIsLockedAndStartChikoMachine());
            }
        }
    }

    public class State_DoorIsLockedAndStartChikoMachine :State
    {
        public override void Work(StateMachine statemachine)
        { }
    }

    public class State_Marking : State
    {
        public override void Work(StateMachine stateMachine)
        {
            Console.WriteLine(this.GetType());
        }
    }

    public class State_MarkingIsFinished : State
    {
        public override void Work(StateMachine stateMachine)
        {
            Console.WriteLine(this.GetType());
        }
    }



}
