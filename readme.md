VPN-Check 1.0
Written by jgeau in c# requires .net 3.0 or higher

VPN-Check.exe is just a simple command line tool that does nothing more than return a 0 or 160 as an exit code.
If the VPN is connected in it will return 160 and show "Error! VPN is connected" in at the command prompt.
If the VPN is not connected in will return 0 and show "VPN is not connected!" in at the command prompt.

Usage
This is intended to be used with other programs that may need to know if a VPN is currently connected and active.

For testing and debugging open a command prompt and run VPN-Check.exe and observe the output. it will list all adapters and thier types that were found.

Example: in powershell can run VPN-Check.exe The look at $LASTEXITCODE

If $LASTEXITCODE is 0 then the dock is not plugged in
IF $LASTEXITCODE is 160 then the dock is plugged in


In an SCCM task sequence just run the command VPN-Check.exe in a "run command line" step
The task sequence will see and exit code of 0 if the VPN is not connected and continue
The task sequence will see and exit code of 160 if VPN is connected and exit unless you have the "continue on error" option checked.


Basic Design: 
this uses NetworkInterface.NetworkInterfaceType Property described below
https://msdn.microsoft.com/en-us/library/system.net.networkinformation.networkinterface.networkinterfacetype(v=vs.110).aspx
It enumerates all network adapters in the system and looks for one with the Type of "Ppp" if it finds one the it reports VPN is connected.




