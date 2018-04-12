# Integrate Tableau with ASP.Net MVC5 
The project aim is to provide a simple integration between Tableau API and asp.net mvc 5 framework.
The idea is to provide a Single sign in soloution so the user does not need to login for each request. 
This soloution acting as a middleware between client UI and Tableau server. the client consume the middleware API to communicate with the Tableau server, **do not procced with this soloution if you are looking for a direct connection from java script to Tableau server**.
## Over All View
### Before start the development : 

1- [By deault the Tableau setting for an idle user session timeout is 240 minutes](http://kb.tableau.com/articles/howto/changing-the-user-session-timeout)

2- By default the ASP.Net mvc5 Identity token is valid for 30 min (can set in Startup.Auth.cs)

3- The Tableau token should pass through header using "X-Tableau-Auth" header key. 

4- you can fin all the API reference [here](https://onlinehelp.tableau.com/current/api/rest_api/en-us/help.htm#REST/rest_api_ref.htm#API_Reference%3FTocPath%3DAPI%2520Reference%7C_____0).

## Authentication

Performing each login attemp will force the Tableau server to provide a token key value object. Each object has limited time life span, and after expiray server will throw expired token error. 

The soloution store the token inside both **local storage and cookies**. You can disable either of method based on ur reqirments. we use a 3rd party java script library to store the Token into the cookie.

