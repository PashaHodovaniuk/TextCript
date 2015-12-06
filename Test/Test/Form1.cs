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
                Textcript1.Text += mastext[lenkey];
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
            char[,] mastext = new char[8, 9] {{'x','x','x','x','x','x','x','x','x'},{'x','з','д','р','а','в','о','м','ы'}, {'x','с','л','я','щ','и','й','б','г'},
            {'x','е','ё','ж','к','н','п','т','у'}, {'x','ф','х','ц','ч','ш','ъ','ь','э'}, {'x','ю','+','-','/','*','.',',','!'}, 
            {'x','?','(',')','@',' ',':','1','2'}, {'x','3','4','5','6','7','8','9','0'}};
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
            for (int k = 0; k < maschartext.Length; k++)
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
            if (k == 51)
            {
                k = -1;
            }
            k++;
            Numsdv.Text = k.ToString();
            bool flag = false;
            if (k == 0)
                flag = true;
            if (flag)
            {
                Array.Copy(mastex, mastexcopy, mastex.Length);
            }
            string texted = Text3.Text.ToLower();
            char[] maschartext;
            maschartext = texted.ToCharArray();
            if (!flag)
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
                k = 52;
            }
            k--;
            Numsdv.Text = k.ToString();
            bool flag = false;
            if (k == 0)
                flag = true;
            if (flag)
            {
                Array.Copy(mastex, mastexcopy, mastex.Length);
            }
            string texted = Text3.Text.ToLower();
            char[] maschartext;
            maschartext = texted.ToCharArray();
            if (!flag)
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
                mastexcopy[i - 1] = array[i];
            }
            mastexcopy[array.Length - 1] = temp;
        }

        public void arrayRotateRight(char[] array)
        {
            char temp = array[array.Length - 1];
            for (int i = array.Length - 2; i >= 0; i--)
            {
                mastexcopy[i + 1] = array[i];
            }
            mastexcopy[0] = temp;
        }

        private void расшифроватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            decryptiontext2();
        }

        private void decryptiontext2()
        {
            char[,] mastext = new char[8, 9] {{'x','x','x','x','x','x','x','x','x'},{'x','з','д','р','а','в','о','м','ы'}, {'x','с','л','я','щ','и','й','б','г'},
            {'x','е','ё','ж','к','н','п','т','у'}, {'x','ф','х','ц','ч','ш','ъ','ь','э'}, {'x','ю','+','-','/','*','.',',','!'}, 
            {'x','?','(',')','@',' ',':','1','2'}, {'x','3','4','5','6','7','8','9','0'}};
            string texted = DTextcript2.Text.ToLower();
            string[] DText = texted.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string Keid = DKey2.Text.ToLower();
            char[] mascharkey;
            mascharkey = Keid.ToCharArray();
            int RowKey;
            int ColumnKey;
            bool flag;
            int[] LengthKey = new int[mascharkey.Length];
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
            string num = null;
            int p = 0;
            for (int i = 0; i < DText.Length; i++)
            {
                if (p == mascharkey.Length)
                    p = 0;
                num += (int.Parse(DText[i]) - LengthKey[p]).ToString();
                p++;
            }
            for (int t = 1; t < num.Length; t++)
            {
                num = num.Insert(t, " ");
                ++t;
            }
            string[] numkey = num.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;
            int[] rowkey = new int[DText.Length];
            int[] columnkey = new int[DText.Length];
            flag = true;
            int r = 0;
            int c = 0;
            for (int j = 0; j < numkey.Length; j++)
            {
                if (flag)
                {
                    rowkey[r] = int.Parse(numkey[j]);
                    flag = false;
                    r++;
                }
                else
                {
                    columnkey[c] = int.Parse(numkey[j]);
                    flag = true;
                    c++;
                }
            }
            for (int g = 0; g < DText.Length; g++)
            {
                DText2.Text += mastext[rowkey[g], columnkey[g]];
            }
        }

        private void DDecriptbut_Click(object sender, EventArgs e)
        {
            int Numsdv = int.Parse(DNumsdv.Text);
            Array.Copy(mastex, mastexcopy, mastex.Length);
            if ((Numsdv > 0) && (Numsdv <= 52))
            {
                arrayRotate(mastexcopy, Numsdv);
                string texted = DTextcript3.Text.ToLower();
                char[] maschartext;
                maschartext = texted.ToCharArray();
                int[] num = new int[maschartext.Length];
                for (int i = 0; i < maschartext.Length; i++)
                {
                    for (int p = 0; p < mastexcopy.Length; p++)
                    {
                        if (maschartext[i] == mastexcopy[p])
                        {
                            num[i] = p;
                            break;
                        }
                    }
                }
                DText3.Text = null;
                for (int i = 0; i < maschartext.Length; i++)
                {
                    DText3.Text += mastex[num[i]];
                }
            }
            else
            {
                MessageBox.Show("Вы ввели число не входящее в диапазон!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DNumsdv.Focus();
            }
        }

        private void arrayRotate(char[] array, int size)
        {
            for (int j = 0; j < size; j++)
            {
                char temp = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    mastexcopy[i - 1] = array[i];
                }
                mastexcopy[array.Length - 1] = temp;
            }
        }

        private void расшифроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decryptiontext1();
        }

        private void decryptiontext1()
        {
            int maxlentext = 52;
            char[] mastext = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
                'р', 'с', 'т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я','*','/','+','-','.',',','?','!',' ','0','1','2',
                '3','4','5','6','7','8','9'};
            int lenmastext = mastext.Length;
            string texted = Dtextcript1.Text.ToLower();
            char[] maschardtext;
            maschardtext = texted.ToCharArray();
            string[] ttext = DKey1.Text.Split(',');
            int[] masdkey = new int[ttext.Length - 1];
            for (int i = 0; i < ttext.Length - 1; i++)
            {
                masdkey[i] = int.Parse(ttext[i]);
            }
            int key;
            int lenkey;
            int[] dnum = new int[masdkey.Length];
            for (int i = 0; i < maschardtext.Length; i++)
            {
                for (int k = 0; k < mastext.Length; k++)
                {
                    if (maschardtext[i] == mastext[k])
                    {
                        dnum[i] = k;
                        break;
                    }
                }
            }
            key = 0;
            for (int j = 0; j < masdkey.Length; j++)
            {
                key = dnum[j] + masdkey[j];
                if (key >= 52)
                {
                    key = key - maxlentext;
                    lenkey = 0 + Math.Abs(key);
                }
                else
                {
                    lenkey = key;
                }
                DText1.Text += mastext[lenkey];
            }
        }
    }
}