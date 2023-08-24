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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // ADD button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkifAuthorexist())
            {
                Response.Write("<script>alert( 'Author  with this ID Already Exist. You cannot add another aurthor with the same Author ID.'); </script>");
            }
            else
            {
                addNewAutrhor();
            }
        }

        // Update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifAuthorexist())
            {
                UpdateAuthor();
                
            }
            else
            {
                Response.Write("<script>alert( 'Author does not Exist.'); </script>");
            }
        }

        // Delete button
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (checkifAuthorexist())
            {
                deleteAuthor();

            }
            else
            {
                Response.Write("<script>alert( 'Author does not Exist.'); </script>");
            }
        }

        // GO button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getauthorbyID();
        }

        //user defined functions

        void getauthorbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert( 'Invalid Author ID'); </script>");
                }

                

                

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
               
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from author_master_tbl  WHERE author_id='" + TextBox1.Text.Trim() + "'", con);

                


                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Author Deleted Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }
        
        void UpdateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPdate author_master_tbl SET author_name=@author_name WHERE author_id='"+TextBox1.Text.Trim()+"'", con);
                
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Author Updated Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }

        void addNewAutrhor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name) ", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
               

                cmd.ExecuteNonQuery();
                con.Close();
                clearForm();
                GridView1.DataBind();
                Response.Write("<script>alert( 'Author added Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkifAuthorexist() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'; ", con);
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

                con.Close();

                

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