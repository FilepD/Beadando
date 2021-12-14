using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Termékek : System.Web.UI.Page
{
    private List<int> id = new List<int>();
    private List<string> megnevezes = new List<string>();
    private List<int> suly = new List<int>();
    private List<double> ar = new List<double>();

    protected void Page_Load(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        try
        {
            SqlDataAdapter sqlalk = new SqlDataAdapter("Select * From alkatrészek", con);
            DataTable tablealk = new DataTable();
            sqlalk.Fill(tablealk);
        }
        catch (Exception)
        {
            con.Open();
            SqlCommand cmdalk = new SqlCommand("CREATE TABLE [dbo].[alkatrészek] ([id] INT IDENTITY(1, 1) NOT NULL, [megnevezés] NCHAR(100) NOT NULL, [súly] INT NOT NULL, [ár] INT NOT NULL, CONSTRAINT[PK_alkatrészek] PRIMARY KEY CLUSTERED([id] ASC)); ", con);
            cmdalk.ExecuteNonQuery();
        } //alktrészek

        try
        {
            SqlDataAdapter sqlterm = new SqlDataAdapter("Select * From termékek", con);
            DataTable tableterm = new DataTable();
            sqlterm.Fill(tableterm);
        }
        catch (Exception)
        {
            con.Open();
            SqlCommand cmdterm = new SqlCommand("CREATE TABLE [dbo].[termékek] ([id] INT IDENTITY(1, 1) NOT NULL, [megnevezés] NCHAR(100) NOT NULL, [súly] INT NOT NULL, [ár] INT NOT NULL, CONSTRAINT[PK_termékek] PRIMARY KEY CLUSTERED([id] ASC)); ", con);
            cmdterm.ExecuteNonQuery();
        } //termékek

        try //összekötő
        {
            SqlDataAdapter sqlköt = new SqlDataAdapter("Select * From összekötő", con);
            DataTable tableköt = new DataTable();
            sqlköt.Fill(tableköt);
        }
        catch (Exception)
        {
            con.Open();
            SqlCommand cmdköt = new SqlCommand("CREATE TABLE [dbo].[összekötő] ([id] INT IDENTITY(1, 1) NOT NULL, [tid] INT NOT NULL, [aid] INT NOT NULL,  [mennyiség] INT NOT NULL, CONSTRAINT[PK_összekötő] PRIMARY KEY CLUSTERED([id] ASC), CONSTRAINT[FK_összekötő_alkatrészek] FOREIGN KEY([aid]) REFERENCES[dbo].[alkatrészek]([id]), CONSTRAINT[FK_összekötő_termékek] FOREIGN KEY([tid]) REFERENCES[dbo].[termékek]([id]));", con);
            cmdköt.ExecuteNonQuery();
        } //összekötő

        SqlDataAdapter sqla = new SqlDataAdapter("Select * From termékek", con);
        DataTable table = new DataTable();
        sqla.Fill(table);
        foreach (DataRow r in table.Rows)
        {
            id.Add(Convert.ToInt32(r["id"]));
            megnevezes.Add(Convert.ToString(r["megnevezés"]));
            suly.Add(Convert.ToInt32(r["súly"]));
            ar.Add(Convert.ToDouble(r["ár"]));
        }
        TableRow row;
        TableCell cell;
        for (int i = 0; i < id.Count; i++)
        {
            row = new TableRow();

            cell = new TableCell();
            cell.Text = Convert.ToString(id[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = megnevezes[i];
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = Convert.ToString(suly[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = Convert.ToString(ar[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }
    }

    protected void btnHozzáad_Click(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (Megnevezésbev.Text != "")
        {
            try
            {
            SqlCommand cmd = new SqlCommand("insert into termékek (megnevezés, súly, ár) values (@megnevezés, @súly, @ár)", con);
                        cmd.Parameters.AddWithValue("@megnevezés", Megnevezésbev.Text);
                        cmd.Parameters.AddWithValue("@súly", 0);
                        cmd.Parameters.AddWithValue("@ár", 0);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect(Request.RawUrl);
                        IDbev.BackColor = System.Drawing.Color.White;
                        Megnevezésbev.BackColor = System.Drawing.Color.White;
                        //Súlybev.BackColor = System.Drawing.Color.White;
                        //Árbev.BackColor = System.Drawing.Color.White;
            }
            catch (Exception)
            {
                ErrorLabel.Text = "A súly és az ár értéke csak szám lehet!";
                ErrorLabel.Visible = true;
            }            
        }
        else
        {
            IDbev.BackColor = System.Drawing.Color.White;
            Megnevezésbev.BackColor = System.Drawing.Color.Yellow;
            ErrorLabel.Visible = true;
            ErrorLabel.Text = "A művelet elvégzéséhez írj a szükséges sorba!";
        }
    }

    protected void btnMódosít_Click(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (IDbev.Text != "" && Megnevezésbev.Text != "")
        {
            try
            {
            SqlCommand cmd = new SqlCommand("update termékek set megnevezés =@megnevezés where id = @id", con);
                        cmd.Parameters.AddWithValue("@megnevezés", Megnevezésbev.Text);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(IDbev.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect(Request.RawUrl);
                        IDbev.BackColor = System.Drawing.Color.White;
                        Megnevezésbev.BackColor = System.Drawing.Color.White;
            }
            catch (Exception)
            {
                ErrorLabel.Text = "A súly és az ár értéke csak szám lehet!";
                ErrorLabel.Visible = true;
            }
            
        }else
        {
            ErrorLabel.Visible = true;
            ErrorLabel.Text = "A művelet elvégzéséhez írj a szükséges sorba!";
            IDbev.BackColor = System.Drawing.Color.Yellow;
            Megnevezésbev.BackColor = System.Drawing.Color.Yellow;
        }

    }

    protected void btnTöröl_Click(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (IDbev.Text != "")
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete From termékek Where id =" + Convert.ToInt32(IDbev.Text) + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
                IDbev.BackColor = System.Drawing.Color.White;
                Megnevezésbev.BackColor = System.Drawing.Color.White;
            }
            catch (Exception)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "A megadott id-jű terméknek van alkatrésze!";
            }
        }
        else
        {
            ErrorLabel.Visible = true;
            ErrorLabel.Text = "A művelet elvégzéséhez töltsd ki az ID mezőt!";
            IDbev.BackColor = System.Drawing.Color.Yellow;
            Megnevezésbev.BackColor = System.Drawing.Color.White;
        }
    }
}