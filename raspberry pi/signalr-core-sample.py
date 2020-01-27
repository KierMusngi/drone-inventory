# import logging
import sys
from signalrcore.hub_connection_builder import HubConnectionBuilder

server_url = "ws://54.179.139.55:8090/chat"
print("Server set to: " + server_url)

# add this if you want logs

# hub_connection = HubConnectionBuilder()\
#     .with_url(server_url)\
#     .configure_logging(logging.DEBUG)\
#     .with_automatic_reconnect({
#         "type": "raw",
#         "keep_alive_interval": 10,
#         "reconnect_interval": 5,
#         "max_attempts": 5
#     }).build()

hub_connection = HubConnectionBuilder()\
    .with_url(server_url)\
    .with_automatic_reconnect({
        "type": "raw",
        "keep_alive_interval": 10,
        "reconnect_interval": 5,
        "max_attempts": 5
    }).build()

print("Hub connection built.")

def print_me(data):
    print(str(data[0]) + ": " + str(data[1]))

hub_connection.on("broadcastMessage", print_me)

hub_connection.start()
print("Hub connection started.")

message = ""

while message != "exit()":
    message = raw_input('')
    user = "Raspberry Pi"
    try:
        hub_connection.send("Send", [user, message])
    except:
        print("Something went wrong.")

hub_connection.stop()
print("Connection stopped")

sys.exit(0)