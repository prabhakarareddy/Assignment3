using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Assignment3
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["dbCOn"].ConnectionString;
            if (!Page.IsPostBack)
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
            conn = new SqlConnection(con);
            conn.Open();
        }

        protected void Unnamed_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCreatUser_Click(object sender, EventArgs e)
        {            
            string con= ConfigurationManager.ConnectionStrings["dbCOn"].ConnectionString;

            string email = txtEmail.Text + emailType.SelectedValue;

            conn = new SqlConnection(con);            
            conn.Open();
            cmd = new SqlCommand("insert into users values(" + "'" + txtUserName.Text + "'"+",'" + txtPassword.Text + "'," + "'" + email + "'" +",'" + ddlUserType.SelectedValue + "','" + txtNode.Text+ "')", conn);
            try
            {
                cmd.ExecuteNonQuery();
                lblStatus.Text = "New Record Created Succesfully";

                txtUserName.Text = "";
                txtPassword.Text = "";
                ddlUserType.SelectedValue = "Select";
                txtNode.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        protected void btnFindUser_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["dbCOn"].ConnectionString;

            conn = new SqlConnection(con);
            conn.Open();
            cmd = new SqlCommand("select * from users where username = '" + txtUserName.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                DataSet customers = new DataSet();
                adapter.Fill(customers, "Users");

                DataTable dt = customers.Tables["Users"];
                if (dt.Rows.Count > 0)
                {
                    txtPassword.Text = dt.Rows[0][1].ToString();
                    txtNode.Text = dt.Rows[0][4].ToString();
                    string email = dt.Rows[0][2].ToString();
                    String[] elements = Regex.Split(email, "@");
                    txtEmail.Text = elements[0];
                    emailType.SelectedValue = "@" + elements[1].ToString();
                    ddlUserType.SelectedValue = dt.Rows[0][3].ToString();
                    btnCreatUser.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;                 
                }
                else
                {
                    lblDisplay.Text = "No User Found";
                    lblStatus.Text = "Please Create New Record";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["dbCOn"].ConnectionString;

            string email = txtEmail.Text + emailType.SelectedValue;

            conn = new SqlConnection(con);
            conn.Open();
            cmd = new SqlCommand("update users set username =" + "'" + txtUserName.Text + "'" + ",password= '" + txtPassword.Text + "',Email=" + "'" + email + "'" + ",userType='" + ddlUserType.SelectedValue + "',note='" + txtNode.Text + "'", conn);
            try
            {
                cmd.ExecuteNonQuery();
                btnCreatUser.Visible = true;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                txtUserName.Text = "";
                txtPassword.Text = "";
                ddlUserType.SelectedValue = "Select";
                txtNode.Text = "";
                lblStatus.Text = "Record Updated Succesufully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["dbCOn"].ConnectionString;

            string email = txtEmail.Text + emailType.SelectedValue;

            conn = new SqlConnection(con);
            conn.Open();
            cmd = new SqlCommand("delete from users where username=" +"'" + txtUserName.Text + "'", conn);
            try
            {
                cmd.ExecuteNonQuery();
                btnCreatUser.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                lblStatus.Text = "Record Deleted Succesufully";

                txtUserName.Text = "";
                txtPassword.Text = "";
                ddlUserType.SelectedValue = "Select";
                txtNode.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}