using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using lib;
using System.Linq;
using WMPLib;
using MiscGen;
using MoveGen;
using System.Diagnostics;
using static SuperGen.SuperForm;

namespace SuperGen
{
    public partial class TrainerClassForm : Form
    {
        private bool msg = true;
        private bool canPlay = true;
        private bool terminate = false;
        WindowsMediaPlayer player;
        private BindingSource classBinder = new BindingSource();
        private List<Class> classes = new List<Class>();

        public TrainerClassForm()
        {
            InitializeComponent();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Properties.Settings.Default.Save();

                msg = false;
                player.controls.stop();
                Close();
                Dispose();
            }
        }

        private void TrainerClassForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"PBS\trainertypes.txt")) { try {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\trainertypes.txt"));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Trainer Class Editor", "trainertypes");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> entries = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < entries.Count; i++)
                    {
                        try
                        {
                            if (!entries[i].StartsWith("#") && !entries[i].StartsWith(" ") && !entries[i].StartsWith("\r\n") && entries[i].Length > 0) {
                                bool cont = true;
                                List<string> line = entries[i].Split(',').ToList();
                                int id = Convert.ToInt32(line[0]);
                                string name = line[2];
                                string intname = line[1];
                                int? money = null;
                                string bgmusic = null;
                                string victorymusic = null;
                                string intromusic = null;
                                string gender = null;
                                int? skill = null;
                                try { money = Convert.ToInt32(line[3]); }
                                catch (Exception) {
                                    money = null;
                                    bgmusic = null;
                                    victorymusic = null;
                                    intromusic = null;
                                    gender = null;
                                    skill = null;
                                    cont = false; }
                                if (cont) {
                                    try { bgmusic = line[4]; }
                                    catch (Exception) {
                                        bgmusic = null;
                                        victorymusic = null;
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false; } }
                                if (cont) {
                                    try { victorymusic = line[5]; }
                                    catch (Exception) {
                                        victorymusic = null;
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false; } }
                                if (cont) {
                                    try { intromusic = line[6]; }
                                    catch (Exception) {
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false; } }
                                if (cont) {
                                    try { gender = line[7]; }
                                    catch (Exception) {
                                        gender = null;
                                        skill = null;
                                        cont = false; } }
                                if (cont) {
                                    try { skill = Convert.ToInt32(line[8]); }
                                    catch (Exception) {
                                        skill = null;
                                        cont = false; } }
                                classes.Add(new Class(id, name, intname, money, bgmusic, victorymusic, intromusic, gender, skill));
                            }
                        }
                        catch (Exception)
                        {
                            SuperForm.invalidLine("trainertypes", entries[i], "Trainer Class Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                catch (Exception) {
                    MessageBox.Show("Something went wrong while converting data inside \"trainertypes.txt\".","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                SuperForm.fileNotFound("trainertypes", "Trainer Class Editor");
                terminate = true;
                Close();
                return;
            }

            classBinder.DataSource = classes;
            classBox.DataSource = classBinder;
            classBox.DisplayMember = "intname";
            Class c = classes[0];
            switch (Properties.Settings.Default.ClassSortMethod)
            {
                case "ID": classes.Sort(delegate (Class c1, Class c2) { return c1.id.CompareTo(c2.id); }); break;
                case "DisplayName": classes.Sort(delegate (Class c1, Class c2) { return c1.name.CompareTo(c2.name); }); break;
                case "InternalName": classes.Sort(delegate (Class c1, Class c2) { return c1.intname.CompareTo(c2.intname); }); break;
                case "Money": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMoney().CompareTo(c2.getSortableMoney()); }); classes.Reverse(); break;
                case "BGMusic": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(1).CompareTo(c2.getSortableMusic(1)); }); classes.Reverse(); break;
                case "VictoryMusic": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(2).CompareTo(c2.getSortableMusic(2)); }); classes.Reverse(); break;
                case "IntroMusic": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(3).CompareTo(c2.getSortableMusic(3)); }); classes.Reverse(); break;
                case "Gender": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableGender().CompareTo(c2.getSortableGender()); }); break;
                case "Skill": classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableSkill().CompareTo(c2.getSortableSkill()); }); classes.Reverse(); break;
                default: Properties.Settings.Default.ClassSortMethod = "InternalName"; break;
            }
            classBinder.ResetBindings(false);
            classBox.SelectedIndex = classes.IndexOf(c);
            try
            {
                player = new WindowsMediaPlayer();
            }
            catch (Exception)
            {
                canPlay = false;
            }
        }
        private void TrainerClassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.close();
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void classBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classes.Count > 0)
            {
                requiredFields.Enabled = true;
                volumeBox.Enabled = true;
                label10.Enabled = true;
                optionalFields.Enabled = true;
                idBox.Value = classes[classBox.SelectedIndex].id;
                nameBox.Text = classes[classBox.SelectedIndex].name;
                intnameBox.Text = classes[classBox.SelectedIndex].intname;
                if (classes[classBox.SelectedIndex].money != null && classes[classBox.SelectedIndex].money != 30) { moneyBox.Value = (int)classes[classBox.SelectedIndex].money; moneyBox.Enabled = true; defaultMoney.Checked = false; }
                else { moneyBox.Enabled = false; defaultMoney.Checked = true; moneyBox.Value = 30; }
                if (!string.IsNullOrEmpty(classes[classBox.SelectedIndex].bgmusic)) { bgMusic.Text = classes[classBox.SelectedIndex].bgmusic; bgMusic.Enabled = true; defaultBGMusic.Checked = false; }
                else { bgMusic.Enabled = false; defaultBGMusic.Checked = true; }
                if (!string.IsNullOrEmpty(classes[classBox.SelectedIndex].victorymusic)) { victoryMusic.Text = classes[classBox.SelectedIndex].victorymusic; victoryMusic.Enabled = true; defaultVictoryMusic.Checked = false; }
                else { victoryMusic.Enabled = false; defaultVictoryMusic.Checked = true; }
                if (!string.IsNullOrEmpty(classes[classBox.SelectedIndex].intromusic)) { introMusic.Text = classes[classBox.SelectedIndex].intromusic; introMusic.Enabled = true; defaultIntroMusic.Checked = false; }
                else { introMusic.Enabled = false; defaultIntroMusic.Checked = true; }
                if (!string.IsNullOrEmpty(classes[classBox.SelectedIndex].gender)) { genderBox.Text = classes[classBox.SelectedIndex].gender; genderBox.Enabled = true; defaultGender.Checked = false; }
                else { genderBox.Enabled = false; defaultGender.Checked = true; }
                if (classes[classBox.SelectedIndex].skill != null && classes[classBox.SelectedIndex].skill != classes[classBox.SelectedIndex].money) { skillBox.Value = (int)classes[classBox.SelectedIndex].skill; skillBox.Enabled = true; defaultSkill.Checked = false; }
                else { skillBox.Enabled = false; defaultSkill.Checked = true; skillBox.Value = moneyBox.Value; }
            }
            else
            {
                requiredFields.Enabled = false;
                volumeBox.Enabled = false;
                label10.Enabled = false;
                optionalFields.Enabled = false;
            }
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].id = (int)idBox.Value;
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].name = nameBox.Text;
        }
        private void intnameBox_TextChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].intname = intnameBox.Text;
        }
        private void moneyBox_ValueChanged(object sender, EventArgs e)
        {
            if (moneyBox.Value == 30) { classes[classBox.SelectedIndex].money = null; }
            else { classes[classBox.SelectedIndex].money = (int)moneyBox.Value; }
        }
        private void bgMusic_TextChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].bgmusic = bgMusic.Text;
        }
        private void victoryMusic_TextChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].victorymusic = victoryMusic.Text;
        }
        private void introMusic_TextChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].intromusic = introMusic.Text;
        }
        private void genderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            classes[classBox.SelectedIndex].gender = genderBox.Text;
        }
        private void skillBox_ValueChanged(object sender, EventArgs e)
        {
            if (skillBox.Value == moneyBox.Value) { classes[classBox.SelectedIndex].skill = null; defaultSkill.Checked = true; }
            else { classes[classBox.SelectedIndex].skill = (int)skillBox.Value; }
        }

        private void defaultMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultMoney.Checked)
            {
                moneyBox.Value = 30; classes[classBox.SelectedIndex].money = null;  moneyBox.Enabled = false;
            }
            else
            {
                moneyBox.Enabled = true;
            }
        }
        private void defaultBGMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultBGMusic.Checked)
            {
                bgMusic.Text = null; classes[classBox.SelectedIndex].bgmusic = null;  bgMusic.Enabled = false;
            }
            else
            {
                bgMusic.Enabled = true;
            }
        }
        private void defaultVictoryMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultVictoryMusic.Checked)
            {
                victoryMusic.Text = null; classes[classBox.SelectedIndex].victorymusic = null; victoryMusic.Enabled = false;
            }
            else
            {
                victoryMusic.Enabled = true;
            }
        }
        private void defaultIntroMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultIntroMusic.Checked)
            {
                introMusic.Text = null; classes[classBox.SelectedIndex].intromusic = null; introMusic.Enabled = false;
            }
            else
            {
                introMusic.Enabled = true;
            }
        }
        private void defaultGender_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultGender.Checked)
            {
                genderBox.Text = "Mixed"; classes[classBox.SelectedIndex].gender = null;genderBox.Enabled = false;
            }
            else
            {
                genderBox.Enabled = true;
            }
        }
        private void defaultSkill_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultSkill.Checked)
            {
                skillBox.Value = moneyBox.Value; classes[classBox.SelectedIndex].skill = null; skillBox.Enabled = false;
            }
            else
            {
                skillBox.Enabled = true;
            }
        }

        private void browseBGMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Directory.Exists(@"Audio\BGM")) { ofd.InitialDirectory = @"Audio\BGM"; }
            else { ofd.InitialDirectory = Application.CommonAppDataPath; }
            ofd.Title = "Choose Background Music";
            ofd.Filter = "All Files (*.*)|*.*|"
                + "OGG Verbis (*.ogg)|*.ogg|"
                + "MP3 File (*.mp3)|*.mp3|"
                + "WAV File (*.wav)|*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(@"Audio\BGM");
                List<string> temp = ofd.FileName.Split('\\').Last().Split('.').ToList();
                string retval = null;
                for (int i = 0; i < temp.Count; i++) {
                    if (i == 0) { retval += temp[0]; }
                    else if (i != temp.Count - 1) { retval += "." + temp[i]; } }
                bgMusic.Text = retval;
                if (!File.Exists($@"Audio\BGM\{ofd.FileName.Split('\\').Last()}"))
                { File.Copy(ofd.FileName, $@"Audio\BGM\{retval}.{temp.Last()}"); }
                if (bgMusic.Text.Length > 0) { defaultBGMusic.Checked = false; bgMusic.Enabled = true; }
            }
        }
        private void browseVictoryMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Directory.Exists(@"Audio\BGM")) { ofd.InitialDirectory = @"Audio\BGM"; }
            else { ofd.InitialDirectory = Application.CommonAppDataPath; }
            ofd.Title = "Choose Victory Music";
            ofd.Filter = "All Files (*.*)|*.*|"
                + "OGG Verbis (*.ogg)|*.ogg|"
                + "MP3 File (*.mp3)|*.mp3|"
                + "WAV File (*.wav)|*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> temp = ofd.FileName.Split('\\').Last().Split('.').ToList();
                string retval = null;
                for (int i = 0; i < temp.Count; i++) {
                    if (i == 0) { retval += temp[0]; }
                    else if (i != temp.Count - 1) { retval += "." + temp[i]; } }
                victoryMusic.Text = retval;
                if (!File.Exists($@"Audio\BGM\{ofd.FileName.Split('\\').Last()}"))
                { File.Copy(ofd.FileName, $@"Audio\BGM\{retval}.{temp.Last()}"); }
                if (victoryMusic.Text.Length > 0) { defaultVictoryMusic.Checked = false; victoryMusic.Enabled = true; }
            }
        }
        private void browseIntroMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Directory.Exists(@"Audio\ME")) { ofd.InitialDirectory = @"Audio\ME"; }
            else { ofd.InitialDirectory = Application.CommonAppDataPath; }
            ofd.Title = "Choose Intro Music";
            ofd.Filter = "All Files (*.*)|*.*|"
                + "OGG Verbis (*.ogg)|*.ogg|"
                + "MP3 File (*.mp3)|*.mp3|"
                + "WAV File (*.wav)|*.wav|"
                + "MIDI file (*.mid)|*.mid";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> temp = ofd.FileName.Split('\\').Last().Split('.').ToList();
                string retval = null;
                for (int i = 0; i < temp.Count; i++) {
                    if (i == 0) { retval += temp[0]; }
                    else if (i != temp.Count - 1) { retval += "." + temp[i]; } }
                introMusic.Text = retval;
                if (!File.Exists($@"Audio\ME\{ofd.FileName.Split('\\').Last()}"))
                { File.Copy(ofd.FileName, $@"Audio\ME\{retval}.{temp.Last()}"); }
                if (introMusic.Text.Length > 0) { defaultIntroMusic.Checked = false; introMusic.Enabled = true; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!canPlay) { return; }
            player.controls.stop();
            player.settings.volume = (int)volumeBox.Value;
            if (!Directory.Exists(@"Audio") || !Directory.Exists(@"Audio\BGM")) { MessageBox.Show("One or more audio folders are missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else {
                if (File.Exists($@"Audio\BGM\{bgMusic.Text}.mid"))
                { player.URL = $@"Audio\BGM\{bgMusic.Text}.mid";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\BGM\{bgMusic.Text}.wav"))
                { player.URL = $@"Audio\BGM\{bgMusic.Text}.wav";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\BGM\{bgMusic.Text}.mp3"))
                { player.URL = $@"Audio\BGM\{bgMusic.Text}.mp3";
                    player.controls.play(); }
                else { MessageBox.Show("No audio file found! Supported extensions: *.mid, *.wav, *.mp3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!canPlay) { return; }
            player.controls.stop();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!canPlay) { return; }
            player.controls.stop();
            player.settings.volume = (int)volumeBox.Value;
            if (!Directory.Exists("Audio") || !Directory.Exists(@"Audio\BGM")) { MessageBox.Show("One or more audio folders are missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else {
                if (File.Exists($@"Audio\BGM\{victoryMusic.Text}.mid"))
                { player.URL = $@"Audio\BGM\{victoryMusic.Text}.mid";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\BGM\{victoryMusic.Text}.wav"))
                { player.URL = $@"Audio\BGM\{victoryMusic.Text}.wav";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\BGM\{victoryMusic.Text}.mp3"))
                { player.URL = $@"Audio\BGM\{victoryMusic.Text}.mp3";
                    player.controls.play(); }
                else { MessageBox.Show("No audio file found! Supported extensions: *.mid, *.wav, *.mp3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!canPlay) { return; }
            player.controls.stop();
            player.settings.volume = (int)volumeBox.Value;
            if (!Directory.Exists($@"Audio") || !Directory.Exists(@"Audio\ME")) { MessageBox.Show("One or more audio folders are missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            else {
                if (File.Exists($@"Audio\ME\{introMusic.Text}.mid"))
                { player.URL = $@"Audio\ME\{introMusic.Text}.mid";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\ME\{introMusic.Text}.wav"))
                { player.URL = $@"Audio\ME\{introMusic.Text}.wav";
                    player.controls.play(); }
                else if (File.Exists($@"Audio\ME\{introMusic.Text}.mp3"))
                { player.URL = $@"Audio\ME\{introMusic.Text}.mp3";
                    player.controls.play(); }
                else { MessageBox.Show("No audio file found! Supported extensions: *.mid, *.wav, *.mp3.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
        }
        private void volumeBox_ValueChanged(object sender, EventArgs e)
        {
            if (!canPlay) { return; }
            player.settings.volume = (int)volumeBox.Value;
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.id.CompareTo(c2.id); });
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "ID";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void displayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.name.CompareTo(c2.name); });
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "DisplayName";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void internalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.intname.CompareTo(c2.intname); });
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "InternalName";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void byMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMoney().CompareTo(c2.getSortableMoney()); });
            classes.Reverse();
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "Money";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void byBGMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(1).CompareTo(c2.getSortableMusic(1)); });
            classes.Reverse();
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "BGMusic";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void byVictoryMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(2).CompareTo(c2.getSortableMusic(2)); });
            classes.Reverse();
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "VictoryMusic";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void byIntroMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableMusic(3).CompareTo(c2.getSortableMusic(3)); });
            classes.Reverse();
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "IntroMusic";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void byGenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableGender().CompareTo(c2.getSortableGender()); });
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "Gender";
            classBox.SelectedIndex = classes.IndexOf(c);
        }
        private void bySkillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            classes.Sort(delegate (Class c1, Class c2) { return c1.getSortableSkill().CompareTo(c2.getSortableSkill()); });
            classes.Reverse();
            classBinder.ResetBindings(false);
            Properties.Settings.Default.ClassSortMethod = "Skill";
            classBox.SelectedIndex = classes.IndexOf(c);
        }

        private void addClassBtn_Click(object sender, EventArgs e)
        {
            classes.Add(new Class(classes.Count + 1, null, null, null, null, null, null, null, null));
            classBinder.ResetBindings(false);
            classBox.SelectedIndex = classes.Count - 1;
            classBox_SelectedIndexChanged(sender, e);
            removeClassBtn.Enabled = true;
        }

        private void removeClassBtn_Click(object sender, EventArgs e)
        {
            classes.RemoveAt(classBox.SelectedIndex);
            classBinder.ResetBindings(false);
            if (classes.Count == 0) { removeClassBtn.Enabled = false; }
            else { removeClassBtn.Enabled = true; classBox_SelectedIndexChanged(sender, e); }
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            GennedTypes gt = new GennedTypes();
            gt.txt = $"{c.id},{c.intname},{c.name},{c.money},{c.bgmusic},{c.victorymusic},{c.intromusic},{c.gender},{c.skill},";
            gt.Show();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class c = classes[classBox.SelectedIndex];
            string ret = $"{c.id},{c.intname},{c.name},{c.money},{c.bgmusic},{c.victorymusic},{c.intromusic},{c.gender},{c.skill},";
            SuperForm.exportFile($"trainertype{c.id}.txt", ret);
        }
        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            classes.Sort(delegate (Class c1, Class c2) { return c1.id.CompareTo(c2.id); });
            classBinder.ResetBindings(false);
            string ret = null;
            for (int a = 0; a < classes.Count; a++) {
                Class c = classes[a];
                ret += $"{c.id},{c.intname},{c.name},{c.money},{c.bgmusic},{c.victorymusic},{c.intromusic},{c.gender},{c.skill},"; if (a != classes.Count - 1) { ret += "\r\n"; } }
            GennedTypes gt = new GennedTypes();
            gt.txt = ret;
            gt.Show();
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            classes.Sort(delegate (Class c1, Class c2) { return c1.id.CompareTo(c2.id); });
            classBinder.ResetBindings(false);
            string ret = null;
            for (int a = 0; a < classes.Count; a++) {
                Class c = classes[a];
                ret += $"{c.id},{c.intname},{c.name},{c.money},{c.bgmusic},{c.victorymusic},{c.intromusic},{c.gender},{c.skill},"; if (a != classes.Count - 1) { ret += "\r\n"; } }
            SuperForm.exportFile("trainertypes.txt", ret);
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to overwrite \"trainertypes.txt\"?\r\nA backup of the current file will be saved in a new folder.", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classes.Sort(delegate (Class c1, Class c2) { return c1.id.CompareTo(c2.id); });
                classBinder.ResetBindings(false);
                string ret = null;
                for (int a = 0; a < classes.Count; a++) {
                    Class c = classes[a];
                    ret += $"{c.id},{c.intname},{c.name},{c.money},{c.bgmusic},{c.victorymusic},{c.intromusic},{c.gender},{c.skill},"; if (a != classes.Count - 1) { ret += "\r\n"; } }
                SuperForm.pbsFile("trainertypes.txt", ret);
            }
        }

        private void openTrainertypestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start($@"PBS\trainertypes.txt");
        }

        private void findInternalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].intname == IntNameFinder.result.ToUpper())
                {
                    classBox.SelectedIndex = classes.IndexOf(classes[i]);
                    found = true;
                    break;
                }
            }
            if (!found) { MessageBox.Show("The internal name could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reload all data?\r\nThis will overwrite any unsaved changes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                classes.Clear();
                TrainerClassForm_Load(sender, e);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label1, "The internal ID of the trainer class.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label2, "The display name of the trainer class.");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label3, "The internal name of the trainer class.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            baseMoneyTip.SetToolTip(label4, "The base money used in the sum for the amount of\r\nMoney earned for beating a trainer of this trainer class.");
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            bgMusicTip.SetToolTip(label5, "The background music played when battling a trainer of this trainer class.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            victoryMusicTip.SetToolTip(label6, "The victory music played when a trainer of this trainer class is beaten.");
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            introMusicTip.SetToolTip(label7, "The intro music played when the Player is\r\nAbout to battle a t rainer of this trainer class.");
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            genderTip.SetToolTip(label8, "The set gender of this trainer class.");
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            skillLevelTip.SetToolTip(label9, "How smart the AI of a trainer of this class is.");
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            volumeTip.SetToolTip(label10, "How loud the music is when previewed in the program.\r\nThis does not affect the file itself!");
        }
    }
}
