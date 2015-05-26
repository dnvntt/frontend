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

public partial class FindTrader : System.Web.UI.Page
{
    String followerId;
    NpgsqlConnection connection;
    List<Trader> listTrader;

    protected void Page_Load(object sender, EventArgs e)
    {
        connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123456;Database=zulu;");
        String name = (string)(Session["name"]);
        followerId = (string)(Session["folowerId"]);

        string SQL = "select *  from  trader order by numberfollow desc; ";
        connection.Open();
        DataSet DS = new DataSet("DS1");
        NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
        DA.SelectCommand = new NpgsqlCommand(SQL, connection);
        DA.Fill(DS, "DS1");
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = DS;
            GridView1.DataBind();
        }
        DataTable dt = DS.Tables[0];
        listTrader = dt.AsEnumerable()
                          .Select(row => new Trader(row["traderid"].ToString().Trim(), row["username"].ToString().Trim(), row["numberfollow"].ToString(), row["monneyfollow"].ToString()))
                          .ToList();
        connection.Close();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Follow")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string traderid = row.Cells[0].Text.Trim();
            connection.Open();
        
            String money =  ((TextBox) row.FindControl("txbox1")).Text;
            String maxOpen = ((TextBox)row.FindControl("txbox2")).Text;

            string SQL = "insert into  follower (followerid,traderid,moneyallocate,maxopen) VALUES (" + followerId.Trim() + ",'" + traderid + "'," + money + "," + maxOpen + ");";
            NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            
            Trader traderFollow = listTrader.Find(r => r.traderid == traderid);

            int numberOfFollow = Convert.ToInt32(traderFollow.numberfollow) +1;
            double moneyFollow = Convert.ToDouble(traderFollow.monneyfollow) + Convert.ToDouble(money);
            SQL = "update  trader set numberfollow= " + numberOfFollow + " , monneyfollow = " + moneyFollow + " where traderid='"+ traderid +"';";
            command = new NpgsqlCommand(SQL, connection);
            command.ExecuteNonQuery();
            connection.Close();
            
            Server.Transfer("Member.aspx", true);
        }
    }
}
