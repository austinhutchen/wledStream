using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Define the IP address 
        string ipAddress = "192.168.1.100"; 
        int port = 21324; // Default UDP port for WLED
        
        // Create a UDP client
        using (UdpClient udpClient = new UdpClient())
        {
            try
            {
                // Encode the color command as a byte array
                byte[] colorCommand = Encoding.ASCII.GetBytes("{\"on\":true,\"seg\":[{\"col\":[[255,0,0],[0,255,0],[0,0,255]]}]}");

                // Send the UDP packet to the WLED ESP Device
                udpClient.Send(colorCommand, colorCommand.Length, ipAddress, port);
                
                Console.WriteLine("Color command sent successfully to WLED device.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending UDP packet: {ex.Message}");
            }
        }
    }
}
