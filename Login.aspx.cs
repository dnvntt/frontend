using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Npgsql;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=zulu;");
        connection.Open();
        List<Object> lstSelect = new List<Object>();
        String username = Login1.UserName;
        String password = Login1.Password;
        string SQL = "SELECT * FROM account where username ='" + username + "'  and password='" + password + "';";

        NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
        NpgsqlDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                lstSelect.Add(dr[i]);
            }
        }

        connection.Close();
        if (lstSelect.Count > 1)
        {
            Session["account"] = lstSelect[1].ToString();
            Session["folowerId"] = lstSelect[2].ToString();
            Session["username"] = lstSelect[3].ToString();
            Session["password"] = lstSelect[4].ToString();
            Session["name"] = lstSelect[5].ToString();
            Session["riskFactor"] = lstSelect[0];

            Response.Redirect(Login1.DestinationPageUrl);       // + "?field1=" + lstSelect[3].ToString());
        }

    }
}
