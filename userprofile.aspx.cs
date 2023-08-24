using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationLibraryManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["username"] as string))
                {
                    Response.Write("<script>alert( 'Session Expired Log in Agian'); </script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserData();

                    if (!Page.IsPostBack)
                    {
                        getpersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert( 'Session Expired Log in Agian'); </script>");
                Response.Redirect("userlogin.aspx");
            }
        }

  // button Update

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string))
            {
                Response.Write("<script>alert( 'Session Expired Log in Agian'); </script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updatePersonalDetails();
            }
        }



        //useer defined functions
        void updatePersonalDetails()
        {
            string password = "";


            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,password=@password,account_status=@account_status where member_id='"+Session["username"].ToString().Trim()+"'", con);

                cmd.Parameters.AddWithValue("@full_name",TextBox3.Text.ToString().Trim());

                cmd.Parameters.AddWithValue("@dob", TextBox4.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.ToString().Trim());

                cmd.Parameters.AddWithValue("@email", TextBox2.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.ToString().Trim());

                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert( 'your Details update successfully'); </script>");
                    getpersonalDetails();
                    getUserData();
                }
                else
                {
                    Response.Write("<scritp>alert('Invalid Entry.S'); </script>");
                }


            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }
        }


        void getpersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from member_master_tbl where member_id='" + Session["username"].ToString() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                TextBox4.Text = dt.Rows[0]["dob"].ToString();
                TextBox1.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox2.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                var accountStatus = dt.Rows[0]["account_status"].ToString().Trim().ToLower();

                Label1.Text = accountStatus;

                if (accountStatus == "active")
                {
                    Label1.Attributes.Add("class", "p-1 mb-1 bg-primary text-dark");
                }
                else if (accountStatus == "pending")
                {
                    Label1.Attributes.Add("class", "p-1 mb-1 bg-warning text-dark");
                }
                else if (accountStatus == "inactive")
                {
                    Label1.Attributes.Add("class", "p-1 mb-1 bg-danger text-dark");
                }
                else
                {
                    Label1.Attributes.Add("class", "p-1 mb-1 bg-primary text-white");
                }



            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");

            }
        }

        void getUserData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from book_issue_tbl where member_id='" + Session["username"].ToString() + "'; ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {

                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (DateTime.TryParse(e.Row.Cells[5].Text.Trim(), out DateTime dt))
                    {
                        DateTime today = DateTime.Today;
                        if (today > dt)
                        {
                            e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                    }
                    else
                    {
                        // Handle the case where the date in the cell couldn't be parsed.
                        // You can choose to display an error message or take other appropriate actions.
                        // For example:
                        // e.Row.BackColor = System.Drawing.Color.Yellow;
                        // e.Row.ToolTip = "Invalid date format in the cell.";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<scritp>alert('" + ex.Message + "'); </script>");
            }

        }
    }
}