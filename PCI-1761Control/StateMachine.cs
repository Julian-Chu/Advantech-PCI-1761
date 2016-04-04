using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PCI_1761Control
{
    public class StateMachine
    {
        State currentState;        

        byte _DOState;
        byte _DIState;

        #region --State--
        public bool DoorIsOpen;
        public bool DoorIsClosed;
        public bool DoorIsLock;
        public bool Marking;
        public bool MarkingIsFinished;
        #endregion

        public void CheckState(byte DOState, byte DIState)
        {
            
        }
        public string GetState()
        {
            return currentState.GetType().ToString();
        }

        public void SetState(State newState)
        {
            currentState = newState;
            
        }

        public StateMachine()
        {
            SetState(new State_DoorIsOpen());
        }
    }
}
