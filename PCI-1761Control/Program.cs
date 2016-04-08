using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PCI_1761Control
{
    class Program
    {
        static void Main(string[] args)
        {
            PCIRelayCard PCI1761 = new PCIRelayCard();

#if DEBUG
            Console.WriteLine("DEBUG MODE BY #if");
#endif
            ShowDebugMode();

            do
            {
                Console.ReadLine();
                Console.WriteLine("Input command to switch IO:");
                Console.WriteLine("input a--> all high");
                Console.WriteLine("input b-->all low");
                switch (Console.Read())
                {
                    case 'a':
                        foreach (var ch in PCI1761.Channels)
                            PCI1761.TurnOnChannel(PCI1761.Ports[0], ch);
                        PCI1761.WriteDoState(0, PCI1761.StateDoToWrite);
                        break;
                    case 'b':
                        foreach (var ch in PCI1761.Channels)
                            PCI1761.TurnOffChannel(PCI1761.Ports[0], ch);
                        PCI1761.WriteDoState(0, PCI1761.StateDoToWrite);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("The state is:" + PCI1761.ReadDoState(0));
                Console.WriteLine("Press <ESC> to exit... or Any key to continue!");

            } while (Console.ReadKey().Key!=ConsoleKey.Escape);
        }

        [Conditional("DEBUG")]
        private static void ShowDebugMode()
        {
            Console.WriteLine("DEBUG MODE BY Conditional");
        }
    }
}
