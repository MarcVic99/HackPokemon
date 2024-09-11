using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib;
using static SuperGen.SuperForm;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace SuperGen
{
    public partial class DexManager : Form
    {
        private bool startup = true;
        public bool error = false;
        private BindingSource pokedexBinder = new BindingSource();
        private BindingSource entriesBinder = new BindingSource();
        private BindingSource speciesBinder = new BindingSource();
        public List<Poke> pokemon = new List<Poke>();
        public List<Pokedex> dexes = new List<Pokedex>();
        private List<string> names = new List<string>();

        public DexManager()
        {
            InitializeComponent();
        }

        private void DexManagerV2_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"PBS\editorinfo.txt")) File.Create(@"PBS\editorinfo.txt");
            StreamReader sr = new StreamReader(File.OpenRead(@"PBS\editorinfo.txt"));
            string data = sr.ReadToEnd();
            sr.Close();
            List<string> info = new List<string>();
            info = data.Split('[').ToList();
            for (int i = 1; i < info.Count; i++)
            {
                if (info[i].StartsWith("POKEDEXES"))
                {
                    List<string> dxs = new List<string>();
                    dxs = info[i].Split(new string[] { "]\r\n" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int j = 0; j < dxs.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dxs[j])) continue;
                        string name = dxs[j].Split(new string[] { $"pokedex{j + 1}=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                        names.Add(name);
                    }
                    break;
                }
            }



            for (int i = 0; i < pokemon.Count; i++)
            {
                List<string> dexnums = new List<string>();
                try
                {
                    dexnums = pokemon[i].dexnums.Split(',').ToList();
                }
                catch (Exception) { continue; }
                for (int j = dexes.Count; j < dexnums.Count; j++)
                {
                    dexes.Add(new Pokedex("Untitled Pokédex", new List<DexEntry>()));
                }

                for (int j = 0; j < dexnums.Count; j++)
                {
                    try
                    {
                        dexes[j].entries.Add(new DexEntry(pokemon[i].id, pokemon[i].intname, Convert.ToInt32(dexnums[j])));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"{pokemon[i].intname}'s Pokédex Numbers ({pokemon[i].dexnums}) are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = true;
                        Close();
                        return;
                    }
                }
            }
            for (int i = 0; i < dexes.Count; i++)
            {
                try
                {
                    dexes[i].name = names[i];
                }
                catch (Exception) { }
            }
            pokedexBinder.DataSource = dexes;
            pokedexBox.DataSource = pokedexBinder;
            pokedexBox.DisplayMember = "name";

            entriesBinder.DataSource = dexes[pokedexBox.SelectedIndex].entries;
            entriesBox.DataSource = entriesBinder;
            entriesBox.DisplayMember = "display";

            speciesBinder.DataSource = pokemon;
            comboBox1.DataSource = speciesBinder;
            comboBox1.DisplayMember = "intname";
            startup = false;
            entriesBox.SelectedIndex = 0;
            pokedexBox.SelectedIndex = 0;
        }

        private void pokedexBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startup) return;
            dexes[pokedexBox.SelectedIndex].entries.Sort(delegate (DexEntry de1, DexEntry de2) { return de1.index.CompareTo(de2.index); });
            entriesBinder.ResetBindings(false);
            entriesBinder.DataSource = dexes[pokedexBox.SelectedIndex].entries;
            textBox1.Text = dexes[pokedexBox.SelectedIndex].name;
            numericUpDown1.Value = firstAbleIndex();
            if (dexes[pokedexBox.SelectedIndex].entries.Count > 0)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dexes[pokedexBox.SelectedIndex].name = textBox1.Text;
            pokedexBinder.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dexes.Add(new Pokedex("Untitled Pokédex", new List<DexEntry>()));
            pokedexBinder.ResetBindings(false);
            pokedexBox.SelectedIndex = dexes.Count - 1;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Pokédex and all its Pokémon?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dexes.RemoveAt(pokedexBox.SelectedIndex);
                pokedexBinder.ResetBindings(false);
                if (dexes.Count == 0)
                {
                    button2.Enabled = false;
                }
                else
                {
                    pokedexBox_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void DexManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamReader sr = new StreamReader(File.OpenRead(@"PBS\editorinfo.txt"));
            string data = sr.ReadToEnd();
            sr.Close();
            List<string> info = new List<string>();
            info = data.Split('[').ToList();
            string newinfo = null;
            for (int i = 1; i < info.Count; i++)
            {
                if (info[i].StartsWith("POKEDEXES"))
                {
                    string s = "[POKEDEXES]\r\n";
                    for (int j = 0; j < dexes.Count; j++)
                    {
                        s += $"pokedex{j+1}={dexes[j].name}\r\n";
                    }
                    newinfo += s+"\r\n";
                }
                else
                {
                    newinfo += "["+info[i];
                }
            }
            File.Delete(@"PBS\editorinfo.txt");
            StreamWriter sw = new StreamWriter(File.OpenWrite(@"PBS\editorinfo.txt"));
            sw.Write(newinfo);
            sw.Close();
        }

        private int firstAbleIndex()
        {
            int lastindex = 0;
            for (int i = 0; i < dexes[pokedexBox.SelectedIndex].entries.Count; i++)
            {
                if (lastindex + 1 != dexes[pokedexBox.SelectedIndex].entries[i].index)
                {
                    return lastindex + 1;
                }
                lastindex = dexes[pokedexBox.SelectedIndex].entries[i].index;
            }
            return dexes[pokedexBox.SelectedIndex].entries.Count + 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DexEntry de = new DexEntry(pokemon[comboBox1.SelectedIndex].id, comboBox1.Text, (int) numericUpDown1.Value);
            dexes[pokedexBox.SelectedIndex].entries.Add(de);
            dexes[pokedexBox.SelectedIndex].entries.Sort(delegate (DexEntry de1, DexEntry de2) { return de1.index.CompareTo(de2.index); });
            entriesBinder.ResetBindings(false);
            entriesBox.SelectedIndex = dexes[pokedexBox.SelectedIndex].entries.IndexOf(de);
            numericUpDown1.Value = firstAbleIndex();
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dexes[pokedexBox.SelectedIndex].entries.RemoveAt(entriesBox.SelectedIndex);
            entriesBinder.ResetBindings(false);
            if (dexes[pokedexBox.SelectedIndex].entries.Count == 0) { button3.Enabled = false; }
        }
    }
}
