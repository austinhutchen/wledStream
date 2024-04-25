using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class WLEDInterface
{
    private readonly string ipAddress="192.168.1.0";
    private readonly int port;

    public WLEDInterface(string ipAddress, int port)
    {
        this.ipAddress = ipAddress;
        this.port = port;
    }

    public void SetColor(byte red, byte green, byte blue)
    {
        string colorCommand = $"{{\"on\":true,\"seg\":[{{\"col\":[[{red},{green},{blue}]]}}]}}";
        SendCommand(colorCommand);
    }

    public void SetBrightness(byte brightness)
    {
        string brightnessCommand = $"{{\"bri\":{brightness}}}";
        SendCommand(brightnessCommand);
    }

    public void SetEffect(string effect)
    {
        string effectCommand = $"{{\"fx\":\"{effect}\"}}";
        SendCommand(effectCommand);
    }

    private void SendCommand(string command)
    {
        using (UdpClient udpClient = new UdpClient())
        {
            try
            {
                byte[] commandBytes = Encoding.ASCII.GetBytes(command);
                udpClient.Send(commandBytes, commandBytes.Length, ipAddress, port);
                Console.WriteLine($"Command '{command}' sent successfully to WLED device.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending command: {ex.Message}");
            }
        }
    }
}
