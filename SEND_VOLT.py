# Assuming you have a 2D array of RGB values (e.g., a list of lists)
# and you want to send voltages to an ESP8266 via UDP

import socket
import struct

# Define the IP address and port of the ESP8266
ESP8266_IP = "192.168.1.100"
ESP8266_PORT = 12345

# Create a UDP socket
udp_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# Define the 2D array of RGB values (e.g., 3x3 grid)
rgb_values = [
    [(255, 0, 0), (0, 255, 0), (0, 0, 255)],
    [(255, 255, 0), (255, 0, 255), (0, 255, 255)],
    [(128, 128, 128), (64, 64, 64), (0, 0, 0)]
]

# Iterate over the 2D array and send voltages
for row in rgb_values:
    for r, g, b in row:
        # Convert RGB values to voltages (assuming 0-255 range)
        voltage_r = r / 255.0 * 3.3
        voltage_g = g / 255.0 * 3.3
        voltage_b = b / 255.0 * 3.3

        # Pack the voltages into a binary format (e.g., 3 floats)
        payload = struct.pack("!fff", voltage_r, voltage_g, voltage_b)

        # Send the UDP packet to the ESP8266
        udp_socket.sendto(payload, (ESP8266_IP, ESP8266_PORT))

# Close the socket
udp_socket.close()

print("Voltages sent to ESP8266 via UDP.")
