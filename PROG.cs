class Program
{
    static void Main(string[] args)
    {
        string ipAddress = "192.168.1.100"; // Replace with the actual IP address of your WLED device
        int port = 21324; // Default UDP port for WLED

        WLEDInterface wledInterface = new WLEDInterface(ipAddress, port);

        // Example usage:
        wledInterface.SetColor(255, 0, 0); // Set color to red
        wledInterface.SetBrightness(150); // Set brightness to 150
        wledInterface.SetEffect("Fire2012"); // Set effect to Fire2012
    }
}
