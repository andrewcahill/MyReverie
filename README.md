[![Build status](https://aviddeveloper.visualstudio.com/My%20Reverie/_apis/build/status/My%20Reverie-CI)](https://aviddeveloper.visualstudio.com/My%20Reverie/_build/latest?definitionId=2)

# MyReverie

The idea of this repository is to build a goal tracking solution. The goals are could be considered a wishlist of things you would like to acheive by a certain time such as travel to a certain desitnation, achieve a certain qualification, purchase a property, start up a business etc. The set of goals are entirely up to the user - this solution is merely a tool to help users acheive these goals by allowing them to set timelines, reminders, progress trackers, motivational quotations etc.

I plan to outline the features under the Projects Tab of GitHub.

In building this solution it enables me to learn and use various new technologies, some technologies I will be looking to incorporate are Asp.Net Core, Swagger, Docker, xUnit.Net and EF Core, Docker, AI/ML, Azure etc.

I will be building this solution with clean architecture principles in mind as I go. 

I will blog about certain features I implement in my blog : http://www.aviddeveloper.com.

# Running the application

## Pre-requisites
We would need the following installed in our system before we start with setting up the project in local machine.
1. Git - As we are using Git for source control, we will want to install this to easily interact with out repo. You can download from : https://git-scm.com/downloads.
2. .Net Core SDK - As we are building a .Net Core application we will want to have the .Net Core SDK installed, you can download it from here : https://www.microsoft.com/net/download

## Local Setup
1. Clone this repository onto your local system and change to the directory.
   
```sh
git clone https://github.com/andrewcahill/MyReverie.git
cd MyReverie/
```

2. Run the solution:

   In order to run the solution you will need to ensure that both the web project as well as the API project are set to startup, for        development/testing simple set the solution to start multiple project under Solution Properties.

## To Note

The application is using an In Memory database as its data store for now, however this will most likely change in the near future to something more persistent like sqllite, SQL Server etc. 

If you would like to change to a SQL Server there a a few steps to perform
1) You will need to run its Entity Framework Core migrations.
2) Update the startup class -> uncomment the SQL Server section and comment the In-Memory section
3) Ensure your connection string in `appsettings.json` points to your SQL Server instance.

Feel free to suggest improvements, features etc.
