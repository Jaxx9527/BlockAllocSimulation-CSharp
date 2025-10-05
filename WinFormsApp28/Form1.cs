using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp28
{
    public partial class Form1 : Form
    {



        int rows = 40, cols = 32; //���þ����С ������ 40 rows�� 4*8=32 cols��
        int cZero;//��ʼ����������ļ�����
        public Form1()
        {
            InitializeComponent();

            //start ������ͷ
            listView1.Columns.Add("bit", 40, HorizontalAlignment.Center);
            for (int i = 0; i <= 31; i++)
                listView1.Columns.Add(i.ToString(), 30, HorizontalAlignment.Center);
            //end ������ͷ

            buttonReset_Click(this, EventArgs.Empty); // �����������Ԫ��Ϊ0/1

        }




        private void buttonReset_Click(object sender, EventArgs e)
        {
            /*
            �����������Ԫ��Ϊ0/1
             */

            Random rand = new Random();


            listView1.BeginUpdate();            // ���� listView1 ���ػ棬���������
            listView1.Items.Clear();            // ��� listView1 �����е�������


            cZero = 0;//���������
            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem();        // Ϊÿһrow����һ���µ� ListViewItem
                item.Text = "[" + i.ToString() + ']'; //Ϊÿrow�������

                for (int j = 0; j < cols; j++)
                {
                    int value = rand.Next(2);            // ���� 0 / 1 
                    if (value == 0)
                        cZero++; //����������0�����п���+1
                    item.SubItems.Add(value.ToString());//������������i row��
                }
                listView1.Items.Add(item);//����i row��Ԫ��������listView1
            }
            label1.Text = "free block: " + cZero.ToString();//��ʾ���п�����

            listView1.EndUpdate();    // �������� listView1 ���ػ棬��ˢ����ʾ
        }


        private void buttonFP_Click(object sender, EventArgs e)
        {
            /*
             ���� �������� �����п�
             */
            int number;//��ʼ��number�Ա�������Ŀ��п���
            if (int.TryParse(textBoxFP.Text, out number) && number > 0) //�������textBoxFP��ȡֵ�����浽number���������ж�����ֵ�Ƿ�Ϊ����������񣬱���
            {
                if (number > cZero)//�ж���������Ƿ���ڿ��п��������ǣ�����
                {
                    MessageBox.Show("�������ݴ��ڿɷ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                StringBuilder logBuilder = new StringBuilder();//��ʼ��StringBuilder����logBuilder��������־��Ϣ
                // start �����û�п��д��̿�
                for (int i = 0; i < rows && number > 0; i++) //�ھ���Χ���ж��Ƿ��п��п�&�ж��Ƿ���Ҫ���п�
                {
                    for (int j = 1; j <= cols && number > 0; j++) //�ھ���Χ���ж��Ƿ��п��п�&�ж��Ƿ���Ҫ���п�
                    {
                        if (listView1.Items[i].SubItems[j].Text == "0") //���п��п�
                        {
                            listView1.Items[i].SubItems[j].Text = "1";//ʹ�øÿ��п�
                            number--;//��Ҫ�Ŀ��п�-1
                            cZero--;//���п���-1

                            int blocknum = i * 32 + j - 1;//ת�����굽���ַ

                            int cylinder = blocknum / (4 * 8);//ת�����ַ������
                            int temp = blocknum % (4 * 8);
                            int head = temp / 8;              //ת�����ַ����ͷ
                            int sector = temp % 8;            //ת�����ַ������
                            logBuilder.AppendLine($"����|��ַ:{blocknum} (����:{cylinder} ��ͷ:{head} ����:{sector})");//��logBuilder����ô����뵽�Ŀ�


                        }
                    }
                }
                textBoxLog.AppendText(logBuilder.ToString());//���ۻ������뵽�Ŀ���Ϣ�����log�ı�����
                textBoxLog.AppendText("\r\n");

                label1.Text = "free block: " + cZero.ToString();//ˢ�¿��п�������ǩ


            }
            else
            {
                MessageBox.Show("��������Ϊ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




        }

        private void buttonHS_Click(object sender, EventArgs e)
        {
            /*
             ���� �����ַ �Ĵ��̿�
             */

            int blocknum;//��ʼ��blocknum�������Ա�����Ҫ���յĿ��ַ
            if (int.TryParse(textBoxHS.Text, out blocknum) && blocknum >= 0)//�������textBoxHS��ȡֵ�����浽blocknum���������ж�����ֵ�Ƿ�Ϊ���������㣬��񣬱���
            {
                if (blocknum > 1279)//һ��ֻ��1280�����̿飬����Ҫ���յĿ��ַ�������̿�����������
                {
                    MessageBox.Show("�������ݴ��ڿ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //start ת�����ַ����������λ��
                int i = blocknum / 32;
                int j = blocknum % 32 + 1;//��Ϊcol 0 �Ǳ�ǩ�����̿�ʵ�ʴ�col 1 ��ʼ����
                //end ת�����ַ����������λ��


                if (listView1.Items[i].SubItems[j].Text == "0")//�ж��Ƿ���Ҫ���յĿ��Ƿ�Ϊ���п飬���ǣ�����
                {
                    MessageBox.Show("�����ַΪ���п�", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //������ճ���
                listView1.Items[i].SubItems[j].Text = "0"; //���ÿ��ھ�������Ϊ0
                cZero++;//��������ֵ+1
                label1.Text = "free block: " + cZero.ToString();//���¿��п���ʾ��ǩ
                int cylinder = blocknum / (4 * 8);    //ת�����ַ������ 
                int temp = blocknum % (4 * 8);
                int head = temp / 8;                  //ת�����ַ����ͷ
                int sector = temp % 8;                //ת�����ַ������
                textBoxLog.AppendText($"����|��ַ:{blocknum} (����:{cylinder} ��ͷ:{head} ����:{sector})\r\n");//���log��Ϣ�������textBoxLog

            }
            else
            {
                MessageBox.Show("��������Ϊ��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




        }

        private void buttonSetOne_Click(object sender, EventArgs e)
        {
            /*
            ��Ӳ�̿�ȫ������Ϊռ��״̬����������
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
            ��Ӳ�̿�ȫ������Ϊ����״̬����������
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
            ���log�ı���
             */
            textBoxLog.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            ��Ӳ�̿�����Ϊ���ַ�������ڵ���
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
            �������д��̿飬�����ڵ���
            */
            for (int i = 0; i < 1280; i++)
            {
                textBoxHS.Text = i.ToString();
                buttonHS_Click(this, EventArgs.Empty);
            }
        }
    }
}
