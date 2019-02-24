# Geek Hunters

You are working at IT-recruiting agency "Geek Hunters". Your employer asked you to implement Geek Registration System
(GRS). 

Using GRS a recruitment agent should be able to:
  - register a new candidate:
     - first name / last name
     - select technologies candidate has experience in from the predefined list 
  - view all candidates
  - filter candidates by technology

Another developer has partially designed and implemented a
SQLite DB for this project - GeekHunters.sqlite. Feel free to modify a structure to
your needs.

Please fork the project and commit your source code (please do not archive it :) ).

You are free to use **ANY** .net web frameworks you need - aspnet / webapi / spa etc. However, if you decide to go with third
party package manager or dev tool - don't forget to mention them in the
README.md of your fork.

Good luck!

P.S: And unit tests! We love unit tests!

There is 2 Applications in this solution:
i. GeekHunters.Api, a webapi application that provide registration services by using sqlite database.
ii.GeekHunters.App, a ASP.Net Core MVC Front End application that uses GeekHunters.Api.

In GeekHunters.Api, 3rd party tools that are used are:
1. AutoMapper, mapping between db Entities and ViewModal. In some cases, it maybe necessary not to exposed every property in the
   db entities.
2. EntityFramework Core for SQLite.
3. Swashbuckle.AspNetCore, swagger api/doc to help in debugging.

In GeekHunters.App, 3rd party tools that are used are:
1. RestSharp, a simple and lightweight REST and HTTP API Client for .NET, used to data comms with webapi.

Lastly, NUnit Test are used. Unit Testing is perform on the Service Layer. That is where the business logic is.
Repository layer is being mock by using objects to perform the test.

