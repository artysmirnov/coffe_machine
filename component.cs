﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffe
{
    public partial class component : UserControl
    {
        public component()
        {
            InitializeComponent();
            WireAllControls(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void CreateButton(string name, string cost, string path)
        {
            button1.Text = name+ "-" + cost;
            button1.BackgroundImage = Image.FromFile(path);
            this.Tag = button1.Text;
        }
        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
