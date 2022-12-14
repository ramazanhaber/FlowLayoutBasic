using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FlowLayoutBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                OrnekModel ornekModel = new OrnekModel();
                ornekModel.id= i;
                ornekModel.ad = "Button " + i;
                if (i % 2 == 0) ornekModel.durum = true;
                MyFlowDoldur(ornekModel);
            }

        }
        public void MyFlowDoldur(OrnekModel ornekModel)
        {
            try
            {
                MyButton button = new MyButton();
                button.FlatStyle = FlatStyle.Flat;
                button.Height = 70;
                button.Width = 135;
                button.ForeColor = Color.White;
                button.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);

                if (ornekModel.durum == false)
                {
                    button.BackColor = Color.Green;
                }
                else
                {
                    button.BackColor = Color.Red;
                }

                button.Text = ornekModel.ad;
                button.Tag = ornekModel;
                flowLayoutPanel1.Controls.Add(button);
                button.Click += btnNew_Click;
                button.DoubleClick += btnDoubleNew_Click;
                button.MouseHover += ButtonName_MouseHover;
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA! MyFlowDoldur()" + ex.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string text = clickedButton.Text;
            //MessageBox.Show(text);
            Console.WriteLine("click  " + text);


            OrnekModel model = (OrnekModel)clickedButton.Tag;
            //MessageBox.Show("Left Single Click :\n"+ model.id + "- " + model.ad);
            label1.Text = "Left Single Click :\n" + model.id + "- " + model.ad;
        }
        private void btnDoubleNew_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string text = clickedButton.Text;


            OrnekModel model = (OrnekModel)clickedButton.Tag;
            MessageBox.Show("double click :\n" + model.id + "- " + model.ad);

         
        }
        private void ButtonName_MouseHover(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string text = clickedButton.Text;
            Console.WriteLine("hover  " + text);


            OrnekModel model = (OrnekModel)clickedButton.Tag;


            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(clickedButton, "hover \n" + model.id+"- "+model.ad);
        }
    }
}
