using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public readonly IEmployeeRepository EmployeeRepository;
        public readonly Form2 form2;
        public Form1(IEmployeeRepository employeeRepository,Form2 form2)
        {
            InitializeComponent();
            this.EmployeeRepository = employeeRepository;
            this.form2 = form2;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = await EmployeeRepository.GetAll();
            this.form2.ShowDialog();
            Program.ServiceProvider.GetRequiredService<Form2>();
        }
    }
}   