using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _020_FormClock
{
  public partial class Form1 : Form
  {
    // 필드를 만든다
    private Graphics g;
    private bool aClockFlag = true;
    private Point center;   // 중심점
    private int radius;     // 반지름
    private int hourHand;   // 시침의 길이
    private int minHand;    // 분침
    private int secHand;    // 초침

    private const int clientSize = 450; // 클라이언트 사이즈
    private const int clockSize = 350; // 시계 사이즈
    public Form1()
    {
      InitializeComponent();

      this.Text = "Form Clock by bikang";
      panel1.BackColor = Color.White;
      this.ClientSize 
        = new Size(clientSize, 
              clientSize + menuStrip1.Height); 

      g = panel1.CreateGraphics();

      aClockSetting();
      dClockSetting();
      TimerSetting();
    }

        private void dClockSetting()
        {
            label1.Font = new Font("맑은 고딕", 16, FontStyle.Bold | FontStyle.Italic);

            label1.ForeColor = Color.DarkSlateBlue;
        }

        // 아날로그 시계 세팅
        private void aClockSetting()
    {
      center = new Point(clientSize/2, clientSize/2);
      radius = clockSize / 2;

      hourHand = (int)(radius * 0.5);
      minHand = (int)(radius * 0.7);
      secHand = (int)(radius * 0.85);
    }

    private void TimerSetting()
    {
      Timer t = new Timer();
      t.Interval = 1000;
      t.Tick += T_Tick;
      t.Start();  // t.Enable = true;
    }

    // 1초에 한번씩 시계를 그려준다
    private void T_Tick(object sender, EventArgs e)
    {
      panel1.Refresh();
      DateTime c = DateTime.Now;  // 현재시간

      if(aClockFlag == true)  // 아날로그 시계
      {
        // 시계판
        DrawClockFace();

        // 시계바늘의 각도를 라디안으로 표현
        double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI/180;
        double radMin = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
        double radSec = c.Second * 6 * Math.PI / 180;

        DrawHands(radHr, radMin, radSec);

       
        // 시계배꼽
        int coreSize = 32;
        Rectangle r = new Rectangle(center.X - coreSize/2, center.Y - coreSize/2, coreSize, coreSize);
        g.FillEllipse(Brushes.Gold, r);
        g.DrawEllipse(new Pen(Brushes.Green, 5), r);
      }
      else //디지털시계
      {
        label1.Text = DateTime.Now.ToString();
        label1.Location = new Point(ClientSize.Width / 2 - label1.Width / 2, ClientSize.Height / 2 - label1.Height / 2); // ClientSize -> panel1
       }                        // = panel1.Width
        }

    // 각도를 받아서 시계바늘을 그리는 메소드 ***중요!!!
    private void DrawHands(double radHr, double radMin, double radSec)
    {
      DrawLine((int)(hourHand * Math.Sin(radHr)), 
        (int)(hourHand * Math.Cos(radHr)), Brushes.RoyalBlue, 14);
      DrawLine((int)(minHand * Math.Sin(radMin)),
        (int)(minHand * Math.Cos(radMin)), Brushes.SkyBlue, 9);
      DrawLine((int)(secHand * Math.Sin(radSec)),
        (int)(secHand * Math.Cos(radSec)), Brushes.OrangeRed, 5);
    }

    private void DrawLine(int x, int y, Brush b, int t)
    {
      Pen p = new Pen(b, t);
      p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
      g.DrawLine(p, center.X, center.Y, center.X + x, center.Y - y);
    }

    private void DrawClockFace()
    {
      Pen p = new Pen(Color.LightSteelBlue, 40);
      g.DrawEllipse(p, center.X - clockSize/2, center.Y - clockSize/2,
        clockSize, clockSize);

      // 시간위치 표시
      // 숫자판(점) 그리기
      int dotSize = 12;
      for(int d = 0; d<360; d +=30)
      {
        int x = (int)(center.X + radius * Math.Sin(d * Math.PI / 180) - dotSize/2);
        int y = (int)(center.Y - radius * Math.Cos(d * Math.PI / 180) - dotSize/2);
        g.FillEllipse(Brushes.AliceBlue, x, y, dotSize, dotSize);
        //g.FillEllipse(Brushes.AliceBlue, new Rectangle(x - dotSize / 2, y - dotSize / 2, dotSize, dotSize));
      }
    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClockFlag = true;
            label1.Text = "";
        }

        private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClockFlag = false;
        }

        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
