using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationLibraryManagement
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go BUtton
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        //ISsue Book button
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (checkifBookexist() && checkifMemberexist())
            {

                if (checkifIssueEntryexist())
                {
                    Response.Write("<script>alert( 'This member has already this BOOk.'); </script>");
                }
                else
                {
                    issueBook();
                }
               
            }
            else
            {
                Response.Write("<script>alert( 'Wrong Book ID or Member ID'); </script>");
            }
        }


        //Return BUtton
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifBookexist() && checkifMemberexist())
            {

                if (checkifIssueEntryexist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert( 'This entry does not exist.'); </script>");
                }

            }
            else
            {
                Response.Write("<script>alert( 'Wrong Book ID or Member ID'); </script>");
            }
        }

        //user defined FUnctions

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl where book_id='" + TextBox1.Text.Trim() + "' and member_id='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
              
                if (result >0)
                {
                    
                    cmd = new SqlCommand("Update book_master_tbl set current_stock = current_stock +1 where book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert( 'Book Return Successful.'); </script>");
                }
                else
                {
                    Response.Write("<script>alert( 'Error -  Invalid Details'); </script>");
                }

                

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }



        bool checkifIssueEntryexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where member_id='" + TextBox2.Text.Trim() + "' and book_id='" + TextBox1.Text.Trim() + "'", con);
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
            catch (Exception)
            {
                return false;
            }
        }

        
        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date) ", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());


                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("Update book_master_tbl set current_stock = current_stock -1 where book_id='"+TextBox1.Text.Trim()+"'",con);


                cmd.ExecuteNonQuery();
                con.Close();
               
                GridView1.DataBind();
                Response.Write("<script>alert( 'Book Issued Successful.'); </script>");

            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }

        bool checkifMemberexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataBind();
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        bool checkifBookexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' and current_stock >0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataBind();
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
                return false;
            }
        }

        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl where book_id='"+TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert( 'Wrong Book ID'); </script>");
                }

                cmd = new SqlCommand("select full_name from member_master_tbl where member_id='"+TextBox2.Text.Trim()+"'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert( 'Wrong User ID'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( '"+ex.Message+"'); </script>");
            }
        }
       // date function valid

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text.Trim() );
                    DateTime today = DateTime.Today;
                    if (today > dt )
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( '" + ex.Message + "'); </script>");
            }
        }
    }
}