# Advantech PCI relay card:  PCI-1761

Using adapter pattern to simplify code and enhance readability
        
<h3>Origianl way to open a port:</h3>
<p> 
//choose port<br/>
stateDoToWrite = ReadDoState(Port);  <br/>
// update all channels in port by calculating bytes<br/>
  stateDoToWrite|=(byte) (0x1 << Channel);  <br/>
// execute update in all channels   <br/>
  WriteDoState(Port, stateDoToWrite)            </p>
        
        
<h3>New Way to open a port:</h3>
  TurnOnChannel(port, channel);
