using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Симулятор_простого_рестарана_4
{
    public partial class Form1 : Form
    {
       

        private Server server;
        private Cook cook;

        public Form1()
        {
            InitializeComponent();


            server = new Server();
            cook = new Cook();

            cook.Subscribe(server);

            cook.Processed += server.ServeFood;
            cook.Processed += (s, e) =>
            {
                richTextBox1.AppendText("All food processed successfully!\n");
            };

            comboBox1.Items.AddRange(new string[]
            {
                "None", "Tea", "Cocacola", "Water", "Fanta"
            });

            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;

            int chicken = int.Parse(textBox1.Text);
            int egg = int.Parse(textBox2.Text);
            bool drink = comboBox1.SelectedItem.ToString() != "None";

            server.TakeOrder(name, chicken, egg, drink);

            label4.Text = new Random().Next(1, 101).ToString();

            richTextBox1.AppendText(
                $"Order received from {name}\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.SendOrders();
        }

       

      
    }
}
