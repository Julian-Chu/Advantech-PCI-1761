using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCI_1761Control;
using NUnit.Framework;


namespace PCI_1761Control.Tests
{
    [TestFixture()]
    public class StateMachineTests
    {
        [Test()]
        public void GetState_Initializing_Return_State_DoorIsOpen()
        {
            //Assign
            StateMachine stateMachine = new StateMachine();
            string actual;
            string expected;

            //Act
            actual = stateMachine.GetState();
            expected = (new State_DoorIsOpen()).GetType().ToString();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void SetState_SetToDoorIsClosed_Return_State_DoorIsClosed()
        {
            //Assign
            StateMachine stateMachine = new StateMachine();
            string actual;
            string expected;

            //Act
            stateMachine.SetState(new State_DoorIsClosed());
            actual = stateMachine.GetState();
            expected = (new State_DoorIsClosed()).GetType().ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
