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
        PCIRelayCard pci1761;
        
        [SetUp]
        public void SetUp()
        {
            pci1761 = new PCIRelayCard();
        }

        [Test()]
        public void TurnOnChannel_WhenStateAreAllLowAndTurnOn_Port0_Ch2_OnlyCh2IsHigh()
        {
            //Assign
<<<<<<< HEAD
            byte actual;
            byte expect;
            //Act
            byte actual1 = pci1761.StateDoToWrite;
=======
            PCIRelayCard pci1761 = new PCIRelayCard();
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOffChannel(pci1761.Ports[0], ch);
>>>>>>> master
            pci1761.TurnOnChannel(pci1761.Ports[0], pci1761.Channels[2]);
            actual = pci1761.StateDoToWrite;
            expect = (0x1 << 2);
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOffChannel_OnlyCh2IsHighAndTurnIt_Port0_Ch2_StateAreAllLow()
        {
            //Assign
<<<<<<< HEAD
=======
            PCIRelayCard pci1761 = new PCIRelayCard();
>>>>>>> master
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
        public void TurnOnMultiChannels_TurnOnAllChannels_StateAreAllHigh()
        {
            //Assign
<<<<<<< HEAD
=======
            PCIRelayCard pci1761 = new PCIRelayCard();
>>>>>>> master
            byte actual;
            byte expect;
            //Act
            //foreach (var ch in pci1761.Channels)
            //    pci1761.TurnOnChannel(pci1761.Ports[0], ch);

            pci1761.TurnOnMultiChannels(pci1761.Ports[0], 0, 1, 2, 3, 4, 5, 6, 7);
            actual = pci1761.StateDoToWrite;
            expect = 255;
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOffMultiChannels_TurnOffAllChannels_StateAreAllLow()
        {
            //Assign
<<<<<<< HEAD
=======
            PCIRelayCard pci1761 = new PCIRelayCard();
>>>>>>> master
            byte actual;
            byte expect;
            //Act
            //foreach (var ch in pci1761.Channels)
            //    pci1761.TurnOnChannel(pci1761.Ports[0], ch);
            //foreach (var ch in pci1761.Channels)
            //    pci1761.TurnOffChannel(pci1761.Ports[0],ch);
            pci1761.TurnOnMultiChannels(pci1761.Ports[0], 0, 1, 2, 3, 4, 5, 6, 7);
            pci1761.TurnOffMultiChannels(pci1761.Ports[0], 0, 1, 2, 3, 4, 5, 6, 7);
            actual = pci1761.StateDoToWrite;
            expect = 0;
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOmMultiChannels_TurnOnCh234_StateAreHighOnCh234()
        {
            //Assign
            byte actual;
            byte expect;
            //Act
            //foreach (var ch in pci1761.Channels)
            //    pci1761.TurnOnChannel(pci1761.Ports[0], ch);

            pci1761.TurnOnMultiChannels(pci1761.Ports[0], 2, 3, 4);
            actual = pci1761.StateDoToWrite;
            expect = 28;
            //Assert
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TurnOmMultiChannels_TurnONAndThenOffCh234_StateAreloWOnCh234()
        {
            //Assign
            byte actual;
            byte expect;
            //Act
            //foreach (var ch in pci1761.Channels)
            //    pci1761.TurnOnChannel(pci1761.Ports[0], ch);

            pci1761.TurnOnMultiChannels(pci1761.Ports[0], 2, 3, 4);
            pci1761.TurnOffMultiChannels(pci1761.Ports[0], 2, 3, 4);
            actual = pci1761.StateDoToWrite;
            expect = 0;
            //Assert
            Assert.AreEqual(expect, actual);
        }


        [Test()]
        public void WriteDoState_WhenStateAreAllLowAndTurnOn_Port0_Ch2_OnlyCh2IsHigh()
        {
            //Assign
<<<<<<< HEAD
=======
            PCIRelayCard pci1761 = new PCIRelayCard();
>>>>>>> master
            byte actual;
            byte expect;
            //Act
            foreach (var ch in pci1761.Channels)
                pci1761.TurnOffChannel(pci1761.Ports[0], ch);
            pci1761.TurnOnChannel(pci1761.Ports[0], pci1761.Channels[2]);
<<<<<<< HEAD
            pci1761.WriteDoState(pci1761.Ports[0]);
=======
            //pci1761.WriteDoState(pci1761.Ports[0], pci1761.StateDoToWrite);
>>>>>>> master
            actual = pci1761.ReadDoState(pci1761.Ports[0]);
            expect = (0x1 << 2);
            //Assert
            Assert.AreEqual(expect, actual);
        }
    }
}
