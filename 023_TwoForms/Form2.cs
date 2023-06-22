using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _023_TwoForms
{
    public partial class Form2 : Form
    {
        public Form2(Form1 form, string s)
        {
            InitializeComponent();
            f = form;
            MessageBox.Show(s, "이곳은 Form2");
        }

        Form1 f;

        private void button1_Click(object sender, EventArgs e)
        {            
            f.Show();
        }

        // Form2에서 Form1의 Text 변경( 제목 )
        private void button2_Click(object sender, EventArgs e)
        { 
            f.Text = textBox1.Text;

        }

        // Form2에서 Form1의 label1 변경
        private void button3_Click(object sender, EventArgs e)
        {
            // Fomr1의 label1의 Modifiers 속성을 public으로 바꾼 다음
            f.label1.Text = textBox1.Text;
        }

        // Form2 에서 Common 클래스의 값을 지정
        private void button4_Click(object sender, EventArgs e)
        {
            Common.str = textBox1.Text;
            Common.value = 1024;
        }
    }
}
