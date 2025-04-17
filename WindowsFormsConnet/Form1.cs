using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace WindowsFormsConnet
{
    public partial class Form1 : Form
    {


        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
       // private readonly SqlConnection Conn;

        public Form1()
        {
            InitializeComponent();
            
            // conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultname"].ConnectionString);

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultname"].ConnectionString);
            //   using var_ = sqlConnection;

        }
        public void clearformFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox2.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into employee values(@eid,@ename,@esal)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", textBox1.Text);
                cmd.Parameters.AddWithValue("@ename", textBox2.Text);
                cmd.Parameters.AddWithValue("@esal", textBox3.Text);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                clearformFields();
                //int reslt = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Employee Added");

                }
                else {
                    MessageBox.Show("Employee not Added");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Employee not Added" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string qry = "select *from employee";
            cmd = new SqlCommand(qry, conn);
            conn.Open();
            reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;


            conn.Close();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select *from where eid=@id";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader["ename"].ToString();
                    textBox3.Text = reader["esal"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" not Added" + ex.Message);
            }
            finally {
                conn.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string deleteQuery = "DELETE FROM Employee WHERE ename = @ename";
            //   // cmd = new SqlCommand(sql, conn);
            //    cmd.Parameters.AddWithValue("@name", textBox1.Text);
            //    cmd.Parameters.AddWithValue("@Salary", textBox1.Text);
            //    conn.Open();
            //    int res =deleteQuery.ExecuteNonQuery();
            //    connection.Close();
            //    MessageBox.Show("Record deleted successfully!");
            //    int result = cmd.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(" not Added" + ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //} 
            
         
        
            }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update Employee set ename=@ename,esal=@esal, eid=@id";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ename", textBox2.Text);
                cmd.Parameters.AddWithValue("@esal", textBox3.Text);
                cmd.Parameters.AddWithValue("@eid", textBox1.Text);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result>=0)
                {
                  
                    MessageBox.Show(" updated Record"  );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" not Added" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
