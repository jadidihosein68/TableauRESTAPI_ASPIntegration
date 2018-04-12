# Integrate Tableau with ASP.Net
Integrate Tableau with ASP.Net MVC5 

The project aim is to provide a simple integration between Tableau API and asp.net mvc 5 framework.
The idea is to provide a Single sign in soloution so the user does not need to login for each request. 
This soloution acting as a middleware between client UI and tabluea server. the client consume the middleware API to communicate with tabluea server, **do not procced with this soloution if you are looking for a direct connection from java script to tableau server**.

Before start the development you have to consider following points : 

1- [By deault the Tableau session will timeout after 240 mins](https://community.tableau.com/thread/201438)

2- By default the ASP.Net Identity token is valid for 30 min (can set in Startup.Auth.cs)

3- The tableaue token should pass through header using "X-Tableau-Auth" header key. 

How the soloution works : 

Performing each login attemp will force the tableau server to provide a token key value object. each object has limited time life span, and after expiray server will throw expired token error. 

The soloution store the token inside both local storage and cookies. You can disable either of method based on ur reqirments. 


