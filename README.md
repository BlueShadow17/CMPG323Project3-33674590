# CMPG323Project3-33674590

# Table of Contents
 -[Introduction](#Introduction)
 
 -[Prerequisites](#prerequisites)
 
 -[Installation](#installation)
 
 -[Usage](#usage)
 
-[Endpoints](#endpoints)

-[Refrence List](#Refrence)
    
## Introduction
In this project tha database and code of a web application was given to me. All frontwork was completed but was ask to look at the backend. Firstly was to optimize the code and implement the 2 tiers that was asked. The first was to create repositories that stored what the controller must do. This resulted in many duplicate code. So a generic repository was created in tier 2. With this repository it stored al the methods that are found in all the controllers. Using the interface class for each controller and the generic repository, the dependency injections were done to insure there is no duplication code and that the code is more readable. Using OOP(Object orientated Programming) to achieve tier 2.

The project link is below:

[Link]( https://ecopowerlogistics20230920003952.azurewebsites.net/)


Click below for the Azure profile link:


[Link]( https://portal.azure.com/#@nwuac.onmicrosoft.com/resource/subscriptions/7a703948-d81e-4731-917f-de4fcf2080a6/resourceGroups/rgP2App/overview](https://portal.azure.com/?Microsoft_Azure_Education_correlationId=b7ecfcc0-eea4-402d-a37f-9df854253939&Microsoft_Azure_Education_newA4E=true&Microsoft_Azure_Education_asoSubGuid=7a703948-d81e-4731-917f-de4fcf2080a6#@nwuac.onmicrosoft.com/resource/subscriptions/7a703948-d81e-4731-917f-de4fcf2080a6/resourceGroups/rgP2App/overview))

## Prerequisites

List any prerequisites that users need to have installed before they can use your API. For example:
-Download packages from NuGet packages
1. Microsoft.EntityFrameworkCore  V 6.0.21
2. Microsoft.EntityFrameworkCore.Design V 6.0.21
3. Microsoft.EntityFrameworkCore.SqlServe V 6.0.21
4. Microsoft.EntityFrameworkCore.Tools V 6.0.21

## Installation

Provide step-by-step instructions for users to install and set up in visual studio. This could include:

1. Clone this repository.
2. Open the solution in visual studio.
3. Build the solution.
4. Run the application.

## Configure Database Connection String
The database is provided for us and is a online database. The appsettings.json and bin file is not inclueded in github.

## Usage
  Using the endpoint you will be able to see each root and path for the methods that was implemented to show how the database data is used for the project. See endpoints below:
## Endpoints
1. Customers
   
   -GET: Customers
   
   -GET: Customers/Details/5
   
   -GET: Customers/Create

   -POST: Customers/Create

   -GET: Customers/Edit/5

   -POST: Customers/Edit/5

   -GET: Customers/Delete/5

   -POST: Customers/Delete/5
   

2. Orders

   -GET: Orders
   
   -GET: Orders/Details/5
   
   -GET: Orders/Create

   -POST: Orders/Create

   -GET: Orders/Edit/5

   -POST: Orders/Edit/5

   -GET: Orders/Delete/5

   -POST: Orders/Delete/5

3. Products

   -GET: Products
   
   -GET: Products/Details/5
   
   -GET: Products/Create

   -POST: Products/Create

   -GET: Products/Edit/5

   -POST: Products/Edit/5

   -GET: Products/Delete/5

   -POST: Products/Delete/5

## Refrence List
The resourses used in the project:
From the word doc provided and other sourses.
  1. Microsoft. (2023). ASP.NET Core Web Application Learning Path. [Link](https://learn.microsoft.com/en-us/training/paths/aspnet-core-web-app/)
  2. Microsoft. (2023). ASP.NET MVC Overview.  [Link](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/overview/asp-net-mvc-overview/)
  3. Microsoft. (2023). Secure ASP.NET Core Identity. [Link](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity/)
  4. C# Corner. (2023). Design Patterns in .NET. [Link](https://www.c-sharpcorner.com/UploadFile/bd5be5/design-patterns-in-net/)
  5. C# Corner. (2012). Architectural Patterns in .NET. [Link](https://www.c-sharpcorner.com/uploadfile/babu_2082/architectural-patterns-in-net/)
  6. Microsoft. (2021). CS0535 Compiler Error in C#. [Link](https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0535)
  7. Microsoft. (2021). CS1061 Compiler Error in C#. [Link](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs1061)
  8. Microsoft. (2021). CS0029 Compiler Error in C#. [Link](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0029)
  9. Microsoft. (2021). CS1104 Compiler Error in C#. [Link](https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1104)
 10. Microsoft. (2021). CS0738 Compiler Error in C#. [Link](https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0738)







