using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Összeszerelő : System.Web.UI.Page
{
    private List<int> ida = new List<int>();
    private List<string> megnevezesa = new List<string>();
    private List<int> sulya = new List<int>();
    private List<int> ara = new List<int>();
    private List<int> idt = new List<int>();
    private List<string> megnevezest = new List<string>();
    private List<int> sulyt = new List<int>();
    private List<int> art = new List<int>();

    private List<int> ID = new List<int>();
    private List<int> termid = new List<int>();
    private List<int> alkid = new List<int>();
    private List<int> mennyiség = new List<int>();

    protected void Page_Load(object sender, EventArgs e)
    {
        törölID.BackColor = System.Drawing.Color.White;
        TbAlkatrészMennyiség.BackColor = System.Drawing.Color.White;
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
            SqlCommand cmdalk = new SqlCommand("CREATE TABLE alkatrészek ([id] INT IDENTITY(1, 1) NOT NULL, [megnevezés] NCHAR(100) NOT NULL, [súly] INT NOT NULL, [ár] INT NOT NULL, CONSTRAINT[PK_alkatrészek] PRIMARY KEY CLUSTERED([id] ASC)); ", con);
            cmdalk.ExecuteNonQuery();
        } //alkatrészek

        try
        {
            SqlDataAdapter sqlterm = new SqlDataAdapter("Select * From termékek", con);
            DataTable tableterm = new DataTable();
            sqlterm.Fill(tableterm);
        }
        catch (Exception)
        {
            con.Open();
            SqlCommand cmdterm = new SqlCommand("CREATE TABLE termékek ([id] INT IDENTITY(1, 1) NOT NULL, [megnevezés] NCHAR(100) NOT NULL, [súly] INT NOT NULL, [ár] INT NOT NULL, CONSTRAINT[PK_termékek] PRIMARY KEY CLUSTERED([id] ASC)); ", con);
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

        SqlDataAdapter sqla = new SqlDataAdapter("Select * From alkatrészek", con);
        DataTable table = new DataTable();
        sqla.Fill(table);
        //AlkatrészLista.Items.Clear();
        foreach (DataRow r in table.Rows)
        {
            ida.Add(Convert.ToInt32(r["id"]));
            megnevezesa.Add(Convert.ToString(r["megnevezés"]));
            sulya.Add(Convert.ToInt32(r["súly"]));
            ara.Add(Convert.ToInt32(r["ár"]));
        }//alkatrészből feltöltés listába
        for (int i = 0; i < ida.Count; i++)
        {
            ListItem item = new ListItem(megnevezesa[i]);
            if (!AlkatrészLista.Items.Contains(item))
            {
                AlkatrészLista.Items.Add(megnevezesa[i]);
            }
        }//alkatrész betöltés

        SqlDataAdapter sqlt = new SqlDataAdapter("Select * From termékek", con);
        table = new DataTable();
        sqlt.Fill(table);
        //TermékLista.Items.Clear();
        foreach (DataRow r in table.Rows)
        {
            idt.Add(Convert.ToInt32(r["id"]));
            megnevezest.Add(Convert.ToString(r["megnevezés"]));
            sulyt.Add(Convert.ToInt32(r["súly"]));
            art.Add(Convert.ToInt32(r["ár"]));
        }//termékekből feltöltés listába
        for (int i = 0; i < idt.Count; i++)
        {
            ListItem item = new ListItem(megnevezest[i]);
            if (!TermékLista.Items.Contains(item))
            {
                TermékLista.Items.Add(megnevezest[i]);
            }
        }//termék betöltés

        SqlDataAdapter sqlö = new SqlDataAdapter("Select * From összekötő", con);
        DataTable table1 = new DataTable();
        sqlö.Fill(table1);
        foreach (DataRow r in table1.Rows)
        {
            ID.Add(Convert.ToInt32(r["id"]));
            termid.Add(Convert.ToInt32(r["tid"]));
            alkid.Add(Convert.ToInt32(r["aid"]));
            mennyiség.Add(Convert.ToInt32(r["mennyiség"]));
        }
        TableRow row;
        TableCell cell;
        for (int i = 0; i < ID.Count; i++)
        {
            row = new TableRow();

            cell = new TableCell();
            cell.Text = Convert.ToString(ID[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = Convert.ToString(termid[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = Convert.ToString(alkid[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            cell = new TableCell();
            cell.Text = Convert.ToString(mennyiség[i]);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }
    }

    protected void TermékLista_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void AlkatrészLista_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnEllenőrzés_Click(object sender, EventArgs e)
    {
        int termékid = 0;
        int alkid = 0;
        for (int i = 0; i < idt.Count; i++)
        {
            if (megnevezest[i] == TermékLista.SelectedValue.ToString())
            {
                termékid = idt[i];
            }
        }

        for (int i = 0; i < ida.Count; i++)
        {
            if (megnevezesa[i] == AlkatrészLista.SelectedValue.ToString())
            {
                alkid = ida[i];
            }
        }

        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        try
        {
            if (TbAlkatrészMennyiség.Text == "")
            {
                ErrorLabel.Text = "Adj meg egy értéket!";
                ErrorLabel.Visible = true;
            }
            else
            {
                SqlCommand cmdalk = new SqlCommand("INSERT INTO összekötő (tid, aid, mennyiség) VALUES (@tid,@aid,@mennyiség)", con);
                cmdalk.Parameters.AddWithValue("@tid", termékid);
                cmdalk.Parameters.AddWithValue("@aid", alkid);
                cmdalk.Parameters.AddWithValue("@mennyiség", TbAlkatrészMennyiség.Text.ToString());
                cmdalk.ExecuteNonQuery();
                TbAlkatrészMennyiség.BackColor = System.Drawing.Color.White;
                con.Close();
            }

            List<int> aidszámol = new List<int>();//aid beker
            List<int> mennyiségszámol = new List<int>();//mennyisegbeker
            List<int> súlyszámol = new List<int>();//súly beker
            List<int> árszámol = new List<int>();//ár beker
            SqlDataAdapter cmdát = new SqlDataAdapter("Select aid, mennyiség, súly, ár From összekötő, alkatrészek where aid=alkatrészek.id and tid=" + termékid, con);
            
            DataTable szamoltabla = new DataTable();
            cmdát.Fill(szamoltabla);
                foreach (DataRow r in szamoltabla.Rows)
                {
                    aidszámol.Add(Convert.ToInt32(r["aid"]));
                    mennyiségszámol.Add(Convert.ToInt32(r["mennyiség"]));
                    súlyszámol.Add(Convert.ToInt32(r["súly"]));
                    árszámol.Add(Convert.ToInt32(r["ár"]));
                }
            //ErrorLabel.Text = Convert.ToString(aidszámol[0]);
            //ErrorLabel.Visible = true;
            int összsúly = 0;
            double összérték = 0;
                for (int i = 0; i < mennyiségszámol.Count; i++)
                {
                    összsúly += mennyiségszámol[i] * súlyszámol[i];//mennyiség
                    összérték += árszámol[i] * mennyiségszámol[i] * 1.1;//ár (hiányzik a 0.valemmnyis szorzat)
                }
            //ErrorLabel.Text = Convert.ToString(mennyiségszámol.Count);
            //ErrorLabel.Visible = true;
            con.Open();
            SqlCommand cmd = new SqlCommand("update termékek set súly=@súly, ár=@ár where id = @id", con);
            cmd.Parameters.AddWithValue("@súly", összsúly);
            cmd.Parameters.AddWithValue("@ár", összérték);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(termékid));
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e2)
        {
            ErrorLabel.Text = Convert.ToString(e2);
            ErrorLabel.Visible = true;
            TbAlkatrészMennyiség.BackColor = System.Drawing.Color.Yellow;
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void idtörl_Click(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\letöltések\egyetem\Int.Net.AlkFejl\Garazs\Garazs\App_Data\ERO056.mdf;Integrated Security = True";
        SqlConnection con = new SqlConnection(constring);
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        if (törölID.Text != "")
        {
            //törölk select
            SqlDataAdapter cmd1 = new SqlDataAdapter("Select * From összekötő where id=" + törölID.Text, con);
            DataTable cmd1tábla = new DataTable();
            cmd1.Fill(cmd1tábla);
            int idérték = 0;
            int tidérték = 0;
            int aidérték = 0;
            int mennyiségérték = 0;
            foreach (DataRow r in cmd1tábla.Rows)
            {
                idérték = Convert.ToInt32(r["id"]);
                tidérték = Convert.ToInt32(r["tid"]);
                aidérték = Convert.ToInt32(r["aid"]);
                mennyiségérték = Convert.ToInt32(r["mennyiség"]);
            }


            //törölt ár és érték kiszamolas mukodik
            SqlDataAdapter cmd2 = new SqlDataAdapter("Select a.súly, a.ár From alkatrészek a, összekötő ö where ö.aid=a.id", con);
            DataTable cmd2tábla = new DataTable();
            cmd2.Fill(cmd2tábla);
            double árértéktörlés = 0;
            int súlyértéktörlés = 0;
            foreach (DataRow r in cmd2tábla.Rows)
            {
                ErrorLabel.Text = Convert.ToString(r);
                ErrorLabel.Visible = true;
                árértéktörlés = Convert.ToDouble(r["ár"]);
                súlyértéktörlés = Convert.ToInt32(r["súly"]);
            }

            árértéktörlés = árértéktörlés*mennyiségérték*1.1;
            súlyértéktörlés = súlyértéktörlés * mennyiségérték;


            //összes select
            List<int> aidszámol = new List<int>();//aid beker
            List<int> mennyiségszámol = new List<int>();//mennyisegbeker
            List<int> súlyszámol = new List<int>();//súly beker
            List<int> árszámol = new List<int>();//ár beker
            SqlDataAdapter cmdát = new SqlDataAdapter("Select aid, mennyiség, súly, ár From összekötő, alkatrészek where aid=alkatrészek.id and tid="+tidérték ,con);

            DataTable szamoltabla = new DataTable();
            cmdát.Fill(szamoltabla);
            foreach (DataRow r in szamoltabla.Rows)
            {
                aidszámol.Add(Convert.ToInt32(r["aid"]));
                mennyiségszámol.Add(Convert.ToInt32(r["mennyiség"]));
                súlyszámol.Add(Convert.ToInt32(r["súly"]));
                árszámol.Add(Convert.ToInt32(r["ár"]));
            }
            //összead
            int összsúly = 0;
            double összérték = 0;
            for (int i = 0; i < mennyiségszámol.Count; i++)
            {
                összsúly += mennyiségszámol[i] * súlyszámol[i];//mennyiség
                összérték += árszámol[i] * mennyiségszámol[i] * 1.1;// kivonandó ár
            }

            összsúly = összsúly - súlyértéktörlés;
            összérték = összérték - árértéktörlés;

            SqlCommand cmd = new SqlCommand("update termékek set súly=@súly, ár=@ár where id = @id", con);
            cmd.Parameters.AddWithValue("@súly", összsúly);
            cmd.Parameters.AddWithValue("@ár", összérték);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tidérték));
            cmd.ExecuteNonQuery();
            // törlés működik
            SqlCommand cmdtöröl = new SqlCommand("Delete From összekötő Where id =" + Convert.ToInt32(törölID.Text), con);
            ErrorLabel.Visible = false;
            törölID.BackColor = System.Drawing.Color.White;
            cmdtöröl.ExecuteNonQuery();
            Response.Redirect(Request.RawUrl);           
            con.Close();
        }
        else
        {
            ErrorLabel.Text = "Adj meg egy valós ID-t!";
            ErrorLabel.Visible = true;
            törölID.BackColor = System.Drawing.Color.Yellow;
        }
    }
}