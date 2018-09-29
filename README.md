# AssurityTestProject
API testing project

This assignment was coded in Visual Studio 2017 community addition.

A solution called “AssurityMSTestProject” was created that contains two Projects:
ProductConsoleApp and AssurityMsTestProject

ProductConsoleApp containts the Main method as the entrypoint for the C# console application. It contains the “Program” class that contains three methods:
- GetCanRelistStatus()
This method returns the boolean status of CanRelist parameter in the Category json object
- GetCategory()
This method returns a string representation of the Category
- GetPromotionList()
This method returns a List of JSON Promotion objects contained in Category

This project also contains classes for creating JSON objects for Category, Promotion, Fees, ListingFeeTier. The last three are child items of Category.
These JSON objects are populated by the three methods as mentioned above. Creation of these objects are required to prevent false positives during testing.

References:
Call a Web API From a .NET Client (C#)
https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
For the creation of JSON objects
http://json2csharp.com/
Microsoft .NET Documentation
https://docs.microsoft.com/en-us/dotnet/
Stackoverflow for general answers to questions
https://stackoverflow.com/questions


