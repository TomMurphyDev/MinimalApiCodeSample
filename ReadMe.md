# Minimal Apis in dotnet core
 A .NET Core web API uses an approach that uses controllers. The idea is to have a controller class method, which represents various HTTP verbs, perform an operation to complete a specific task. For example, GetProducts() would return products by using GET as an HTTP verb.

 But in a minimal Api there are a few subtle differences...

- In a traditional .net core api Statup.cs would be pivotal to registering your services and configuration/routes or CORS here we will just use the Progam.cs

- In Net 6 we can use top level statements to reduce the need for using statements and boilerplate code to start our program.

```c#
//Classic Style
using System;

  namespace Application
  {
      class Program
      {
          static void Main(string[] args)
          {
              Console.WriteLine("Hello World!");
          }
      }
  } 
//in our minimal API just this one line below
Console.WriteLine("Hello World!"); 
```
So lets start builing our app

```c#
//lets run the below to set up our app
dotnet new web -o ItemStore -f net6.0
```

## Routes and Commands

| Http Verb | Description |
| --- | ----------- |
| Get | Query based in URL retrieves data |
| Post | Create create - payload in body |
| Put | Update resource  |
| Patch | Partial Update resource |
| Delete | Delete Update resource  |


These can easily be mapped in comands like these 
```c#
app.MapGet("/", () => "Hello World!");
app.MapGet("/items/{id}", (int id) => ItemDB.GetItem(id));
app.MapGet("/items", () => ItemDB.GetItems());
```