# TCPServer
I watched these videos and based on it, I used for my project and I think it's really helpful.
https://www.youtube.com/c/TomWeiland
Here is the link what I watched

Before you use these, there are some steps you need to prepare.
1. ConsoleApp1/Program.cs line 21. : Check port number and max player.
Make sure you put the same port number in your client.
Don't forget to check ip address and they are in same network.

2. ConsoleApp1/ServerHandle.cs. : This is a place to handle data from Client.
And use ServerSend.cs to send message back to client.

3. ConsoleApp1/Packet.cs. : This is a place where to deal with enum value to distinguish which info you are sending back and forth.
Make sure you have same sequence in ServerPackets and ClientPackets.
Also you have to match it with Client Side as well.

4. ConsoleApp1/ServerSend.cs. : This is a place where actually get ready to send the info to clients.

