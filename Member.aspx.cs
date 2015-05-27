using System;
using System.Collections;
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
public partial class member : System.Web.UI.Page
{
    String username ;
    String password ;
    String followeeId;
    int riskFactor;
    NpgsqlConnection connection;
    List<Trader> listTraderFollow;
    DataSet DS;
    protected void Page_Load(object sender, EventArgs e)
    {
        connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=zulu;");
        String name = (string)(Session["name"]);
        username = (string)(Session["username"]);  
        password = (string)(Session["password"]);
        followeeId = (string)(Session["account"]);
        riskFactor = (int)(Session["riskFactor"]);
        
        if (!IsPostBack)
        {
            RadSlider1.Value = riskFactor;
        }

        string SQL = "select b.traderid,b.username,b.numberfollow,b.monneyfollow,a.moneyAllocate,a.maxOpen   from following a, trader b  where id= '" + followeeId + "' and a.traderId = b.traderId; ";
        connection.Open();
        DS = new DataSet("DS1");
        NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
        DA.SelectCommand = new NpgsqlCommand(SQL, connection);
        DA.Fill(DS, "DS1");
        GridView1.DataSource = DS;
        GridView1.DataBind();
        DataTable dt = DS.Tables[0];
        listTraderFollow = dt.AsEnumerable()
                          .Select(row => new Trader(row["traderid"].ToString().Trim(), row["username"].ToString().Trim(), row["numberfollow"].ToString(), row["monneyfollow"].ToString()))
                          .ToList();

        Label1.Text = name;
        connection.Close();
    }

    protected void RadSlider1_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            string risk_value = (sender as Telerik.Web.UI.RadSlider).Value.ToString();
            connection.Open();
            string SQL = "update account set risk_factor =" + risk_value + " where username ='" + username + "';";
            NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("FindTrader.aspx", true);
    }

    protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Unfollow")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string traderid = row.Cells[0].Text.Trim();
            string money = row.Cells[2].Text.Trim();

            connection.Open();
            string SQL = "delete from  following where id ='" + followeeId.Trim() + "' and  traderid ='" + traderid + "';";
            NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
            command.ExecuteNonQuery();

            Trader traderFollow = listTraderFollow.Find(r => r.traderid == traderid);

            int numberOfFollow = Convert.ToInt32(traderFollow.numberfollow) - 1;
            double moneyFollow = Convert.ToDouble(traderFollow.monneyfollow) - Convert.ToDouble(money);
            SQL = "update  trader set numberfollow= " + numberOfFollow + " , monneyfollow = " + moneyFollow + " where traderid='" + traderid + "';";
            command = new NpgsqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            connection.Close();

            //update gridview1
            DS.Tables[0].Rows[index].Delete();
            GridView1.DataSource = DS;
            GridView1.DataBind();
        }
    }

}
