# Integrate Tableau with ASP.Net
Integrate Tableau with ASP.Net MVC5 

The project aim is to provide a simple integration between Tableau API and asp.net mvc 5 framework.
The idea is to provide a Single sign on soloution so the user does not need to login every time they want to use the tableau. 

Before start the development you have to consider following points : 

1- The Tableau session will timeout after 240 mins by deault https://community.tableau.com/thread/201438

2- The ASP.Net Identity token is valid for 30 min by default (can set in Startup.Auth.cs)

3- The tableaue token pass through header using "X-Tableau-Auth" key

How the soloution works : 

By each login attemp tableau server provide a token key value object. each object has limited time life span, and after expiray server will throw expired token error. 

The soloution store the token inside both of local storage and cookies so you may disable either of method based on ur reqirments. 



