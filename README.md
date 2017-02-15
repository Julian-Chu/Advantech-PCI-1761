# Advantech PCI relay card:  PCI-1761

Using adapter pattern to simplify code and enhance readability
        
<h1>Origianl way to open a port:</h1>
// choose port
  stateDoToWrite = ReadDoState(Port);  
// update all channels in port by calculating bytes
  stateDoToWrite|=(byte) (0x1 << Channel); 
// execute update in all channels  
  WriteDoState(Port, stateDoToWrite)            
        
        
New Way to open a port:
  TurnOnChannel(port, channel);
