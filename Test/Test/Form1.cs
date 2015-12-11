using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Test
{
    public partial class CriptoText : Form
    {
        string rFile;
        Bitmap bPic;
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
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            Textcript1.Clear();
            encrypriontext1();
            timecript.Stop();
            timecript1.Text = timecript.Elapsed.ToString();
            timecript.Reset();
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
                for (long k = 0; k < mastext.Length-1; k++)
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
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            Textcript2.Clear();
            encrypriontext2();
            timecript.Stop();
            Timecript2.Text = timecript.Elapsed.ToString();
            timecript.Reset();            
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

        private void encrypriontext31()
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


        private void encrypriontext32()
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
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            DText2.Clear();
            decryptiontext2();
            timecript.Stop();
            TimeDecript2.Text = timecript.Elapsed.ToString();
            timecript.Reset();  
            
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
        private void decryptiontext3()
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
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            DText1.Clear();
            decryptiontext1();
            timecript.Stop();
            Timedecript1.Text = timecript.Elapsed.ToString();
            timecript.Reset();            
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
            int[] dnum = new int[maschardtext.Length];
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

        private void Text3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                IDataObject iData = Clipboard.GetDataObject();

                if (iData.GetDataPresent(DataFormats.Text))
                {
                    Text3.Text = (String)iData.GetData(DataFormats.Text);
                }
                Textcript3.Text = Text3.Text;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            encrypriontext31();
            timecript.Stop();
            Timecript3.Text = timecript.Elapsed.ToString();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            encrypriontext32();
            timecript.Stop();
            Timecript3.Text = timecript.Elapsed.ToString();
        }

        private void DDecriptbut_MouseUp(object sender, MouseEventArgs e)
        {
            Stopwatch timecript = new Stopwatch();
            timecript.Start();
            decryptiontext3();
            timecript.Stop();
            TimeDecript3.Text = timecript.Elapsed.ToString();
            timecript.Reset();
        }

        private void OpenImg_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            rFile = openFileDialog1.FileName.ToString();
                            bPic = new Bitmap(rFile);
                            pictureBox1.Image = bPic;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            bool st = false;
            for (int i = 0; i < 8; i++)
            {
                if ((src >> i & 1) == 1)
                {
                    st = true;
                }
                else st = false;
                bitArray[i] = st;
            }
            return bitArray;
        }

        private byte BitToByte(BitArray scr)
        {
            byte num = 0;
            for (int i = 0; i < scr.Count; i++)
                if (scr[i] == true)
                    num += (byte)Math.Pow(2, i);
            return num;
        }


        private bool isEncryption(Bitmap scr)
        {
            byte[] rez = new byte[1];
            Color color = scr.GetPixel(0, 0);
            BitArray colorArray = ByteToBit(color.R); //получаем байт цвета и преобразуем в массив бит
            BitArray messageArray = ByteToBit(color.R); ;//инициализируем результирующий массив бит
            messageArray[0] = colorArray[0];
            messageArray[1] = colorArray[1];

            colorArray = ByteToBit(color.G);//получаем байт цвета и преобразуем в массив бит
            messageArray[2] = colorArray[0];
            messageArray[3] = colorArray[1];
            messageArray[4] = colorArray[2];

            colorArray = ByteToBit(color.B);//получаем байт цвета и преобразуем в массив бит
            messageArray[5] = colorArray[0];
            messageArray[6] = colorArray[1];
            messageArray[7] = colorArray[2];
            rez[0] = BitToByte(messageArray); //получаем байт символа, записанного в 1 пикселе
            string m = Encoding.GetEncoding(1251).GetString(rez);
            if (m == "/")
            {
                return true;
            }
            else return false;
        }

        private void WriteCountText(int count, Bitmap src)
        {
            byte[] CountSymbols = Encoding.GetEncoding(1251).GetBytes(count.ToString());
            for (int i = 0; i < 3; i++)
            {
                BitArray bitCount = ByteToBit(CountSymbols[i]); //биты количества символов
                Color pColor = src.GetPixel(0, i + 1); //1, 2, 3 пикселы
                BitArray bitsCurColor = ByteToBit(pColor.R); //бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[0];
                bitsCurColor[1] = bitCount[1];
                byte nR = BitToByte(bitsCurColor); //новый бит цвета пиксея

                bitsCurColor = ByteToBit(pColor.G);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[2];
                bitsCurColor[1] = bitCount[3];
                bitsCurColor[2] = bitCount[4];
                byte nG = BitToByte(bitsCurColor);//новый цвет пиксея

                bitsCurColor = ByteToBit(pColor.B);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[5];
                bitsCurColor[1] = bitCount[6];
                bitsCurColor[2] = bitCount[7];
                byte nB = BitToByte(bitsCurColor);//новый цвет пиксея

                Color nColor = Color.FromArgb(nR, nG, nB); //новый цвет из полученных битов
                src.SetPixel(0, i + 1, nColor); //записали полученный цвет в картинку
            }
        }

        private int ReadCountText(Bitmap src)
        {
            byte[] rez = new byte[3]; //массив на 3 элемента, т.е. максимум 999 символов шифруется
            for (int i = 0; i < 3; i++)
            {
                Color color = src.GetPixel(0, i + 1); //цвет 1, 2, 3 пикселей 
                BitArray colorArray = ByteToBit(color.R); //биты цвета
                BitArray bitCount = ByteToBit(color.R); ; //инициализация результирующего массива бит
                bitCount[0] = colorArray[0];
                bitCount[1] = colorArray[1];

                colorArray = ByteToBit(color.G);
                bitCount[2] = colorArray[0];
                bitCount[3] = colorArray[1];
                bitCount[4] = colorArray[2];

                colorArray = ByteToBit(color.B);
                bitCount[5] = colorArray[0];
                bitCount[6] = colorArray[1];
                bitCount[7] = colorArray[2];
                rez[i] = BitToByte(bitCount);
            }
            string m = Encoding.GetEncoding(1251).GetString(rez);
            return Convert.ToInt32(m, 10);
        }

        private void Steganograf1(Stream rText)
        {
            BinaryReader bText = new BinaryReader(rText, Encoding.ASCII);

            List<byte> bList = new List<byte>();
            while (bText.PeekChar() != -1)
            {
                bList.Add(bText.ReadByte());
            }
            int CountText = bList.Count;
            bText.Close();

            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                MessageBox.Show("Выбранная картинка мала для размещения выбранного текста", "Информация", MessageBoxButtons.OK);
                return;
            }

            if (isEncryption(bPic))
            {
                MessageBox.Show("Файл уже зашифрован", "Информация", MessageBoxButtons.OK);
                return;
            }

            byte[] Symbol = Encoding.GetEncoding(1251).GetBytes("/");
            BitArray ArrBeginSymbol = ByteToBit(Symbol[0]);
            Color curColor = bPic.GetPixel(0, 0);
            BitArray tempArray = ByteToBit(curColor.R);
            tempArray[0] = ArrBeginSymbol[0];
            tempArray[1] = ArrBeginSymbol[1];
            byte nR = BitToByte(tempArray);

            tempArray = ByteToBit(curColor.G);
            tempArray[0] = ArrBeginSymbol[2];
            tempArray[1] = ArrBeginSymbol[3];
            tempArray[2] = ArrBeginSymbol[4];
            byte nG = BitToByte(tempArray);

            tempArray = ByteToBit(curColor.B);
            tempArray[0] = ArrBeginSymbol[5];
            tempArray[1] = ArrBeginSymbol[6];
            tempArray[2] = ArrBeginSymbol[7];
            byte nB = BitToByte(tempArray);

            Color nColor = Color.FromArgb(nR, nG, nB);
            bPic.SetPixel(0, 0, nColor);

            WriteCountText(CountText, bPic); //записываем количество символов исходного текста

            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == bList.Count)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = ByteToBit(pixelColor.R);
                    BitArray messageArray = ByteToBit(bList[index]);
                    colorArray[0] = messageArray[0]; //меняем
                    colorArray[1] = messageArray[1]; // в нашем цвете биты
                    byte newR = BitToByte(colorArray);

                    colorArray = ByteToBit(pixelColor.G);
                    colorArray[0] = messageArray[2];
                    colorArray[1] = messageArray[3];
                    colorArray[2] = messageArray[4];
                    byte newG = BitToByte(colorArray);

                    colorArray = ByteToBit(pixelColor.B);
                    colorArray[0] = messageArray[5];
                    colorArray[1] = messageArray[6];
                    colorArray[2] = messageArray[7];
                    byte newB = BitToByte(colorArray);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    bPic.SetPixel(i, j, newColor);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }
        }

        private void Metod1_Click(object sender, EventArgs e)
        {
            string text = Textcript1.Text;
            byte[] temp = Encoding.Unicode.GetBytes(text);
            Stream stream = new MemoryStream(temp);
            Steganograf1(stream);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bPic.Save(saveFileDialog1.FileName);
                return;
            }
        }

        private void Metod2_Click(object sender, EventArgs e)
        {
            string text = Textcript2.Text;
            byte[] temp = Encoding.Unicode.GetBytes(text);
            Stream stream = new MemoryStream(temp);
            Steganograf1(stream);
        }

        private void Metod3_Click(object sender, EventArgs e)
        {
            string text = Textcript3.Text;
            byte[] temp = Encoding.Unicode.GetBytes(text);
            Stream stream = new MemoryStream(temp);
            Steganograf1(stream);
        }
    }
}