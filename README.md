# Advantech PCI relay card:  PCI-1761

Using adapter pattern to simplify code and enhance readability
        
Origianl way to open a port:
  stateDoToWrite = ReadDoState(Port);           // choose port
  stateDoToWrite|=(byte) (0x1 << Channel);      // update all channels in port
  WriteDoState(Port, stateDoToWrite)            // execute update in all channels  
        
        
New Way to open a port:
  TurnOnChannel(port, channel);
