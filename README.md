# Integrate Tableau REST API with ASP.Net MVC5 
The project aim is to provide a simple integration between Tableau API and asp.net mvc 5 framework.
Tabluea API is use for automation only, **you can not use the API token for the VIZ**, if you want to use SSI for VIZ please study [Trusted Auth](http://onlinehelp.tableau.com/current/server/en-us/trusted_auth.htm)
The idea is to provide a Single sign in soloution so the user does not need to login for each Tableau Rest API requests. 
This soloution acting as a middleware between client UI and Tableau server. the client consume the middleware API to communicate with the Tableau server, **do not procced with this soloution if you are looking for a direct connection from java script to Tableau server**.
## Over All View
### Before start the development : 

1- [By deault the Tableau setting for an idle user session timeout is 240 minutes](http://kb.tableau.com/articles/howto/changing-the-user-session-timeout)

2- By default the ASP.Net mvc5 Identity token is valid for 30 min (can set in Startup.Auth.cs)

3- The Tableau token should pass through header using "X-Tableau-Auth" header key. 

4- you can find all of the API reference [here](https://onlinehelp.tableau.com/current/api/rest_api/en-us/help.htm#REST/rest_api_ref.htm#API_Reference%3FTocPath%3DAPI%2520Reference%7C_____0).

## Configuration 

Update the Tableau server url in the TableauHttpClientConfig.cs on App_Start folder 

`` client.BaseAddress = new Uri("http://<ServerURL:port number>/api/"); ``

Example : 

You can use

`` client.BaseAddress = new Uri("http://tableau:8000/api/"); ``

or

`` client.BaseAddress = new Uri("http://192.168.0.108:8000/api/"); ``

If you want to use VIZ Make sure the [clickjack protection](http://onlinehelp.tableau.com/current/server/en-us/clickjack_protection.htm) is disabled.

## Authentication

Performing each login attemp will force the Tableau server to provide a token key value object. Each object has limited time life span, and after expiray server will throw expired token error. 

The soloution store the token inside both **local storage and cookies**. You can disable either of method based on ur reqirments. we use a [3rd party java script library](https://developer.mozilla.org/en-US/docs/Web/API/Document/cookie/Simple_document.cookie_framework) to store the Token into the cookie.


## Limitations 

1- The Tabluea Rest API does not provide change password request for a normal user, so we can not change the password by a single request. the user need to change the password 2 times (.Net and tableau).  
2- Aassume you are **not using 2 factor auth** after register a new user the user navigates to index page, you need to update the token in register view too. 




