using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public readonly Form1 form1;
        public readonly Form2 form2;
        public FormMain(Form1 form1, Form2 form2)
        {
            InitializeComponent();
            this.form1 = form1;
            this.form2 = form2;
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            if (TestExitsPage(typeof(Form1))) { return; }
            form1.MdiParent = this;
            form1.Show();
        }

        bool TestExitsPage(Type page)
        {
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage pg in tabMain.Pages)
            {
                if (pg.MdiChild.GetType() == page)
                {
                    tabMain.SelectedPage = pg;
                    return true;
                }
            }
            return false;
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (TestExitsPage(typeof(Form2))) { return; }
            form2.MdiParent = this;
            form2.Show();
        }
    }
}
