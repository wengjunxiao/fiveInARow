using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        //server-用于处理客户端连接请求的socket
        Socket clientSocket = null;

         //创建服务端服务端套接字
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Socket clientSocket1 = null;//客户端套接字
         Thread threadListen;
        public Form1()
        {
            InitializeComponent();
        }
        public struct play
        {
            public int m;
            public int n;
        }

        int oldx, oldy, ff, ss;
        private System.Drawing.Image bgbmp = System.Drawing.Image.FromFile("qipan.bmp");
        private bool online = false;
        private bool hu = true;
        private int m, n;
        private int[,] board = new int[15, 15];
        private play[] ftable = new play[113];
        private play[] stable = new play[112];
        private bool player, computer, over, first;
        private bool start = false;
        private bool fwin, swin, tie;
        System.Drawing.Graphics g;


        private void updatePaint()   //刷新屏幕；
        {
            g = this.CreateGraphics();
            g.DrawImage(bgbmp, 0, 0, bgbmp.Width, bgbmp.Height);



            if (computer)
                ComTurn();

            judge();

            showpiont();


        }



        private void ComTurn()    //电脑下棋；
        {
            while (board[m, n] != 2)
            {
                Random rdm2 = new Random();
                m = rdm2.Next(0, 15);
                n = rdm2.Next(0, 15);
            }
            if (board[m, n] == 2)
            {
                board[m, n] = 1;
                stable[ss].m = m;
                stable[ss].n = n;
                ss++;
            }


            if (!online)
            {
                player = true;
                computer = false;
            }
        }

        private void judge()    //判断输赢；
        {
            for (int i = 0; i < 15; i++)
            {
                //每一行，测试；
                int a = 0;
                int b = 0;
                while (a < 12 && b < 5)
                {

                    if (board[i, a] == 0)
                    {
                        a++;
                        b++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                    return;
                }
                a = 0;
                b = 0;
                while (a < 12 && b < 5)
                {
                    if (board[i, a] == 1)
                    {
                        a++;
                        b++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                    return;
                }


                // 每一列，测试
                a = 0;
                b = 0;
                while (a < 12 && b < 5)
                {
                    if (board[a, i] == 0)
                    {
                        a++;
                        b++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                    return;
                }

                a = 0;
                b = 0;

                while (a < 12 && b < 5)
                {
                    if (board[a, i] == 1)
                    {
                        a++;
                        b++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                    return;
                }
            }


            //斜着；
            for (int i = 14; i > 3; i--)
            {
                int a = 0;
                int b = 0;
                int c = i;
                while (a < 15 && b < 5 && c >= 0)
                {
                    if (board[a, c] == 0)
                    {
                        b++;
                        a++;
                        c--;
                    }
                    else
                    {
                        a = a - b + 1;
                        c = c + b - 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                }

                a = 0;
                b = 0;
                c = i;
                while (a < 15 && b < 5 && c >= 0)
                {
                    if (board[a, c] == 1)
                    {
                        b++;
                        a++;
                        c--;
                    }
                    else
                    {
                        a = a - b + 1;
                        c = c + b - 1;
                        b = 0;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                }
            }


            for (int i = 0; i < 15; ++i)
            {
                int a = 14;
                int b = 0;
                int c = i;
                while (a >= 0 && b < 5 && c < 15)
                {
                    if (board[c, a] == 0)
                    {
                        b++;
                        a--;
                        c++;
                    }
                    else
                    {
                        a = a + b - 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                }

                a = 14;

                b = 0;

                c = i;

                while (a >= 0 && b < 5 && c < 15)
                {
                    if (board[c, a] == 1)
                    {
                        b++;
                        a--;
                        c++;
                    }
                    else
                    {
                        a = a + b - 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                }
            }


            for (int i = 0; i < 15; ++i)
            {
                int a = 0;
                int b = 0;
                int c = i;
                while (a < 15 && b < 5 && c < 15)
                {
                    if (board[a, c] == 0)
                    {
                        a++;
                        b++;
                        c++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                }


                a = 0;
                b = 0;
                c = i;
                while (a < 15 && b < 5 && c < 15)
                {
                    if (board[a, c] == 1)
                    {
                        a++;
                        b++;
                        c++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                }
            }

            for (int i = 0; i < 15; i++)
            {
                int a = 0;
                int b = 0;
                int c = i;

                while (a < 15 && b < 5 && c < 15)
                {
                    if (board[c, a] == 0)
                    {
                        a++;
                        b++;
                        c++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    fwin = true;
                    over = true;
                }



                a = 0;
                b = 0;
                c = i;

                while (a < 15 && b < 5 && c < 15)
                {
                    if (board[c, a] == 1)
                    {
                        a++;
                        b++;
                        c++;
                    }
                    else
                    {
                        a = a - b + 1;
                        b = 0;
                        c = c - b + 1;
                    }
                }
                if (b == 5)
                {
                    swin = true;
                    over = true;
                }
            }






        }//judge finish;



        private void showpiont()   //显示棋子；
        {


            for (int i = 0; i <= 14; i++)
                for (int j = 0; j <= 14; j++)
                {
                    if (board[i, j] == 0)
                    {
                        // g.DrawImage(green, i * 40 + 2, j * 40 + 2, 36, 36);
                        SolidBrush black = new SolidBrush(Color.Black);
                        g.FillEllipse(black, i * 31 + 32, j * 31 + 70, 26, 26);
                    }
                    if (board[i, j] == 1)
                    {
                        // g.DrawImage(purple, i * 40 + 2, j * 40 + 2, 36, 36);
                        SolidBrush white = new SolidBrush(Color.White);
                        g.FillEllipse(white, i * 31 + 32, j * 31 + 70, 26, 26);
                    }
                }

            if (fwin)
            {
                toolStripStatusLabel1.Text = "玩家一赢";
                hu = false;
                fwin = false;
                MessageBox.Show("玩家一赢");
                if (!online)
                    danji();
                else
                    olagaint();

                    
                
            }
            if (swin)
            {
                toolStripStatusLabel1.Text = "玩家2赢";
                hu = false;
                swin = false;
                MessageBox.Show("玩家2赢");
                if (!online)
                    danji();
                else
                    olagaint();
               
            }
            if (tie)
            {
                toolStripStatusLabel1.Text = "3";
                hu = false;
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;


            this.KeyPreview = true;
            this.Width = 535;
            this.Height = 604;




            //Random rdm1 = new Random(unchecked((int)DateTime.Now.Ticks));

            //if (rdm1.Next() % 2 == 0)

            //else
            //  player = true;

        }

        private void danji()
        {
            computer = true;
            first = true;
            start = true;
            over = false;
            online = false;
        //    player = true; //刚添；
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                g.Dispose();
                this.Close();
                return;
            }
            if (e.KeyCode == Keys.F2)
                danji();
            if (e.KeyCode == Keys.F3)
                retry();
            updatePaint();
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (hu)
            {

               
                if (online)
                {
                    computer = false;
                    player = true;
                    start = cc.start;
                    

                }
                updatePaint();

            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                oldx = e.X;
                oldy = e.Y;
                // label1.Text = oldx + "   " + oldy;


                if (!over)
                    if (player && start)
                    {
                        if (oldx > 490 || oldx < 31 || oldy < 70 || oldy > 531)
                        {

                            return;

                        }



                        {


                            oldx -= 45;
                            oldy -= 83;
                            //  label1.Text = oldx + "   " + oldy;
                            int a = oldx % 31;
                            int b = oldy % 31;
                            //   label2.Text = a + "   " + b;
                            if (a > 13 && a < 18)
                                return;
                            if (b > 13 && b < 18)
                                return;
                            m = Convert.ToInt32(Math.Round(oldx / 31.0));
                            n = Convert.ToInt32(Math.Round(oldy / 31.0));

                            // label3.Text = m + "   " + n;

                            if (board[m, n] == 2)
                            {

                                if (first)
                                {
                                    //  button2.Enabled = true;
                                    board[m, n] = 0;
                                    ftable[ff].m = m;
                                    ftable[ff].n = n;

                                    ff++;
                                    if (online)
                                    {
                                        sever_send();
                                        over = true;
                                    }

                                }
                                else
                                {
                                    //  button2.Enabled = true;
                                    board[m, n] = 1;
                                    stable[ss].m = m;
                                    stable[ss].n = n;

                                    ss++;
                                    if (online)
                                    {
                                        client_send();
                                        over = true;
                                    }

                                }


                                if ((ff == 113) || (ss == 112))
                                {
                                    tie = true;
                                    over = true;
                                }


                                if (!online)
                                {
                                    player = false;
                                    computer = true;
                                    first = true;
                                }
                            }
                        }
                    }
                updatePaint();
            }
            catch
            {
                online = false;
                first = !first;
                if (first)
                    clientSocket.Close();
                else
                    clientSocket1.Close();
                danji();
            }



        }



        private void retry()
        {
            if (over)
                return;
            try
            {

                ss -= 1;
                ff -= 1;
                board[ftable[ff].m, ftable[ff].n] = 2;
                board[stable[ss].m, stable[ss].n] = 2;
                if (ff == 0)
                {
                    button2.Enabled = false;
                    ff = 0;
                    ss = 0;
                }

            }

            catch
            {
                ff = 0;
                ss = 0;
                button2.Enabled = false;

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            retry();
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danji();
        }







        private void 退出EscToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            g.Dispose();
            this.Close();

        }

        private void 帮助F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void 退出EscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            retry();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void 联机对战ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;

      //      first = true;
            start = true;
            over = false;
            
            //Form2 frm2 = new Form2();
            //frm2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        //网络对战功能；

        //server-侦听方法
        private void listen()
        {
            //获取服务器IP
            string hostName = Dns.GetHostName();
            IPAddress ip = GetLocalIPV4();
            IPAddress HostIp = ip;

            //创建一个网络端点
            IPEndPoint iep = new IPEndPoint(HostIp, 82);

          

           

            //将套接字与网络端点绑定
            serverSocket.Bind(iep);

            //将套接字置为侦听状态，并设置最大队列数为2
            serverSocket.Listen(2);

            //以同步方式从侦听套接字的连接请求队列中提取第一个挂起的连接请求，然后创建并返回新的 Socket
            //新的套接字：包含对方计算机的IP和端口号，可使用这个套接字与本机进行通信   
            clientSocket = serverSocket.Accept();
            if (clientSocket != null)
            {
                MessageBox.Show("连接成功！");
                cc.start = true;
            }

        }

        public IPAddress GetLocalIPV4()
        {
            IPAddress[] ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //遍历获得的IP集以得到IPV4地址
            foreach (IPAddress ip in ips)
            {
                //筛选出IPV4地址
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            //如果没有则返回IPV6地址
            return ips[0];
        }

        public void sever_send()
        {


           
                try
                {
                    //发送数据
                    //string message = textBox1.Text;
                    // int[] sendbytes = { cc.m, cc.n, cc.ff }; //服务器为黑子，总是第一手下；
                    byte[] bySend = new byte[3];
                    bySend[0] = Convert.ToByte(m);
                    bySend[1] = Convert.ToByte(n);
                    bySend[2] = Convert.ToByte(ff);

                    int successSendBtyes = clientSocket.Send(bySend);
                }
                catch (Exception exp)
                {
                 //   MessageBox.Show(exp.Message);   //对象应用实例
                }
                //将发送的数据
               


            }

        
        //服务开始；
        public void severstart()
        {
            threadListen = new Thread(new ThreadStart(listen));
            threadListen.Start();
        }



        //接受检测； 
        private void server_receive()
        {

            try
            {
                byte[] receiveBytes = new byte[3];
                //如果侦听后取得客户端连接，并且客户端的缓冲区中有内容可读,开始接收数据
                if (clientSocket != null)
                {

                    if (clientSocket.Poll(100, SelectMode.SelectRead))
                    {
                        int successReceiveBytes = clientSocket.Receive(receiveBytes);
                        m = Convert.ToInt32(receiveBytes[0]);
                        n = Convert.ToInt32(receiveBytes[1]);
                        ss = Convert.ToInt32(receiveBytes[2]);
                        if (m == 111 && n == 222 && ss == 222)
                        {
                            for (int i = 0; i < 15; i++)
                                for (int j = 0; j < 15; j++)
                                    board[i, j] = 2;
                            updatePaint();
                            toolStripStatusLabel1.Text = "五子棋对战";
                        }
                        else
                        {
                            if (m == 222 && n == 222 && ss == 222)
                            {
                                timer1.Enabled = false;
                                online = false;
                                clientSocket.Close();
                                serverSocket.Close();
                                this.Close();
                                threadListen.Abort();
                                
                                return;
                            }
                            else
                            {

                                board[m, n] = 1;
                                over = false;
                                judge();
                                showpiont();
                            }
                        }
                    }
                }
            }
            catch
            {
                
                return;
            }
        }


        //客户端


        public void connect()   //连接到服务器；
        {
            try                  
            {
                //建立与服务器连接的套接字
                IPAddress ip = IPAddress.Parse(cc.ip);
                IPEndPoint iep = new IPEndPoint(ip, 82);
                clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(iep);
                // textBox2.Text = "连接成功" + "\r\n";
                cc.start = true;

            }
            catch 
            {
                MessageBox.Show("请输入正确的ip地址");
                return;
            }
        }


        public void client_send()   //客户端send；白棋
        {
          //  if (ss < cc.ss)   //不能发送空消息
            {
                try
                {
                    //发送数据
                    // string message = textBox1.Text;
                    // int[] sendbytes ={ cc.m, cc.n, cc.ss };  
                    byte[] bySend = new byte[3];
                    bySend[0] = Convert.ToByte(m);
                    bySend[1] = Convert.ToByte(n);
                    bySend[2] = Convert.ToByte(ss);

                    int successSendBtyes = clientSocket1.Send(bySend);
                   
                }
                catch (Exception exp)
                {
                  //  MessageBox.Show(exp.Message);
                }
                //将发送的数据

            }

        }

        //接受timer
        public void client_receive()
        {
            try
            {
                byte[] receiveBytes = new byte[3];
                //如果侦听后取得客户端连接，并且客户端的缓冲区中有内容可读,开始接收数据
                if (clientSocket1 != null)
                {

                    if (clientSocket1.Poll(100, SelectMode.SelectRead))
                    {
                        int successReceiveBytes = clientSocket1.Receive(receiveBytes);
                        m = Convert.ToInt32(receiveBytes[0]);
                        n = Convert.ToInt32(receiveBytes[1]);
                        ff = Convert.ToInt32(receiveBytes[2]);
                        if (m == 111 && n == 222 && ff == 222)
                        {
                            for (int i = 0; i < 15; i++)
                                for (int j = 0; j < 15; j++)
                                    board[i, j] = 2;
                            updatePaint();
                            toolStripStatusLabel1.Text = "五子棋对战";
                        }
                        else
                        {
                            if (m == 222 && n == 222 && ff == 222)
                            {
                                timer1.Enabled = false;
                                online = false;
                                MessageBox.Show("断开连接了");
                                clientSocket1.Close();
                                serverSocket.Close();
                                
                                threadListen.Abort();
                                this.Close();
                                return;
                            }
                            else
                            {
                                board[m, n] = 0;
                                over = false;
                                judge();
                                showpiont();
                            }
                        }
                    }

                }
            }
            catch
            {
               
                return;
            }
        }

      

        private void 服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;
            再来一局ToolStripMenuItem.Enabled = true;
            first = true;
            start = true;
            over = false;
            player = true;
            online = true;
            timer1.Enabled = true;
            severstart(); 

        }

        private void 客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;
            再来一局ToolStripMenuItem.Enabled = true;

            first = false;
            start = true;
            over = false;
            player = true;
            timer1.Enabled = true;
            online = true;
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(cc.ip!="")
            connect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!first)
                {

                    client_receive();
                }
                else
                {
                    // MessageBox.Show("sd");
                    server_receive();

                }
            }
            catch
            { return; }

        }

        private void 再来一局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             online = false;
            if (first)
            {
                byte[] bySend = new byte[3];
                bySend[0] = Convert.ToByte(222);
                bySend[1] = Convert.ToByte(222);
                bySend[2] = Convert.ToByte(222);

              int successSendBtyes = clientSocket.Send(bySend);
              clientSocket.Close();
              serverSocket.Close();
            //  threadListen.Abort();
              return;
    


                //  client_send();
            }
            else
            {
                byte[] bySend = new byte[3];
                bySend[0] = Convert.ToByte(222);
                bySend[1] = Convert.ToByte(222);
                bySend[2] = Convert.ToByte(222);

                int successSendBtyes = clientSocket1.Send(bySend);
               clientSocket1.Close();
               serverSocket.Close();
              // threadListen.Abort();
               return;


            }
           

        }
       
        private void olagaint()
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    board[i, j] = 2;
            updatePaint();
            toolStripStatusLabel1.Text = "五子棋对战";

            if (first)
            {
                byte[] bySend = new byte[3];
                bySend[0] = Convert.ToByte(111);
                bySend[1] = Convert.ToByte(222);
                bySend[2] = Convert.ToByte(222);

                int successSendBtyes = clientSocket.Send(bySend);




                //  client_send();
            }
            else
            {
                byte[] bySend = new byte[3];
                bySend[0] = Convert.ToByte(111);
                bySend[1] = Convert.ToByte(222);
                bySend[2] = Convert.ToByte(222);

                int successSendBtyes = clientSocket1.Send(bySend);

            }

            start = true;
            over = false;
            player = true;
            online = true;
        }

        private void 再来一局ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            olagaint();
        }





    }
}