using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public readonly ICustomerRepository EmployeeRepository;
        public Form1(ICustomerRepository employeeRepository, CommonContext commonContext)
        {
            InitializeComponent();
            this.EmployeeRepository = employeeRepository;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = await EmployeeRepository.GetAll();
            Console.WriteLine(x);
            
            new Form2(EmployeeRepository, commonContext).ShowDialog();
            Program.ServiceProvider.GetRequiredService<Form2>();
        }
    }
}   