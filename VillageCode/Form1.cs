using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VillageCode
{
    public partial class Form1 : Form
    {
        Dictionary<char, char> alphabet = new Dictionary<char, char>();
        public void FillAlphabet()
        {
            alphabet.Clear();
            //alphabet.Add('ا', 'A');
            alphabet.Add('آ', 'A');
            alphabet.Add('ب', 'B');
            alphabet.Add('پ', 'P');
            alphabet.Add('ت', 'T');
            alphabet.Add('ث', 'S');
            alphabet.Add('ج', 'J');
            alphabet.Add('چ', 'C');
            alphabet.Add('ح', 'H');
            alphabet.Add('خ', 'K');
            alphabet.Add('د', 'D');
            alphabet.Add('ذ', 'Z');
            alphabet.Add('ر', 'R');
            alphabet.Add('ز', 'Z');
            alphabet.Add('ژ', 'Z');
            alphabet.Add('س', 'S');
            alphabet.Add('ش', 'S');
            alphabet.Add('ص', 'S');
            alphabet.Add('ض', 'Z');
            alphabet.Add('ط', 'T');
            alphabet.Add('ظ', 'Z');
            alphabet.Add('ع', 'A');
            alphabet.Add('غ', 'G');
            alphabet.Add('ف', 'F');
            alphabet.Add('ق', 'Q');
            alphabet.Add('ک', 'K');
            alphabet.Add('ك', 'K');
            alphabet.Add('گ', 'G');
            alphabet.Add('ل', 'L');
            alphabet.Add('م', 'M');
            alphabet.Add('ن', 'N');
            alphabet.Add('و', 'V');
            alphabet.Add('ه', 'H');
            alphabet.Add('ی', 'Y');
            alphabet.Add('ي', 'Y');
        }
        public Form1()
        {
            InitializeComponent();
            FillAlphabet();
        }
        List<string> converted = new List<string>();
        List<string> shortlist = new List<string>();
        string temp = "";
        char[] temp2 = "xxx".ToCharArray();
        private void button1_Click(object sender, EventArgs e)
        {
            char tempCh;
            foreach (string item in textBox1.Text.Split('\n'))
            {
                foreach (char ch in item.ToCharArray())
                {
                    if (alphabet.TryGetValue(ch, out tempCh))
                    {
                        temp += tempCh;
                    }
                }
                converted.Add(temp);
                temp = "";
            }
            converted.ForEach(s => textBox2.Text += (s + "\r\n"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string s in converted)
            {
                if (string.IsNullOrWhiteSpace(s)) continue;
               
                temp2[0] = s[0];

                temp2[1] = s.Length > 1 ? s[1] : 'x';

                temp2[2] = s.Length > 2 ? s[2] : 'x';
                if (!shortlist.Contains(new String(temp2)))
                    shortlist.Add(new String(temp2));
                else
                {
                    temp2[0] = s[0];
                    
                    for (int i = 3; i < s.Length; i++)
                    {
                        temp2[2] = s[i];
                        if (!shortlist.Contains(new String(temp2))) break;
                        for (int j = 2; j < s.Length; j++)
                        {                           
                            temp2[1] = s[j];
                            if (!shortlist.Contains(new String(temp2))) break;
                        }
                        
                    }
                    if (!shortlist.Contains(new String(temp2)))
                        shortlist.Add(new String(temp2));
                    else
                        shortlist.Add("xxx");
                }                
            }
            shortlist.ForEach(s => textBox3.Text += (s + "\r\n"));
        }
    }
}
