using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace VPN_Check
{
    class Program
    {
        private const int ERROR_VPN_Connected = 0xA0;
        static void Main(string[] args)
        {
            string macType = string.Empty;
            int VPN_count = 0;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                var temptype = nic.NetworkInterfaceType.ToString();
                Console.WriteLine(
                    "Found MAC Address: " + nic.GetPhysicalAddress() +
                    " Type: " + temptype);

                if (temptype == "Ppp")
                {
                    Console.WriteLine("VPN adapter Found");
                    VPN_count++;
                }
        
            }
            Console.WriteLine("Search complete!");
            if (VPN_count != 0) 
            {
                Console.WriteLine("Error! VPN is connected");
                Environment.ExitCode = ERROR_VPN_Connected;
            }
            else
            {
                Console.WriteLine("VPN is not connected!");
            }

            //Console.WriteLine("Press ENTER to exit");
            //Console.ReadLine();
        
        }

    }

}




