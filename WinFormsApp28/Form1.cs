using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp28
{
    public partial class Form1 : Form
    {



        int rows = 40, cols = 32; //设置矩阵大小 （共有 40 rows， 4*8=32 cols）
        int cZero;//初始化矩阵内零的计数器
        public Form1()
        {
            InitializeComponent();

            //start 新增表头
            listView1.Columns.Add("bit", 40, HorizontalAlignment.Center);
            for (int i = 0; i <= 31; i++)
                listView1.Columns.Add(i.ToString(), 30, HorizontalAlignment.Center);
            //end 新增表头

            buttonReset_Click(this, EventArgs.Empty); // 随机化矩阵内元素为0/1

        }




        private void buttonReset_Click(object sender, EventArgs e)
        {
            /*
            随机化矩阵内元素为0/1
             */

            Random rand = new Random();


            listView1.BeginUpdate();            // 禁用 listView1 的重绘，以提高性能
            listView1.Items.Clear();            // 清除 listView1 中所有的现有项


            cZero = 0;//计数器清空
            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem();        // 为每一row创建一个新的 ListViewItem
                item.Text = "[" + i.ToString() + ']'; //为每row添加索引

                for (int j = 0; j < cols; j++)
                {
                    int value = rand.Next(2);            // 生成 0 / 1 
                    if (value == 0)
                        cZero++; //如果随机数是0，空闲块数+1
                    item.SubItems.Add(value.ToString());//将随机数输出第i row中
                }
                listView1.Items.Add(item);//将第i row的元素新增到listView1
            }
            label1.Text = "free block: " + cZero.ToString();//显示空闲块数量

            listView1.EndUpdate();    // 重新启用 listView1 的重绘，并刷新显示
        }


        private void buttonFP_Click(object sender, EventArgs e)
        {
            /*
             分配 输入数量 个空闲块
             */
            int number;//初始化number以保存申请的空闲块数
            if (int.TryParse(textBoxFP.Text, out number) && number > 0) //从输入框textBoxFP提取值并保存到number变量，并判断输入值是否为正整数，如否，报错
            {
                if (number > cZero)//判断申请块数是否大于空闲块数，如是，报错
                {
                    MessageBox.Show("输入内容大于可分配块数", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                StringBuilder logBuilder = new StringBuilder();//初始化StringBuilder对象logBuilder，构建日志信息
                // start 检查有没有空闲磁盘块
                for (int i = 0; i < rows && number > 0; i++) //在矩阵范围内判断是否有空闲块&判断是否还需要空闲块
                {
                    for (int j = 1; j <= cols && number > 0; j++) //在矩阵范围内判断是否有空闲块&判断是否还需要空闲块
                    {
                        if (listView1.Items[i].SubItems[j].Text == "0") //如有空闲块
                        {
                            listView1.Items[i].SubItems[j].Text = "1";//使用该空闲块
                            number--;//需要的空闲块-1
                            cZero--;//空闲块数-1

                            int blocknum = i * 32 + j - 1;//转换坐标到块地址

                            int cylinder = blocknum / (4 * 8);//转换块地址到柱面
                            int temp = blocknum % (4 * 8);
                            int head = temp / 8;              //转换块地址到磁头
                            int sector = temp % 8;            //转换块地址到扇区
                            logBuilder.AppendLine($"分配|地址:{blocknum} (柱面:{cylinder} 磁头:{head} 扇区:{sector})");//往logBuilder保存该次申请到的块


                        }
                    }
                }
                textBoxLog.AppendText(logBuilder.ToString());//将累积的申请到的块信息输出到log文本框中
                textBoxLog.AppendText("\r\n");

                label1.Text = "free block: " + cZero.ToString();//刷新空闲块数量标签


            }
            else
            {
                MessageBox.Show("输入内容为非正整数", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




        }

        private void buttonHS_Click(object sender, EventArgs e)
        {
            /*
             回收 输入地址 的磁盘块
             */

            int blocknum;//初始化blocknum变量，以保存需要回收的块地址
            if (int.TryParse(textBoxHS.Text, out blocknum) && blocknum >= 0)//从输入框textBoxHS提取值并保存到blocknum变量，并判断输入值是否为正整数或零，如否，报错
            {
                if (blocknum > 1279)//一共只有1280个磁盘块，如需要回收的块地址超出磁盘块数量，报错
                {
                    MessageBox.Show("输入内容大于块数", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //start 转换块地址到矩阵索引位置
                int i = blocknum / 32;
                int j = blocknum % 32 + 1;//因为col 0 是标签，磁盘块实际从col 1 开始保存
                //end 转换块地址到矩阵索引位置


                if (listView1.Items[i].SubItems[j].Text == "0")//判断是否需要回收的块是否为空闲块，如是，报错
                {
                    MessageBox.Show("输入地址为空闲块", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //进入回收程序
                listView1.Items[i].SubItems[j].Text = "0"; //将该块在矩阵内设为0
                cZero++;//计数器数值+1
                label1.Text = "free block: " + cZero.ToString();//更新空闲块显示标签
                int cylinder = blocknum / (4 * 8);    //转换块地址到柱面 
                int temp = blocknum % (4 * 8);
                int head = temp / 8;                  //转换块地址到磁头
                int sector = temp % 8;                //转换块地址到扇区
                textBoxLog.AppendText($"回收|地址:{blocknum} (柱面:{cylinder} 磁头:{head} 扇区:{sector})\r\n");//输出log信息到输入框textBoxLog

            }
            else
            {
                MessageBox.Show("输入内容为非正整数", "出错", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




        }

        private void buttonSetOne_Click(object sender, EventArgs e)
        {
            /*
            将硬盘块全部设置为占用状态，供调试用
            */
            listView1.BeginUpdate();
            listView1.Items.Clear();

            cZero = 0;
            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "[" + i.ToString() + ']';

                for (int j = 0; j < cols; j++)
                {

                    item.SubItems.Add("1");
                }
                listView1.Items.Add(item);
            }
            label1.Text = "free block: 0";

            listView1.EndUpdate();
        }

        private void buttonSetZero_Click(object sender, EventArgs e)
        {

            /*
            将硬盘块全部设置为空闲状态，供调试用
            */
            listView1.BeginUpdate();
            listView1.Items.Clear();

            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "[" + i.ToString() + ']';

                for (int j = 0; j < cols; j++)
                {
                    item.SubItems.Add("0");
                }
                listView1.Items.Add(item);
            }
            cZero = 1280;
            label1.Text = "free block: 1280";

            listView1.EndUpdate();
        }

        private void buttonbuttonClearLog_Click(object sender, EventArgs e)
        {

            /*
            清除log文本框
             */
            textBoxLog.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            将硬盘块设置为块地址，仅用于调试
            */
            cZero = 1;
            listView1.BeginUpdate();
            listView1.Items.Clear();

            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "[" + i.ToString() + ']';

                for (int j = 0; j < cols; j++)
                {
                    item.SubItems.Add((i * 32 + j).ToString());
                }
                listView1.Items.Add(item);
            }
            label1.Text = "free block: 1";

            listView1.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            回收所有磁盘块，仅用于调试
            */
            for (int i = 0; i < 1280; i++)
            {
                textBoxHS.Text = i.ToString();
                buttonHS_Click(this, EventArgs.Empty);
            }
        }
    }
}
