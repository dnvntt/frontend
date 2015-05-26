using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Trader
/// </summary>
public class Trader
{
    public string traderid { get; set; }
    public string username { get; set; }
    public string numberfollow { get; set; }
    public string monneyfollow { get; set; }
    public Trader(string id, string user, string number, string money)
    {
        traderid = id; username = user; numberfollow = number; monneyfollow = money;
    }
	 
}
