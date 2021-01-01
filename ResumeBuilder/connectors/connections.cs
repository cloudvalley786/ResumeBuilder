using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for connections
/// </summary>
public class connections
{
    public static string ConnectionStringCLOVA = ConfigurationManager.ConnectionStrings["CLOVA_SQL"].ConnectionString;

}
