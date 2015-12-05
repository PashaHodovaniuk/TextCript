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
            encrypriontext();
        }

        private void encrypriontext()
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

       
    }
}
