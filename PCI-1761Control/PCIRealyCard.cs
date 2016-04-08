﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.BDaq;

namespace PCI_1761Control
{
    public class PCIRealyCard
    {
        private byte stateDoToWrite=0;
        public byte StateDoToWrite
        {
            get { return stateDoToWrite; }
        }

        private byte stateDoFromRead=0;
        public byte StateDoFromread
        {
            get { return stateDoFromRead; }
        }

        private byte stateDIFromRead = 0;
        public byte StateDIFromRead
        {
            get { return stateDIFromRead; }
        }
        ErrorCode err;

        #region --Channels--
        readonly public int[] Channels = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
        readonly public int MinChannel = 0;
        readonly public int MaxChannel = 7;
        #endregion
        #region --Ports--
        readonly public int IORealyPort=0;
        readonly public int IDIPort=1;
        readonly public int[] Ports = new int[2] { 0, 1 };
        readonly public int MinPort = 0;
        readonly public int MaxPort = 1;
        #endregion

        InstantDoCtrl DoController;
        InstantDiCtrl DiReader;

        public PCIRealyCard()
        {
            DoController = new InstantDoCtrl();
            DiReader = new InstantDiCtrl();
            string deviceDescription = "DemoDevice,BID#0";
            DoController.SelectedDevice = new DeviceInformation(deviceDescription);
            DiReader.SelectedDevice = new DeviceInformation(deviceDescription);
            ReadDoState(this.IORealyPort);
            ReadDiState(this.IDIPort);
        }

        public PCIRealyCard(int deviceNumber)
        {
            DoController = new InstantDoCtrl();
            DoController.SelectedDevice = new DeviceInformation(deviceNumber);
        }

        public void TurnOnChannel(int Port, int Channel)
        {
            if (Channel > MaxChannel || Channel < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Channel");
            else if (Port > MaxPort || Port < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Port");
            
            stateDoToWrite|=(byte) (0x1 << Channel);            
        }

        public void TurnOffChannel(int Port, int Channel)
        {
            if (Channel > MaxChannel || Channel < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Channel");
            else if (Port > MaxPort || Port < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Port");

            stateDoToWrite &= (byte)~(0x1 << Channel);
        }

        public void WriteDoState(int port, byte state )
        {
            err=DoController.Write(port, state);
            var t = Task.Delay(200);
            t.Wait();
            if (err != ErrorCode.Success)
            {
                throw new Exception("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }

        public byte ReadDoState(int port)
        {
            DoController.Read(port, out stateDoFromRead);

            return stateDoFromRead;
        }

        public byte ReadDiState(int port)
        {
            DiReader.Read(port, out stateDIFromRead);
            return stateDIFromRead;
        }

    }
}
