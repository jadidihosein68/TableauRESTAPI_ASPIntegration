# TableauRestAPI
Integrate Tableau with ASP.Net MVC5 

The project aim is to provide a simple integration between Tableau API and asp.net mvc 5 framework.
The idea is to provide a Single sign on soloution so the user does not need to login every time they want to use the tableau. 

Before start the development you have to consider following point : 

1- The Tableau session will timeout after 240 mins by deault https://community.tableau.com/thread/201438

2- The ASP.Net Identity token is valid for 30 min by default (can set in Startup.Auth.cs)







