from requests import Session
from signalr import Connection

with Session() as session:
    #create a connection
    connection = Connection("http://54.179.139.55:8090/chat", session)
    print("Connection Stablished!")

    #get chat hub
    chat = connection.register_hub('chat')
    print("Hub Registered!")

    #start a connection
    connection.start()
    print("Connection Started!")
    #create new chat message handler
    # def print_received_message(name, message):
    #     print(name + 'says' + message)

    # #create error handler
    # def print_error(error):
    #     print('error: ', error)

    # #receive new chat messages from the hub
    # chat.client.on('broadcastMessage', print_received_message)

    # #process errors
    # connection.error += print_error

    #start connection, optionally can be connection.start()
    with connection:

        #post new message
        chat.server.invoke('broadcastMessage', 'Python is here')

        #post another message
        chat.server.invoke('SendMessage', 'Bye-bye!')

        #wait a second before exit
        connection.wait(1)