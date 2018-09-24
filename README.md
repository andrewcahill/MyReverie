[![Build status](https://dev.azure.com/aviddeveloper/My%20Reverie/_apis/build/status/My%20Reverie-ASP.NET%20Core-CI%20(1))](https://dev.azure.com/aviddeveloper/My%20Reverie/_build/latest?definitionId=2)

# MyReverie

The idea of this repository is to build a goal tracking solution. The goals are could be considered a wishlist of things you would like to acheive by a certain time such as travel to a certain desitnation, acheive a certain qualification, purchase a property, start up a business etc. The set are entirely up to the user - this solution is merely a tool to help users acheive these goals by allowing them to set timelines, reminders, progress trackers, motivational quotations etc.

I plan to outline the features under the Projects Tab of GitHub.

In building this solution it enables me to learn and use various new technologies, some technologies I will be looking to incorporate are Asp.Net Core, Swagger, Docker,  xUnit.Net and EF Core, Docker, AI/ML, Azure etc.

I will be building this solution with clean architecture principles in mind as I go. 

I will blog about certain features I implement at http://www.aviddeveloper.com.

# Running the application

The application is using and In Memory database as its data store  for simplicity, however there is capability to switch to SQL Server. If you would like to change to a SQL Server there a a few steps to perform
1) You will need to run its Entity Framework Core migrations.
2) Update the startup class -> uncomment the SQL Server section and comment the In-Memory section
3) Ensure your connection string in `appsettings.json` points to your SQL Server instance.

In order to run the solution you will need to ensure the web application as well as the API project as startup, for development/testing simple set the solution to start multiple project under Solution Properties.

Feel free to suggest improvements, features etc.
