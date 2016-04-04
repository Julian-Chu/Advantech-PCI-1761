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
    public class PCIRelayCardTests
    {
        [Test()]
        public void TurnOnChannel_WhenStateAreAllLowAndTurnOn_Port0_Ch2_OnlyCh2IsHigh()
        {
            //Assign
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOffChannel(pci1761.Ports[0], ch);
            pci1761.TurnOnChannel(pci1761.Ports[0], pci1761.Channels[2]);
            actual = pci1761.StateDoToWrite;
            expect = (0x1 << 2);
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOffChannel_OnlyChannel2IsHighAndTurnIt_Port0_Ch2_StateAreAllLow()
        {
            //Assign
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            pci1761.TurnOnChannel(pci1761.Ports[0], pci1761.Channels[2]);
            pci1761.TurnOffChannel(pci1761.Ports[0], pci1761.Channels[2]);
            actual = pci1761.StateDoToWrite;
            expect = 0;            
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOnChannel_TurnOnAllChannels_StateAreAllHigh()
        {
            //Assign
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOnChannel(pci1761.Ports[0], ch);

            actual = pci1761.StateDoToWrite;
            expect = 255;
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOffChannel_TurnOffAllChannels_StateAreAllLow()
        {
            //Assign
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOnChannel(pci1761.Ports[0], ch);
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOffChannel(pci1761.Ports[0],ch);
            actual = pci1761.StateDoToWrite;
            expect = 0;
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test()]
        public void Write_WhenStateAreAllLowAndTurnOn_Port0_Ch2_OnlyCh2IsHigh()
        {
            //Assign
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOffChannel(pci1761.Ports[0], ch);
            pci1761.TurnOnChannel(pci1761.Ports[0], pci1761.Channels[2]);
            //pci1761.WriteDoState(pci1761.Ports[0], pci1761.StateDoToWrite);
            actual = pci1761.ReadDoState(pci1761.Ports[0]);
            expect = (0x1 << 2);
            //Assert
            Assert.AreEqual(expect, actual);
        }
    }
}
