using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public readonly ICustomerRepository customerRepository;

        public Form2(ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.customerRepository = customerRepository;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = await customerRepository.GetAll();
        }
    }
}
