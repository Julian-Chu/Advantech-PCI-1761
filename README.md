# Advantech PCI relay card:  PCI-1761

Using adapter pattern to simplify code and enhance readability
        
<h6>Origianl way to open a port:</h6>
<p> 
//choose port<br/>
stateDoToWrite = ReadDoState(Port);  <br/>
// update all channels in port by calculating bytes<br/>
  stateDoToWrite|=(byte) (0x1 << Channel);  <br/>
// execute update in all channels   <br/>
  WriteDoState(Port, stateDoToWrite)            </p>
        
        
<h6>New Way to open a port:</h6>
  TurnOnChannel(port, channel);
