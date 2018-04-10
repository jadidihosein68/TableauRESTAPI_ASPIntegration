using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableauRestAPI.Models
{

    class ServerInfoAPIObject
    {
        public serverInfo serverInfo { get; set; }
        public string restApiVersion { get; set; }
    }

    public class productVersion
    {
        public string value { get; set; }
        public string build { get; set; }
    }
    
    public class serverInfo
    {
        public productVersion productVersion { get; set; }

    }
    
    public class CredentialTableau
    {
        public string name { get; set; }
        public string password { get; set; }
        public site site { get; set; }
        public string token { get; set; }
        public TableauUser user { get; set; }
        
    }

    public class TableauUser
    {
        public string id { get; set; }
    }

    public class postObject
    {
        public CredentialTableau credentials { get; set; }
        public postObject(CredentialTableau CredentialTableau)
        {
            credentials = CredentialTableau;
        }

    }

    public class site
    {
        public site(string contentUrl)
        {
            this.contentUrl = contentUrl;
        }

        public string id { get; set; }
        public string contentUrl { get; set; }
    }



}