# Advantech PCI relay card:  PCI-1761

Using adapter pattern to simplify code and improve readability
        
<h3>Origianl way to open a channel(1 Output on):</h3>
<p> 
//choose port<br/>
stateDoToWrite = ReadDoState(Port);  <br/>
// update all channels in port by calculating bytes<br/>
stateDoToWrite|=(byte) (0x1 << Channel);  <br/>
// execute update in all channels   <br/>
WriteDoState(Port, stateDoToWrite)      
</p>        
<h3>New Way to open a channel(1 Output on):</h3>
  TurnOnChannel(port, channel);
