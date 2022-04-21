# Gabriel.Software.Users
alfasoft
how to run the application
## to run the application you must have the dotnet runtime installed in your computer https://dotnet.microsoft.com/en-us/download
## dotnet sdk is required to run via CLI 

# RUNNING VIA DOTNET CLI (REQUIREMENTS: DOTNET RUNTIME AND DOTNET SDK)
1. ##### using the cmd clone the project using git
#### How to clone a project: https://docs.github.com/pt/repositories/creating-and-managing-repositories/cloning-a-repository
2. ##### open the main folder: "Gabriel.Software.Users.Console"
3. ##### run the application with the dotnet cli: "dotnet run".
4. ##### in order to run this application you must pass a path from a text file from your PC.
5. ##### the command should looks like this: dotnet run "C:/User/file.txt" 
6. ##### The application will run and return the data







# RUNNING THE PUBLISHED VERSION - OPTION 1 (Requirements: DOTNET RUNTIME)
1. ##### download the application https://drive.google.com/file/d/1olNusmYkMXJgVa8KqdEkvvDtb-OUa1Tx/view?usp=sharing
2. ##### extract all the files for any folder in your computer
3. ##### open the cmd (command prompt) and access the same folder as the .exe file 
4. ##### run the exe via cmd passing the path of the text file.
5. Example:" gabriel.software.users.console "C:\Users\GABRI\Desktop\filepath\users.txt"  "


# RUNNING THE PUBLISHED VERSION - OPTION 2 (REQUIREMENTS: DOTNET RUNTIME AND DOTNET SDK)
1. ##### using the cmd (command prompt) clone the project using git
2. ##### open the root folder: ("Gabriel.Software.Users.Console")
3. ##### in the cmd write and run this command: dotnet publish --configuration Release
4. ##### inside the root folder ("Gabriel.Software.Users.Console") you're going to find a "bin" folder, click in it
5. ##### Open the "Release" folder
6. ##### Open the "net6.0" folder
7. ##### Open the publish folder via cmd (command prompt) and go to 4. step in "Running the publishd version - option 1"
