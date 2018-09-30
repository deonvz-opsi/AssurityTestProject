# AssurityTestProject
API testing project

**Requirement:**
- Automated test that verifies three acceptance criteria:
1. Name = "Carbon credits"
2. CanRelist = true
3. The Promotions element with Name = "Gallery" has a Description that contains the text "2x large image"

**Development environment**
- This assignment was coded in Visual Studio 2017 community edition.

**Solution architecture**
- A solution called “AssurityMSTestProject” was created that contains two Projects:
1. ProductConsoleApp
2. AssurityMsTestProject

- ProductConsoleApp containts the Main method as the entrypoint for the C# console application. It contains the “Program” class that contains three methods:
1. GetCanRelistStatus()
  This method returns the boolean status of CanRelist parameter in the Category JSON object.
2. GetCategory()
  This method returns a string representation of the Category.
3. GetPromotionList()
  This method returns a List of JSON Promotion objects contained in Category.

- This project also contains classes for creating JSON objects for Category, Promotion, Fees, ListingFeeTier. The last three are child items of Category.
These JSON objects are populated by the three methods as mentioned above. Creation of these objects are required to prevent false positives during testing. Full JSON objects were created for completeness and to allow for easy addition of test criteria.

**Test Methods**
- As per the task set out in the assignment, the first test method verifies the three test criteria. 
I strongly advise against combining three acceptance criteria in to an automated test as per the assignment. For this reason I have written additional test methods. One for each of the acceptance criteria. 

**References:**
- Call a Web API From a .NET Client (C#)
https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
- For the creation of JSON objects
http://json2csharp.com/
- Microsoft .NET Documentation
https://docs.microsoft.com/en-us/dotnet/
- Stackoverflow for general answers to questions
https://stackoverflow.com/questions


