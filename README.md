This is a .NET Core Project that includes API application for School Subjects Information System. The user interacts with the application through a
Console Application that you can download from this link: https://github.com/izabelaugrevska/damilah-challenge-console
In order to start this project, you need to have installed Visual Studio Code and SQL Server.

1. First clone the repository and navigate to the project folder:
    git clone https://github.com/izabelaugrevska/damilah-graduate-challenge.git
    cd damilah-graduate-challenge
    cd ssis
2. Update the database connection string in 'appsettings.json' with your Data Source and your Database (Initial Catalog)
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-ACHIVDA\\SQLEXPRESS01;Initial Catalog=subjects;Integrated Security=True;Connect Timeout=30;
                         Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
   }
3. Apply the database migrations:
   dotnet ef database update
4. Run the application with:
   dotnet run

To continue to interact with the application please download the Console Application from the repository link: https://github.com/izabelaugrevska/damilah-challenge-console
and follow the steps for setting up that application too.
   
