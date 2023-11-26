using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.User_COntrol
{
    public partial class ctrlCalc : UserControl
    {
        public ctrlCalc()
        {
            InitializeComponent();
        }

        // Property
        public float Result
        {
            get
            {
                return (float)(Convert.ToDouble(lblResult.Text));
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lblResult.Text = Convert.ToString(int.Parse(textBox1.Text) +
                int.Parse(textBox2.Text));
        }
    }
}
