using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationLibraryManagement
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                Response.Write("<script>alert( 'Publisher  with this ID Already Exist. You cannot add another Publisher with the same Publisher ID.'); </script>");
            }
            else
            {
                addNewpublisher();
            }
        }
        // update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                UpdatePublisher();

            }
            else
            {
                Response.Write("<script>alert( 'Publisher does not Exist.'); </script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                deletePublisher();

            }
            else
            {
                Response.Write("<script>alert( 'Publisher does not Exist.'); </script>");
            }
        }

        //goo  button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getpublisherID();
        }

        // user definde functions

        void getpublisherID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert( 'Invalid Publisher ID'); </script>");
                }

                con.Close();



            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");

            }
        }


        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from publisher_master_tbl  WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);




                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Publisher Deleted Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }


        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPdate publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Publisher Updated Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }

        void addNewpublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name) ", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Publisher added Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkifpublisherexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

               

               

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}