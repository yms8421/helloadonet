using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.SQLServer.WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var employees = new List<Employee>();
            //EN KEKO YÖNTEM
            var connectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";
            //var connectionString = "Server=10.11.22.206;Database=Northwind;User Id=student;Password=ba123;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT FirstName, LastName, BirthDate FROM Employees";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var emp = new Employee();
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                employees.Add(emp);
            }
            dataGridView1.DataSource = employees;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var employees = new List<Employee>();
            //EN KEKO YÖNTEM
            var connectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";
            //var connectionString = "Server=10.11.22.206;Database=Northwind;User Id=student;Password=ba123;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = $"SELECT FirstName, LastName, BirthDate FROM Employees WHERE FirstName LIKE '%{txtSearch.Text}%'";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var emp = new Employee();
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                employees.Add(emp);
            }
            dataGridView1.DataSource = employees;
        }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
