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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 f;

        private void button1_Click(object sender, EventArgs e)
        {
            if(f == null)  // Form2가 없을 때만 만든다
             f = new Form2(this,"난 Form1이야.");
            f.Show();
            this.Hide(); //Form1 없어짐
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = f.textBox1.Text;
        }

        // Common 클래스에서 값을 가져오기
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Common.str + "\n" + Common.value);
        }
    }

    public static class Common
    {
        // 멤버 변수 = field(필드) dataBase 처럼 모두 쓸 수 있는 공통의 클래스
        public static string str = "";
        public static int value = 0;
    }
}
