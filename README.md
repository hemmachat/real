# REA Coding Test
## To Run The Application
You need to install .NET Core 2.1. (https://www.microsoft.com/net/download)
Once you have it installed, go to the source code directory and run `dotnet run --project Robot`. The application is an interactive console application that will receive user input commands e.g. PLACE, MOVE, LEFT, REPORT, etc. 
To exit, type `q` or submit an empty line to the console.

You can also run test cases by using the command `dotnet test RobotTest`

## Rooms for improvement
There is some rooms for improvement such as using Command design pattern to decouple (a bit) between the commands and the robot and will give some flexibility for creating new commands in the future.
