using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.BDaq;

namespace PCI_1761Control
{
    public class PCIRealyCard
    {
        private byte stateToWrite=0;
        public byte StateToWrite
        {
            get { return stateToWrite; }
        }

        private byte stateFromRead=0;
        public byte StateFromread
        {
            get { return stateFromRead; }
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

        public PCIRealyCard()
        {
            DoController = new InstantDoCtrl();
            string deviceDescription = "DemoDevice,BID#0";
            DoController.SelectedDevice = new DeviceInformation(deviceDescription);
            Read(Ports[0]);
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
            
            stateToWrite|=(byte) (0x1 << Channel);            
        }

        public void TurnOffChannel(int Port, int Channel)
        {
            if (Channel > MaxChannel || Channel < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Channel");
            else if (Port > MaxPort || Port < MinChannel)
                throw new ArgumentOutOfRangeException("Invalid Port");

            stateToWrite &= (byte)~(0x1 << Channel);
        }

        public void Write(int port, byte state )
        {
            err=DoController.Write(port, state);
            if (err != ErrorCode.Success)
            {
                throw new Exception("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }

        public byte Read(int port)
        {
            DoController.Read(port, out stateFromRead);

            return stateFromRead;
        }

    }
}
