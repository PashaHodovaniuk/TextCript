using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class CriptoText : Form
    {
        char[] mastex = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                'р', 'с', 'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я','*','/','+','-','.',',','?','!',' ','0','1','2',
                '3','4','5','6','7','8','9'};
        char[] mastexcopy = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                'р', 'с', 'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я','*','/','+','-','.',',','?','!',' ','0','1','2',
                '3','4','5','6','7','8','9'};
        
        public CriptoText()
        {
            InitializeComponent();            
            
        }

        private void генерироватьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Key1.Clear();
            Random rand = new Random();
            Int32 len = Text1.Text.Length;
            int[] m = new int[len];
            for (int i = 0; i < len; i++)
            {
                m[i] = rand.Next(0, 53);
            }
            for (int i = 0; i < len; i++)
            {
                Key1.Text += m[i] + ", ";
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Key1.Clear();
        }

        private void шифроварьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Textcript1.Clear();
            encrypriontext1();
        }

        private void encrypriontext1()
        {
            long maxlentext = 52;
            char[] mastext = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                'р', 'с', 'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я','*','/','+','-','.',',','?','!',' ','0','1','2',
                '3','4','5','6','7','8','9'};
            long lenmastext = mastext.Length;
            string texted = Text1.Text.ToLower();
            char[] maschartext;
            maschartext = texted.ToCharArray();
            string[] ttext = Key1.Text.Split(',');
            long[] maskey = new long[ttext.Length - 1];
            for (int i = 0; i < ttext.Length - 1; i++)
                maskey[i] = long.Parse(ttext[i]);
            long key;
            long lenkey;
            long[] num = new long[maskey.Length];
            for (int i = 0; i < maschartext.Length; i++)
            {

                for (long k = 0; k < mastext.Length; k++)
                {
                    if (maschartext[i] == mastext[k])
                    {
                        num[i] = k;
                        break;
                    }
                }
            }

            key = 0;
            for (int j = 0; j < maskey.Length; j++)
            {
                key = num[j] - maskey[j];
                if (key < 0)
                {
                    lenkey = maxlentext - Math.Abs(key);
                }
                else
                {
                    lenkey = key;
                }
                Textcript1.Text += mastext[lenkey] + " ";
            }

        }

        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Textcript1.Clear();
        }

        private void очиститьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Key2.Clear();
        }

        private void очиститьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Textcript2.Clear();
        }

        private void encrypriontext2()
        {
            char[,] mastext = new char[8, 9] {{'1','з','д','р','а','в','о','м','ы'},{'1','з','д','р','а','в','о','м','ы'}, {'1','с','л','я','щ','и','й','б','г'},
            {'1','е','ё','ж','к','н','п','т','у'}, {'1','ф','х','ц','ч','ш','ъ','ь','э'}, {'1','ю','+','-','/','*','.',',','!'}, 
            {'1','?','(',')','@',' ',':','1','2'}, {'1','3','4','5','6','7','8','9','0'}};
            string texted = Text2.Text.ToLower();
            char[] maschartext;
            maschartext = texted.ToCharArray();
            string Keid = Key2.Text.ToLower();
            char[] mascharkey;
            mascharkey = Keid.ToCharArray();
            int RowText;
            int ColumnText;
            int RowKey;
            int ColumnKey;
            int[] LengthText = new int[maschartext.Length];
            int[] LengthKey = new int[mascharkey.Length];
            int[] Key = new int[maschartext.Length];
            bool flag;
            //bool flaglen = false;
            for (int k=0; k<maschartext.Length;k++)
            {
                flag = false;
                RowText = 0;
                ColumnText = 0;
                for (int i = 1; i < 8; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (mastext[i, j] == maschartext[k])
                        {
                            RowText = i;
                            ColumnText = j;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        LengthText[k] = int.Parse(RowText.ToString() + ColumnText.ToString());
                        break;
                    }

                }
                 
            }
            for (int k = 0; k < mascharkey.Length; k++)
            {
                flag = false;
                RowKey = 0;
                ColumnKey = 0;
                for (int i = 1; i < 8; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (mastext[i, j] == mascharkey[k])
                        {
                            RowKey = i;
                            ColumnKey = j;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        LengthKey[k] = int.Parse(RowKey.ToString() + ColumnKey.ToString());                        
                        break;
                    }
                }
                
            }
            int p = 0;
            for (int i = 0; i < maschartext.Length; i++)
            {
                if (p == mascharkey.Length)
                    p = 0;
                Key[i] = LengthText[i] + LengthKey[p];
                Textcript2.Text += Key[i].ToString() + " ";
                p++;
            }
        }

        private void шифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrypriontext2();
        }

        private void Text3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                if (Textcript3.TextLength >= 1)
                {
                    Textcript3.Text = Textcript3.Text.Remove(Textcript3.TextLength - 1, 1);
                }
            }
            else
            {
                Textcript3.Text += e.KeyChar;
            }
            if (Text3.TextLength <= 1)
                Numsdv.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            k = int.Parse(Numsdv.Text);
            if (k == 52)
            {
                k = -1;
            }
            k++;
            Numsdv.Text = k.ToString();
            string texted = Text3.Text.ToLower();
            char[] maschartext;            
            maschartext = texted.ToCharArray();
            arrayRotateLeft(mastexcopy);
            int[] num = new int[maschartext.Length];
            for (int i = 0; i < maschartext.Length; i++)
            {

                for (int p = 0; p < mastex.Length; p++)
                {
                    if (maschartext[i] == mastex[p])
                    {
                        num[i] = p;
                        break;
                    }
                }
            }
            Textcript3.Text = null;
            for (int i = 0; i < maschartext.Length; i++)
            {
                Textcript3.Text += mastexcopy[num[i]];
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 0;
            k = int.Parse(Numsdv.Text);
            if (k == 0)
            {
                k = 53;
            }
            k--;
            Numsdv.Text = k.ToString();
            string texted = Text3.Text.ToLower();
            char[] maschartext;
            maschartext = texted.ToCharArray();
            arrayRotateRight(mastexcopy);
            int[] num = new int[maschartext.Length];
            for (int i = 0; i < maschartext.Length; i++)
            {

                for (int p = 0; p < mastex.Length; p++)
                {
                    if (maschartext[i] == mastex[p])
                    {
                        num[i] = p;
                        break;
                    }
                }
            }
            Textcript3.Text = null;
            for (int i = 0; i < maschartext.Length; i++)
            {
                Textcript3.Text += mastexcopy[num[i]];
            }

        }
       
        public void arrayRotateLeft(char[] array) 
        {            
            char temp = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                mastexcopy[i-1] = array[i];
            }
            mastexcopy[array.Length - 1] = temp;
        }

        public void arrayRotateRight(char[] array)
        {
            char temp = array[array.Length-1];
            for (int i = array.Length - 2; i >= 0; i--)
            {
                mastexcopy[i+1] = array[i];
            }
            mastexcopy[0] = temp;
        }
    }
}
