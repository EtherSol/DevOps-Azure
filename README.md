# DevOps-Azure

In this project, I use xUnit and Selenium extentions to do Unit Testings 
and UITesting. The VSCode Environment was set to satisfy C# Testing and Debugs. 

Files:

CreditCards.csproj in Azure/CreditCards/CreditCards.csproject creates a website to be tested on.The .csproj file is where you run the project to display the website.


CreditCardWebAppShould.cs and CreditCardApplicationShould.cs in Azure/CreditCards.UITests/*
are automated tests with C# and Selenium. In order to run the tests, extensions are required for VSCode to run the tests. Dependencies are .Net Core Test Explorer, .NET v2.1^, Selenium is needed. 


DemoHelper.cs's function in Azure/CreditCards.UITests/DemoHelper.cs is called throughout the test code to delay the automated test actions.



<h1>Notes<h1>

<h3> Which Test Scenarios Should You Automate? </h3>

- Follow the Money
- Risk focused Strategy 
    - Legal Implications/ Requirements
    - Reputation of Organization
    - Data Corruption
    - Security/ Privacy Protection
- Features most-used by users
- Unique/ differentiating features

- Amount of Lower Level Test Coverage
- Total Number of features/pages
- At least one "Smoke Test" for every page
