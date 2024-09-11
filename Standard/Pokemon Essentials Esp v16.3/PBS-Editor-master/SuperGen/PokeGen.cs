using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using SuperGen;
using static SuperGen.SuperForm;
using lib;
using System.Diagnostics;
using System.Threading;

namespace PokeGenerator
{
    public partial class PokeGenerator : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        private string thisid = null;
        private bool terminate = false;
        private bool msg = true;
        private bool show_shape = false;
        private int shapeIndex = 0;
        private int shapeImageIndex = 0;
        private bool starting = true;
        #region private BindingSources
        private BindingSource pokeBinder = new BindingSource();
        private BindingSource moveBinder1 = new BindingSource();
        private BindingSource moveBinder2 = new BindingSource();
        private BindingSource abilBinder1 = new BindingSource();
        private BindingSource abilBinder2 = new BindingSource();
        private BindingSource abilBinder3 = new BindingSource();
        private BindingSource itemBinder1 = new BindingSource();
        private BindingSource itemBinder2 = new BindingSource();
        private BindingSource itemBinder3 = new BindingSource();
        private BindingSource typeBinder1 = new BindingSource();
        private BindingSource typeBinder2 = new BindingSource();
        private BindingSource movelistBinder = new BindingSource();
        private BindingSource eggmoveBinder = new BindingSource();
        private BindingSource evolutionBinder = new BindingSource();
        #endregion
        #region private Lists
        public static List<Poke> pokes = new List<Poke>();
        private List<string> moves = new List<string>();
        private List<string> abilities = new List<string>();
        private List<string> items = new List<string>();
        private List<string> types = new List<string>();
        private List<string> eggmoves = new List<string>();
        private List<string> evopoke = new List<string>();
        private List<string> evomethod = new List<string>();
        private List<string> evoparam = new List<string>();
        #endregion

        public PokeGenerator()
        {
            InitializeComponent();
        }

        private void PokeGen_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            #region Sets up all Box Bindings
            pokeBinder.DataSource = pokes;
            pokeBox.DataSource = pokeBinder;
            pokeBox.DisplayMember = "name";

            itemBinder1.DataSource = items;
            itemBinder2.DataSource = items;
            itemBinder3.DataSource = items;
            cmnItemBox.DataSource = itemBinder1;
            cmnItemBox.DisplayMember = "name";
            uncmnItemBox.DataSource = itemBinder2;
            uncmnItemBox.DisplayMember = "name";
            rareItemBox.DataSource = itemBinder3;
            rareItemBox.DisplayMember = "name";

            abilBinder1.DataSource = abilities;
            abilBinder2.DataSource = abilities;
            abilBinder3.DataSource = abilities;
            abilityBox1.DataSource = abilBinder1;
            abilityBox1.DisplayMember = "name";
            abilityBox2.DataSource = abilBinder2;
            abilityBox2.DisplayMember = "name";
            hiddenAbilityBox.DataSource = abilBinder3;
            hiddenAbilityBox.DisplayMember = "name";

            moveBinder1.DataSource = moves;
            moveBinder2.DataSource = moves;
            moveNameBox.DataSource = moveBinder1;
            moveNameBox.DisplayMember = "name";
            eggmoveNameBox.DataSource = moveBinder2;
            eggmoveNameBox.DisplayMember = "name";

            typeBinder1.DataSource = types;
            typeBox1.DisplayMember = "name";
            typeBox1.DataSource = typeBinder1;
            typeBinder2.DataSource = types;
            typeBox2.DataSource = typeBinder2;
            typeBox2.DisplayMember = "name";
            #endregion
            #region Load items.txt
            try
            {
                StreamReader read1 = new StreamReader(@"PBS\items.txt");
                string dat = read1.ReadToEnd();
                read1.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "items");
                    terminate = true;
                    Close();
                    return;
                }
                string stuff1 = dat;
                if (!string.IsNullOrEmpty(stuff1))
                {
                    List<string> allItemData = new List<string>();
                    allItemData = stuff1.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allItemData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allItemData[i]))
                            {
                                items.Add(allItemData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("items", allItemData[i], "Pokémon Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                    items.Sort();
                    itemBinder1.ResetBindings(false);
                    itemBinder2.ResetBindings(false);
                    itemBinder3.ResetBindings(false);
                }
                else
                {
                    
                    MessageBox.Show("Something went wrong while converting data from \"items.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            catch (Exception)
            {
                fileNotFound("items", "Pokémon Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Load abilities.txt
            try
            {
                StreamReader read2 = new StreamReader(@"PBS\abilities.txt");
                string dat = read2.ReadToEnd();
                read2.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "abilities");
                    terminate = true;
                    Close();
                    return;
                }
                string stuff2 = dat;
                if (!string.IsNullOrEmpty(stuff2))
                {
                    List<string> allAbilData = new List<string>();
                    allAbilData = stuff2.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allAbilData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allAbilData[i]))
                            {
                                abilities.Add(allAbilData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("abilities", allAbilData[i], "Pokémon Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                    abilities.Sort(); abilBinder1.ResetBindings(false); abilBinder2.ResetBindings(false); abilBinder3.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("Something went wrong while converting data from \"abilities.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            catch (Exception)
            {
                fileNotFound("abilities", "Pokémon Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Load moves.txt
            try
            {
                StreamReader read3 = new StreamReader(@"PBS\moves.txt");
                string dat = read3.ReadToEnd();
                read3.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "moves");
                    terminate = true;
                    Close();
                    return;
                }
                string stuff3 = dat;
                if (!string.IsNullOrEmpty(stuff3))
                {
                    List<string> allMoveData = new List<string>();
                    allMoveData = stuff3.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allMoveData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allMoveData[i]))
                            {
                                moves.Add(allMoveData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("moves", allMoveData[i], "Pokémon Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                    moves.Sort(); moveBinder1.ResetBindings(false); moveBinder2.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("Something went wrong while converting data from \"moves.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            catch (Exception)
            {
                fileNotFound("moves", "Pokémon Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Load types.txt
            try
            {
                StreamReader read4 = new StreamReader(@"PBS\types.txt");
                string dat = read4.ReadToEnd();
                read4.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "types");
                    terminate = true;
                    Close();
                    return;
                }
                string stuff4 = dat;
                if (!string.IsNullOrEmpty(stuff4))
                {
                    List<string> allTypeData = new List<string>();
                    allTypeData = stuff4.Split('[').ToList();
                    allTypeData.RemoveAt(0);
                    for (int i = 0; i < allTypeData.Count; i++)
                    {
                        try
                        {
                            if (allTypeData[i].Length > 0)
                            {
                                types.Add(allTypeData[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                types.Sort(); typeBinder1.ResetBindings(false); typeBinder2.ResetBindings(false);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("types", allTypeData[i], "Pokémon Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong while loading \"types.txt\".\r\nMake sure the app is installed correctly\r\nAnd the data inside the file is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            catch (Exception)
            {
                fileNotFound("types", "Pokémon Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Load pokemon.txt
            try
            {
                StreamReader read5 = new StreamReader(@"PBS\pokemon.txt");
                string dat = read5.ReadToEnd();
                read5.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "pokemon");
                    terminate = true;
                    Close();
                    return;
                }
                string stuff5 = dat;
                if (!string.IsNullOrEmpty(stuff5))
                {
                    List<string> allPokeData = new List<string>();
                    allPokeData = stuff5.Split('[').ToList();
                    for (int i = 1; i < allPokeData.Count; i++)
                    {
                        try
                        {
                            int id = 1;
                            try
                            {
                                id = Convert.ToInt32(allPokeData[i].Split(']')[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read ID for iteration {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }
                            string name = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "Name=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { name += "é"; } else { name += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Name for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string intname = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { intname += "é"; } else { intname += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process InternalName for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string type1 = null;
                            try
                            {
                                type1 = allPokeData[i].Split(new string[] { "Type1=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Type1 for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }
                            string type2 = null;
                            string ability1 = null;
                            string ability2 = null;
                            string hiddenabil = null;
                            string egg1 = null;
                            string egg2 = null;
                            int evhp = 0;
                            int evatk = 0;
                            int evdef = 0;
                            int evspatk = 0;
                            int evspdef = 0;
                            int evspeed = 0;
                            string habitat = null;
                            int battlerpy = 0;
                            int battlerey = 0;
                            int battleralt = 0;
                            string itemcmn = null;
                            string itemuncmn = null;
                            string itemrare = null;
                            string incense = null;
                            string dexnums = null;
                            string formnames = null;
                            List<string> t = new List<string>();
                            List<string> eggmoves = new List<string>();

                            try
                            {
                                if (allPokeData[i].Contains("Type2=")) { type2 = allPokeData[i].Split(new string[] { "Type2=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Type2 for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }
                            int hp = 0;
                            int atk = 0;
                            int def = 0;
                            int spatk = 0;
                            int spdef = 0;
                            int speed = 0;
                            try
                            {
                                hp = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[0]);
                                atk = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[1]);
                                def = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[2]);
                                spatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[4]);
                                spdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[5].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                speed = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[3]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BaseStats for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string genderratio = null;
                            try
                            {
                                genderratio = allPokeData[i].Split(new string[] { "GenderRate=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read GenderRate for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }
                            string growthrate = null;
                            try
                            {
                                growthrate = allPokeData[i].Split(new string[] { "GrowthRate=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read GrowthRate for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            int exp = 0;
                            try
                            {
                                exp = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseEXP=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BaseEXP for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("EffortPoints=")) { evhp = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[0]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[1]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[2]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[4]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[5].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspeed = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[3]); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse EffortPoints for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            int catchrate = 0;
                            try
                            {
                                catchrate = Convert.ToInt32(allPokeData[i].Split(new string[] { "Rareness=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Rareness for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            int happiness = Convert.ToInt32(allPokeData[i].Split(new string[] { "Happiness=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            try
                            {
                                try
                                {
                                    ability2 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[1];
                                    ability1 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[0];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        ability1 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        ability1 = null; ability2 = null;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Abilities for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("HiddenAbility=")) { hiddenabil = allPokeData[i].Split(new string[] { "HiddenAbility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read HiddenAbility for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                try
                                {
                                    egg2 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[1];
                                    egg1 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[0];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    egg1 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Compatibility for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            int hatchtime = 0;
                            try
                            {
                                hatchtime = Convert.ToInt32(allPokeData[i].Split(new string[] { "StepsToHatch=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse StepsToHatch for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            decimal height = 0;
                            try
                            {
                                height = Convert.ToDecimal(allPokeData[i].Split(new string[] { "Height=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Height for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            decimal weight = 0;
                            try
                            {
                                weight = Convert.ToDecimal(allPokeData[i].Split(new string[] { "Weight=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Weight for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string color = null;
                            try
                            {
                                color = allPokeData[i].Split(new string[] { "Color=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Color for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Habitat=")) { habitat = allPokeData[i].Split(new string[] { "Habitat=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Habitat for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string kind = null;
                            try
                            {
                                kind = allPokeData[i].Split(new string[] { "Kind=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Kind for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            string dexentry = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "Pokedex=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { dexentry += "é"; } else { dexentry += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Pokedex for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Evolutions=")) { t = allPokeData[i].Split(new string[] { "Evolutions=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Evolutions for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("EggMoves=")) { eggmoves = allPokeData[i].Split(new string[] { "EggMoves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                                else if (allPokeData[i].Contains("Eggmoves=")) { eggmoves = allPokeData[i].Split(new string[] { "Eggmoves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read EggMoves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }


                            try
                            {
                                if (allPokeData[i].Contains("BattlerPlayerY=")) { battlerpy = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerPlayerY=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battlerpy = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerPlayerY for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("BattlerEnemyY=")) { battlerey = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerEnemyY=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battlerey = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerEnemyY for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("BattlerAltitude=")) { battleralt = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerAltitude=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battleralt = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerAltitude for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("FormNames=")) { formnames = allPokeData[i].Split(new string[] { "FormNames=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read FormNames for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("RegionalNumbers=")) { dexnums = allPokeData[i].Split(new string[] { "RegionalNumbers=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read RegionalNumbers for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemCommon=")) { itemcmn = allPokeData[i].Split(new string[] { "WildItemCommon=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemCommon for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemUncommon=")) { itemuncmn = allPokeData[i].Split(new string[] { "WildItemUncommon=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemUncommon for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemRare=")) { itemrare = allPokeData[i].Split(new string[] { "WildItemRare=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemRare for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Incense=")) { incense = allPokeData[i].Split(new string[] { "Incense=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Incense for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            List<string> movesetstring = new List<string>();
                            try
                            {
                                movesetstring = allPokeData[i].Split(new string[] { "Moves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Moves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            int shape = 1;
                            try
                            {
                                if (allPokeData[i].Contains("Shape="))
                                {
                                    shape = Convert.ToInt32(allPokeData[i].Split(new string[] { "Shape=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                    show_shape = true;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Shape for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            List<string> tmovesetmoves = new List<string>();
                            List<int> tmovesetlevels = new List<int>();
                            List<Moveset> movelist = new List<Moveset>();

                            try
                            {
                                for (int j = 0; j < movesetstring.Count; j++)
                                {
                                    if (j % 2 == 0)
                                    {
                                        tmovesetlevels.Add(Convert.ToInt32(movesetstring[j]));
                                    }
                                    else
                                    {
                                        tmovesetmoves.Add(movesetstring[j]);
                                    }
                                }

                                for (int j = 0; j < tmovesetmoves.Count; j++)
                                {
                                    movelist.Add(new Moveset(tmovesetmoves[j], tmovesetlevels[j]));
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to process Moves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            List<Evo> evo = new List<Evo>();
                            try
                            {
                                for (int j = 0; j < t.Count - 2; j += 3) { evo.Add(new Evo(t[j], t[j + 1], t[j + 2])); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to process Evolutions for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }

                            try
                            {
                                pokes.Add(new Poke(id, name, intname, type1, type2, hp, atk, def, spatk, spdef, speed, genderratio, growthrate, exp, evhp, evatk, evdef, evspatk, evspdef, evspeed,
                                                    catchrate, happiness, ability1, ability2, hiddenabil, movelist, eggmoves, egg1, egg2,
                                                    hatchtime, height, weight, color, habitat, kind, dexentry, evo, itemcmn, itemuncmn, itemrare,
                                                    battlerpy, battlerey, battleralt, dexnums, incense, formnames, shape));
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to create a Pokémon object for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                terminate = true;
                                Close();
                                return;
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("pokemon", allPokeData[i], "Pokémon Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                    pokes.Sort(delegate (Poke p1, Poke p2) { return p1.name.CompareTo(p2.name); });
                    try
                    {
                        switch (SuperGen.Properties.Settings.Default.SortMethod)
                        {
                            case "ID": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); }); break;
                            case "Type": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.type1.CompareTo(p2.type1); }); break;
                            case "Height": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.height.CompareTo(p2.height); }); pokes.Reverse(); break;
                            case "Weight": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.weight.CompareTo(p2.weight); }); pokes.Reverse(); break;
                            case "StatTotal": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.statTotal.CompareTo(p2.statTotal); }); pokes.Reverse(); break;
                            case "StatHP": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[0].CompareTo(p2.stats[0]); }); pokes.Reverse(); break;
                            case "StatAtk": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[1].CompareTo(p2.stats[1]); }); pokes.Reverse(); break;
                            case "StatDef": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[2].CompareTo(p2.stats[2]); }); pokes.Reverse(); break;
                            case "StatSpAtk": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[3].CompareTo(p2.stats[3]); }); pokes.Reverse(); break;
                            case "StatSpDef": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[4].CompareTo(p2.stats[4]); }); pokes.Reverse(); break;
                            case "StatSpeed": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[5].CompareTo(p2.stats[5]); }); pokes.Reverse(); break;
                            case "Catch Rate": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.catchrate.CompareTo(p2.catchrate); }); break;
                            case "Hatch Time": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.hatchsteps.CompareTo(p2.hatchsteps); }); pokes.Reverse(); break;
                            case "Base EXP": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.exp.CompareTo(p2.exp); }); pokes.Reverse(); break;
                            case "Desc": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.dexentry.CompareTo(p2.dexentry); }); break;
                            case "Moveset": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.moveset.Count.CompareTo(p2.moveset.Count); }); pokes.Reverse(); break;
                            case "Eggmoves": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.eggmoves.Count.CompareTo(p2.eggmoves.Count); }); pokes.Reverse(); break;
                            case "Evolutions": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.evolutions.Count.CompareTo(p2.evolutions.Count); }); pokes.Reverse(); break;
                            case "Shape": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.shape.CompareTo(p2.shape); }); pokes.Reverse(); break;
                            default: pokes.Sort(delegate (Poke p1, Poke p2) { return p1.name.CompareTo(p2.name); }); break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Failed to sort Pokémon list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        terminate = true;
                        Close();
                        return;
                    }
                    pokeBinder.ResetBindings(false);
                    pokeBox.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Something went wrong while loading \"pokemon.txt\".\r\nMake sure the app is installed correctly\r\nAnd the data inside the file is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            catch (Exception)
            {
                fileNotFound("pokemon", "Pokémon Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            if (pokes[0].id < 10) { thisid = "00"; }
            else if (pokes[0].id < 100) { thisid = "0"; }
            thisid += pokes[0].id;
            string s = SuperGen.Properties.Settings.Default.SelForm;

            if (show_shape)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Name = "byShape";
                tsmi.Text = "By Shape";
                tsmi.Click += new EventHandler(byShapeToolStripMenuItem_Click);
                sortToolStripMenuItem.DropDownItems.Add(tsmi);

                pokeBox.Height = 472;
                addPokeBtn.Location = new Point(addPokeBtn.Location.X, addPokeBtn.Location.Y + 50);
                button2.Location = new Point(button2.Location.X, button2.Location.Y + 50);

                MaximumSize = new Size(MaximumSize.Width, 567);
                Height = 567;
                MinimumSize = new Size(MinimumSize.Width, 567);

                fieldSplitter.Height = 497;

                Label label61 = new Label();
                label61.Location = new Point(6, 439);
                label61.Size = new Size(41, 13);
                label61.Text = "Shape:";
                fieldSplitter.TabPages[0].Controls.Add(label61);

                NumericUpDown shapeBox = new NumericUpDown();
                shapeBox.Location = new Point(67, 436);
                shapeBox.Size = new Size(38, 20);
                shapeBox.Name = "shapeBox";
                shapeBox.ValueChanged += new EventHandler(shapeBox_ValueChanged);
                fieldSplitter.TabPages[0].Controls.Add(shapeBox);
                
                PictureBox shapeImage = new PictureBox();
                shapeImage.Location = new Point(111, 431);
                shapeImage.Size = new Size(30, 30);
                shapeImage.Name = "shapeImage";
                shapeImage.SizeMode = PictureBoxSizeMode.StretchImage;
                shapeImage.Image = SuperGen.Properties.Resources.shape1;
                fieldSplitter.TabPages[0].Controls.Add(shapeImage);

                for (int i = 0; i < fieldSplitter.TabPages[0].Controls.Count; i++)
                {
                    if (fieldSplitter.TabPages[0].Controls[i].Name == "shapeBox")
                    {
                        shapeIndex = i;
                    }
                    if (fieldSplitter.TabPages[0].Controls[i].Name == "shapeImage")
                    {
                        shapeImageIndex = i;
                    }
                }
                ((NumericUpDown)fieldSplitter.TabPages[0].Controls[shapeIndex]).Minimum = 1;
                ((NumericUpDown)fieldSplitter.TabPages[0].Controls[shapeIndex]).Maximum = 14;
            }
            starting = false;

            pokeBox.SelectedIndex = 0;
            for (int i = 0; i < pokes.Count; i++)
            {
                if (pokes[i].intname == SuperGen.Properties.Settings.Default.IntName) { pokeBox.SelectedIndex = pokes.IndexOf(pokes[i]); }
            }

            if (SuperGen.Properties.Settings.Default.Show == "Front") { loadImageFront(s != "0" ? s : null); showFront.Checked = true; frontToolStripMenuItem.Checked = true; }
            else if (SuperGen.Properties.Settings.Default.Show == "Back") { loadImageBack(s != "0" ? s : null); showBack.Checked = true; backToolStripMenuItem.Checked = true; }
            else if (SuperGen.Properties.Settings.Default.Show == "FrontShiny") { loadImageFrontShiny(s != "0" ? s : null); showShinyFront.Checked = true; shinyFrontToolStripMenuItem.Checked = true; }
            else if (SuperGen.Properties.Settings.Default.Show == "BackShiny") { loadImageBackShiny(s != "0" ? s : null); showShinyBack.Checked = true; shinyBackToolStripMenuItem.Checked = true; }
            else { SuperGen.Properties.Settings.Default.Show = "Front"; loadImageFront(s != "0" ? s : null); showFront.Checked = true; frontToolStripMenuItem.Checked = true; }
            try { formSpriteBox.Value = Convert.ToInt32(s.Split('_')[1]); } catch (IndexOutOfRangeException) { formSpriteBox.Value = 0; }
            double time = Convert.ToDouble((double) stopwatch.ElapsedMilliseconds / (double) 1000);
            Text = "Pokémon Editor - " + time.ToString() + "s elapsed";
            stopwatch.Reset();
            stopwatch.Start();
            Thread thread = new Thread(loop);
            thread.Start();
        }

        private void loop()
        {
            while (true)
            {
                if (stopwatch.ElapsedMilliseconds > 1500)
                {
                    MethodInvoker mi = delegate () { Text = "Pokémon Editor"; };
                    Invoke(mi);
                    stopwatch.Stop(); break;
                }
            }
        }

        private void PokeGen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SuperGen.Properties.Settings.Default.SizeX = Width;
                    SuperGen.Properties.Settings.Default.SizeY = Height;
                    if (frontToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "Front"; }
                    else if (backToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "Back"; }
                    else if (shinyFrontToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "FrontShiny"; }
                    else if (shinyBackToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "BackShiny"; }
                    else { SuperGen.Properties.Settings.Default.Show = "Front"; }
                    SuperGen.Properties.Settings.Default.IntName = pokes[pokeBox.SelectedIndex].intname;
                    SuperGen.Properties.Settings.Default.FormSprite = Convert.ToInt32(formSpriteBox.Value);
                    if (formSpriteBox.Value > 0) { SuperGen.Properties.Settings.Default.SelForm = "_" + formSpriteBox.Value.ToString(); }
                    else { SuperGen.Properties.Settings.Default.SelForm = "0"; }
                    SuperGen.Properties.Settings.Default.Save();
                    disposeData();
                    Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void addPokeBtn_Click(object sender, EventArgs e)
        {
            pokes.Add(new Poke(pokes.Count + 1, null, null, null, null, 45, 45, 45, 45, 45, 45, "Female50Percent", "Parabolic",
                               45, 0, 0, 0, 0, 0, 3, 45, 70, null, null, null, new List<Moveset> { new Moveset(moves[0], 1) }, new List<string> { },
                               null, null, 9120, 1.0m, 1.0m, null, null, null, null, new List<Evo> { }, null,
                               null, null, 0, 0, 0, null, null, null));
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.Count - 1;
            button2.Enabled = true;
            if (pokes.Count == 1) { ActiveControl = pokeBox; pokeBox.SelectedIndex = 0; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pokes.RemoveAt(pokeBox.SelectedIndex);
            pokeBinder.ResetBindings(false);
            pokeBox_SelectedIndexChanged(sender, e);
        }
        private void pokeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokes.Count > 0)
            {
                fieldSplitter.Enabled = true;
                label39.Enabled = false;
                label40.Enabled = false;
                label41.Enabled = false;
                evoSpeciesBox.Enabled = false;
                evoMethodBox.Enabled = false;
                evoParamBox.Enabled = false;
                idBox.Value = pokes[pokeBox.SelectedIndex].id;
                nameBox.Text = pokes[pokeBox.SelectedIndex].name;
                intNameBox.Text = pokes[pokeBox.SelectedIndex].intname;
                typeBox1.Text = pokes[pokeBox.SelectedIndex].type1;
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].type2)) { typeBox2.Text = pokes[pokeBox.SelectedIndex].type2; noScndType.Checked = false; typeBox2.Enabled = true; }
                else { noScndType.Checked = true; typeBox2.Enabled = false; }
                hpStat.Value = pokes[pokeBox.SelectedIndex].stats[0];
                atkStat.Value = pokes[pokeBox.SelectedIndex].stats[1];
                defStat.Value = pokes[pokeBox.SelectedIndex].stats[2];
                spatkStat.Value = pokes[pokeBox.SelectedIndex].stats[3];
                spdefStat.Value = pokes[pokeBox.SelectedIndex].stats[4];
                speedStat.Value = pokes[pokeBox.SelectedIndex].stats[5];
                totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
                genderBox.SelectedIndex = genderBox.Items.IndexOf(pokes[pokeBox.SelectedIndex].genderratio);
                if (pokes[pokeBox.SelectedIndex].growthrate == "Medium" ||
                    pokes[pokeBox.SelectedIndex].growthrate == "MediumFast") { growthBox.Text = "MediumFast"; }
                else if (pokes[pokeBox.SelectedIndex].growthrate == "Parabolic" ||
                    pokes[pokeBox.SelectedIndex].growthrate == "MediumSlow") { growthBox.Text = "MediumSlow"; }
                else if (pokes[pokeBox.SelectedIndex].growthrate == "Erratic") { growthBox.Text = "Erratic"; }
                else if (pokes[pokeBox.SelectedIndex].growthrate == "Fluctuating") { growthBox.Text = "Fluctuating"; }
                else if (pokes[pokeBox.SelectedIndex].growthrate == "Fast") { growthBox.Text = "Fast"; }
                else { growthBox.Text = "Fluctuating"; }
                expBox.Value = pokes[pokeBox.SelectedIndex].exp;
                catchrateBox.Value = pokes[pokeBox.SelectedIndex].catchrate;
                happinessBox.Value = pokes[pokeBox.SelectedIndex]._happiness;
                eggBox1.Text = pokes[pokeBox.SelectedIndex].egg1;
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].egg2)) { eggBox2.Text = pokes[pokeBox.SelectedIndex].egg2; noScndEggGroup.Checked = false; eggBox2.Enabled = true; }
                else { eggBox2.Enabled = false; noScndEggGroup.Checked = true; }
                hatchTimeBox.Value = pokes[pokeBox.SelectedIndex].hatchsteps;
                heightBox.Value = pokes[pokeBox.SelectedIndex].height;
                weightBox.Value = pokes[pokeBox.SelectedIndex].weight;
                colorBox.Text = pokes[pokeBox.SelectedIndex].color;
                kindBox.Text = pokes[pokeBox.SelectedIndex].kind;
                dexEntryBox.Text = pokes[pokeBox.SelectedIndex].dexentry;
                hpEv.Value = pokes[pokeBox.SelectedIndex].evyield[0];
                atkEv.Value = pokes[pokeBox.SelectedIndex].evyield[1];
                defEv.Value = pokes[pokeBox.SelectedIndex].evyield[2];
                spatkEv.Value = pokes[pokeBox.SelectedIndex].evyield[3];
                spdefEv.Value = pokes[pokeBox.SelectedIndex].evyield[4];
                speedEv.Value = pokes[pokeBox.SelectedIndex].evyield[5];
                totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();

                movelistBinder.DataSource = pokes[pokeBox.SelectedIndex].moveset;
                moveBox.DataSource = movelistBinder;
                moveBox.DisplayMember = "display";
                movelistBinder.ResetBindings(false);
                moveBox.SelectedIndex = 0;
                moveNameBox.Text = pokes[pokeBox.SelectedIndex].moveset[0].name;
                moveLevelBox.Value = pokes[pokeBox.SelectedIndex].moveset[0].level;
                #region abilities
                if (string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1) &&
                    string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2))
                {
                    abilityBox1.Enabled = false; abilityBox2.Enabled = false; noScndAbility.Checked = false; noScndAbility.Enabled = false; noAbilities.Checked = true;
                }
                else if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1) &&
                         string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2))
                {
                    abilityBox1.Text = pokes[pokeBox.SelectedIndex].ability1;
                    abilityBox1.Enabled = true; noAbilities.Checked = false; noScndAbility.Checked = true; noScndAbility.Enabled = true; abilityBox2.Enabled = false;
                }
                else if (string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1) &&
                         !string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2))
                {
                    abilityBox1.Text = pokes[pokeBox.SelectedIndex].ability2;
                    abilityBox1.Enabled = true; noAbilities.Checked = false; noScndAbility.Checked = true; noScndAbility.Enabled = true; abilityBox2.Enabled = false;
                }
                else
                {
                    abilityBox1.Text = pokes[pokeBox.SelectedIndex].ability1;
                    abilityBox2.Text = pokes[pokeBox.SelectedIndex].ability2;
                    abilityBox1.Enabled = true; abilityBox2.Enabled = true; noAbilities.Checked = false; noScndAbility.Checked = false; noScndAbility.Enabled = true;
                }
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability3))
                {
                    hiddenAbilityBox.Text = pokes[pokeBox.SelectedIndex].ability3;
                    noHiddenAbility.Checked = false; hiddenAbilityBox.Enabled = true;
                }
                else
                {
                    hiddenAbilityBox.Enabled = false; noHiddenAbility.Checked = true;
                }
                #endregion
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].habitat))
                {
                    habitatBox.Text = pokes[pokeBox.SelectedIndex].habitat;
                    habitatBox.Enabled = true; noHabitat.Checked = false;
                }
                else { habitatBox.Enabled = false; noHabitat.Checked = true; }
                #region Wild Items
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemcmn))
                {
                    cmnItemBox.Text = pokes[pokeBox.SelectedIndex].itemcmn;
                    cmnItemBox.Enabled = true; noCmnItem.Checked = false;
                }
                else { cmnItemBox.Enabled = false; noCmnItem.Checked = true; }

                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemuncmn))
                {
                    uncmnItemBox.Text = pokes[pokeBox.SelectedIndex].itemuncmn;
                    uncmnItemBox.Enabled = true; noUncmnItem.Checked = false;
                }
                else { uncmnItemBox.Enabled = false; noUncmnItem.Checked = true; }

                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemrare))
                {
                    rareItemBox.Text = pokes[pokeBox.SelectedIndex].itemrare;
                    rareItemBox.Enabled = true; noRareItem.Checked = false;
                }
                else { rareItemBox.Enabled = false; noRareItem.Checked = true; }
                #endregion
                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].dexnums))
                {
                    regNumBox.Text = pokes[pokeBox.SelectedIndex].dexnums;
                    regNumBox.Enabled = true;
                    defaultDexNums.Checked = false;
                }
                else { regNumBox.Enabled = false; defaultDexNums.Checked = true; }

                if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].incense))
                {
                    incenseBox.Enabled = true;
                    incenseBox.Text = pokes[pokeBox.SelectedIndex].incense;
                    noIncense.Checked = false;
                }
                else { incenseBox.Enabled = false; noIncense.Checked = true; incenseBox.Clear(); }

                foreach (Evo evo in pokes[pokeBox.SelectedIndex].evolutions) { evopoke.Add(evo.name); evomethod.Add(evo.method); evoparam.Add(evo.param); }
                evolutionBinder.ResetBindings(false);

                eggmoveBinder.DataSource = pokes[pokeBox.SelectedIndex].eggmoves;
                eggmoveBox.DataSource = eggmoveBinder;
                eggmoveBox.DisplayMember = "name";
                eggmoveBinder.ResetBindings(false);
                if (pokes[pokeBox.SelectedIndex].eggmoves.Count > 0) { eggmoveBox.SelectedIndex = 0; removeEggmoveBtn.Enabled = true; }
                else { removeEggmoveBtn.Enabled = false; }

                evolutionBinder.DataSource = pokes[pokeBox.SelectedIndex].evolutions;
                evoBox.DataSource = evolutionBinder;
                evoBox.DisplayMember = "name";
                evolutionBinder.ResetBindings(false);

                if (pokes[pokeBox.SelectedIndex].moveset.Count > 1) { removeMoveBtn.Enabled = true; } else { removeMoveBtn.Enabled = false; }
                #region Battler Positions
                defaultPY.Checked = false;
                defaultEY.Checked = false;
                defaultAlt.Checked = false;
                plyBox.Enabled = true;
                enyBox.Enabled = true;
                altBox.Enabled = true;
                plyBox.Value = Convert.ToDecimal(pokes[pokeBox.SelectedIndex].battlerpy);
                enyBox.Value = Convert.ToDecimal(pokes[pokeBox.SelectedIndex].battlerey);
                altBox.Value = Convert.ToDecimal(pokes[pokeBox.SelectedIndex].battleralt);
                if (plyBox.Value == 0) { plyBox.Enabled = false; defaultPY.Checked = true; }
                if (enyBox.Value == 0) { enyBox.Enabled = false; defaultEY.Checked = true; }
                if (altBox.Value == 0) { altBox.Enabled = false; defaultAlt.Checked = true; }
                #endregion
                formnameBox.Text = pokes[pokeBox.SelectedIndex].formnames;
                if (string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].formnames)) { formnameBox.Enabled = false; noFormnames.Checked = true; }
                else { formnameBox.Enabled = true; noFormnames.Checked = false; }
                thisid = null;
                if (pokes[pokeBox.SelectedIndex].id < 10) { thisid = "00"; }
                else if (pokes[pokeBox.SelectedIndex].id < 100) { thisid = "0"; }
                thisid += pokes[pokeBox.SelectedIndex].id;
                formSpriteBox.Value = 0;
                if (show_shape) { ((NumericUpDown)fieldSplitter.TabPages[0].Controls[shapeIndex]).Value = pokes[pokeBox.SelectedIndex].shape; }

                loadImageFootprint();
                loadImagePartyIcon(null);
                if (frontToolStripMenuItem.Checked)
                {
                    showFront.Checked = true;
                    showBack.Checked = false;
                    showShinyFront.Checked = false;
                    showShinyBack.Checked = false;
                    loadImageFront(null);
                }
                else if (backToolStripMenuItem.Checked)
                {
                    showFront.Checked = false;
                    showBack.Checked = true;
                    showShinyFront.Checked = false;
                    showShinyBack.Checked = false;
                    loadImageBack(null);
                }
                else if (shinyFrontToolStripMenuItem.Checked)
                {
                    showFront.Checked = false;
                    showBack.Checked = false;
                    showShinyFront.Checked = true;
                    showShinyBack.Checked = false;
                    loadImageFrontShiny(null);
                }
                else if (shinyBackToolStripMenuItem.Checked)
                {
                    showFront.Checked = false;
                    showBack.Checked = false;
                    showShinyFront.Checked = false;
                    showShinyBack.Checked = true;
                    loadImageBackShiny(null);
                }
                else
                {
                    showFront.Checked = true;
                    showBack.Checked = false;
                    showShinyFront.Checked = false;
                    showShinyBack.Checked = false;
                    loadImageFront(null);
                }
            }
            else
            {
                fieldSplitter.Enabled = false;
            }
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.name.CompareTo(p2.name); });
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Name";
        }
        private void byNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); });
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "ID";
        }
        private void byHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.height.CompareTo(p2.height); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Height";
        }
        private void byWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.weight.CompareTo(p2.weight); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Weight";
        }
        private void byCatchRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.catchrate.CompareTo(p2.catchrate); });
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Catch Rate";
        }
        private void byHatchTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.hatchsteps.CompareTo(p2.hatchsteps); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Hatch Time";
        }
        private void byBaseEXPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.exp.CompareTo(p2.exp); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Base EXP";
        }
        private void byDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.dexentry.CompareTo(p2.dexentry); });
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Desc";
        }
        private void byMovesetLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.moveset.Count.CompareTo(p2.moveset.Count); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Moveset";
        }
        private void byAmountOfEggmovesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.eggmoves.Count.CompareTo(p2.eggmoves.Count); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Eggmoves";
        }
        private void byTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.type1.CompareTo(p2.type1); });
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Type";
        }
        private void byAmountOfEvolutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.evolutions.Count.CompareTo(p2.evolutions.Count); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Evolutions";
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].id = Convert.ToInt32(idBox.Value);
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].name = nameBox.Text;
            pokeBinder.ResetBindings(false);
        }
        private void intNameBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].intname = intNameBox.Text;
        }
        private void typeBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].type1 = typeBox1.Text;
        }
        private void typeBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].type2 = typeBox2.Text;
        }
        private void noScndType_CheckedChanged(object sender, EventArgs e)
        {
            if (noScndType.Checked == true) { typeBox2.Enabled = false; pokes[pokeBox.SelectedIndex].type2 = null; typeBox2.ResetText(); }
            else { typeBox2.Enabled = true; pokes[pokeBox.SelectedIndex].type2 = typeBox2.Text; }
        }

        private void hpStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[0] = Convert.ToInt32(hpStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }
        private void atkStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[1] = Convert.ToInt32(atkStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }
        private void defStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[2] = Convert.ToInt32(defStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }
        private void spatkStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[3] = Convert.ToInt32(spatkStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }
        private void spdefStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[4] = Convert.ToInt32(spdefStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }
        private void speedStat_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].stats[5] = Convert.ToInt32(speedStat.Value);
            totalStats.Text = (hpStat.Value + atkStat.Value + defStat.Value + spatkStat.Value + spdefStat.Value + speedStat.Value).ToString();
        }

        private void genderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].genderratio = genderBox.Text;
        }
        private void growthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].growthrate = growthBox.Text;
        }
        private void expBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].exp = Convert.ToInt32(expBox.Value);
        }
        private void catchrateBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].catchrate = Convert.ToInt32(catchrateBox.Value);
        }
        private void happinessBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex]._happiness = Convert.ToInt32(happinessBox.Value);
        }

        private void eggBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].egg1 = eggBox1.Text;
        }
        private void eggBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].egg2 = eggBox2.Text;
        }
        private void noScndEggGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (noScndEggGroup.Checked)
            {
                pokes[pokeBox.SelectedIndex].egg2 = null;
                eggBox2.Enabled = false;
                eggBox2.ResetText();
            }
            else
            {
                pokes[pokeBox.SelectedIndex].egg2 = eggBox2.Text;
                eggBox2.Enabled = true;
            }
        }

        private void hatchTimeBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].hatchsteps = Convert.ToInt32(hatchTimeBox.Value);
        }
        private void heightBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].height = heightBox.Value;
        }
        private void weightBox_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].weight = weightBox.Value;
        }
        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].color = colorBox.Text;
        }
        private void kindBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].kind = kindBox.Text;
        }
        private void dexEntryBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].dexentry = dexEntryBox.Text;
        }

        private void hpEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[0] = Convert.ToInt32(hpEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void atkEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[1] = Convert.ToInt32(atkEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void defEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[2] = Convert.ToInt32(defEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void spatkEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[3] = Convert.ToInt32(spatkEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void spdefEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[4] = Convert.ToInt32(spdefEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void speedEv_ValueChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evyield[5] = Convert.ToInt32(speedEv.Value);
            totalEVs.Text = (hpEv.Value + atkEv.Value + defEv.Value + spatkEv.Value + spdefEv.Value + speedEv.Value).ToString();
        }
        private void totalStats_TextChanged(object sender, EventArgs e)
        {
            comparePoke1.Text = null;
            comparePoke2.Text = null;
            comparePoke3.Text = null;
            List<string> names = new List<string>();
            for (int i = 0; i < pokes.Count; i++)
            {
                if (pokes[i].statTotal == pokes[pokeBox.SelectedIndex].statTotal && pokes[i].name != pokes[pokeBox.SelectedIndex].name) { names.Add(pokes[i].name); }
            }
            Random r = new Random();
            if (names.Count > 2)
            {
                int rnd1 = r.Next(0, names.Count);
                int rnd2 = r.Next(0, names.Count);
                int rnd3 = r.Next(0, names.Count);
                while (rnd1 == rnd2 || rnd2 == rnd3 || rnd1 == rnd3)
                {
                    rnd1 = r.Next(0, names.Count);
                    rnd2 = r.Next(0, names.Count);
                    rnd3 = r.Next(0, names.Count);
                }
                comparePoke1.Text = names[rnd1];
                comparePoke2.Text = names[rnd2];
                comparePoke3.Text = names[rnd3];
            }
            else if (names.Count == 2)
            {
                int rnd1 = r.Next(0, names.Count);
                int rnd2 = r.Next(0, names.Count);
                while (rnd1 == rnd2)
                {
                    rnd1 = r.Next(0, names.Count);
                    rnd2 = r.Next(0, names.Count);
                }
                comparePoke1.Text = names[rnd1];
                comparePoke2.Text = names[rnd2];
            }
            else if (names.Count == 1) { comparePoke1.Text = names[0]; }
            else { comparePoke1.Text = "No matches"; }
        }

        private void moveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveNameBox.Text = pokes[pokeBox.SelectedIndex].moveset[moveBox.SelectedIndex].name;
            moveLevelBox.Value = pokes[pokeBox.SelectedIndex].moveset[moveBox.SelectedIndex].level;
        }
        private void moveNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void moveLevelBox_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void addMoveBtn_Click(object sender, EventArgs e)
        {
            Moveset newMoveset = new Moveset(moveNameBox.Text, (int)moveLevelBox.Value);
            pokes[pokeBox.SelectedIndex].moveset.Add(newMoveset);
            pokes[pokeBox.SelectedIndex].moveset.Sort(delegate (Moveset m1, Moveset m2) { return m1.level.CompareTo(m2.level); });
            movelistBinder.ResetBindings(false);
            moveBox.SelectedIndex = pokes[pokeBox.SelectedIndex].moveset.IndexOf(newMoveset);
            removeMoveBtn.Enabled = true;
        }
        private void removeMoveBtn_Click(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].moveset.RemoveAt(moveBox.SelectedIndex);
            pokes[pokeBox.SelectedIndex].moveset.Sort(delegate (Moveset m1, Moveset m2) { return m1.level.CompareTo(m2.level); });
            movelistBinder.ResetBindings(false);
            if (pokes[pokeBox.SelectedIndex].moveset.Count <= 1) { removeMoveBtn.Enabled = false; }
        }

        private void abilityBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].ability1 = abilityBox1.Text;
        }
        private void abilityBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].ability2 = abilityBox2.Text;
        }
        private void hiddenAbilityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].ability3 = hiddenAbilityBox.Text;
        }

        private void noAbilities_CheckedChanged(object sender, EventArgs e)
        {
            if (noAbilities.Checked)
            {
                noScndAbility.Enabled = false;
                noScndAbility.Checked = false;
                abilityBox1.Enabled = false;
                abilityBox2.Enabled = false;
                pokes[pokeBox.SelectedIndex].ability1 = null;
                pokes[pokeBox.SelectedIndex].ability2 = null;
                abilityBox1.ResetText();
                abilityBox2.ResetText();
            }
            else
            {
                noScndAbility.Enabled = true;
                abilityBox1.Enabled = true;
                abilityBox2.Enabled = true;
            }
        }
        private void noScndAbility_CheckedChanged(object sender, EventArgs e)
        {
            if (noScndAbility.Checked) { abilityBox2.Enabled = false; abilityBox2.ResetText(); pokes[pokeBox.SelectedIndex].ability2 = null; }
            else { abilityBox2.Enabled = true; }
        }
        private void noHiddenAbility_CheckedChanged(object sender, EventArgs e)
        {
            if (noHiddenAbility.Checked) { hiddenAbilityBox.Enabled = false; hiddenAbilityBox.ResetText(); pokes[pokeBox.SelectedIndex].ability3 = null; }
            else { hiddenAbilityBox.Enabled = true; }
        }
        private void habitatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].habitat = habitatBox.Text;
        }
        private void cmnItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].itemcmn = cmnItemBox.Text;
        }
        private void uncmnItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].itemuncmn = uncmnItemBox.Text;
        }
        private void rareItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].itemrare = rareItemBox.Text;
        }
        private void noHabitat_CheckedChanged(object sender, EventArgs e)
        {
            if (noHabitat.Checked) { habitatBox.Enabled = false; habitatBox.ResetText(); pokes[pokeBox.SelectedIndex].habitat = null; }
            else { habitatBox.Enabled = true; }
        }
        private void noCmnItem_CheckedChanged(object sender, EventArgs e)
        {
            if (noCmnItem.Checked) { cmnItemBox.Enabled = false; cmnItemBox.ResetText(); pokes[pokeBox.SelectedIndex].itemcmn = null; }
            else { cmnItemBox.Enabled = true; }
        }
        private void noUncmnItem_CheckedChanged(object sender, EventArgs e)
        {
            if (noUncmnItem.Checked) { uncmnItemBox.Enabled = false; uncmnItemBox.ResetText(); pokes[pokeBox.SelectedIndex].itemuncmn = null; }
            else { uncmnItemBox.Enabled = true; }
        }
        private void noRareItem_CheckedChanged(object sender, EventArgs e)
        {
            if (noRareItem.Checked) { rareItemBox.Enabled = false; rareItemBox.ResetText(); pokes[pokeBox.SelectedIndex].itemrare = null; }
            else { rareItemBox.Enabled = true; }
        }
        private void regNumBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].dexnums = regNumBox.Text;
        }
        private void incenseBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].incense = incenseBox.Text;
        }
        private void defaultDexNums_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultDexNums.Checked) { regNumBox.Enabled = false; regNumBox.ResetText(); pokes[pokeBox.SelectedIndex].dexnums = null; }
            else { regNumBox.Enabled = true; }
        }
        private void noIncense_CheckedChanged(object sender, EventArgs e)
        {
            if (noIncense.Checked) { incenseBox.Enabled = false; incenseBox.ResetText(); pokes[pokeBox.SelectedIndex].incense = null; }
            else { incenseBox.Enabled = true; }
        }
        
        private void addEggmoveBtn_Click(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].eggmoves.Add(eggmoveNameBox.Text);
            eggmoveBinder.ResetBindings(false);
            eggmoveBox.SelectedIndex = pokes[pokeBox.SelectedIndex].eggmoves.Count - 1;
            removeEggmoveBtn.Enabled = true;
        }
        private void eggmoveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokes[pokeBox.SelectedIndex].eggmoves.Count > 0)
            {
                eggmoveNameBox.Text = pokes[pokeBox.SelectedIndex].eggmoves[eggmoveBox.SelectedIndex];
                if (pokes[pokeBox.SelectedIndex].eggmoves.Count <= 1) { removeEggmoveBtn.Enabled = false; }
                else { removeEggmoveBtn.Enabled = true; }
            }
        }
        private void removeEggmoveBtn_Click(object sender, EventArgs e)
        {
            if (eggmoveBox.SelectedIndex > 0)
            {
                pokes[pokeBox.SelectedIndex].eggmoves.RemoveAt(eggmoveBox.SelectedIndex);
                eggmoveBox.SelectedIndex -= 1;
                eggmoveBinder.ResetBindings(false);
            }
            else
            {
                pokes[pokeBox.SelectedIndex].eggmoves.RemoveAt(eggmoveBox.SelectedIndex);
                eggmoveBinder.ResetBindings(false);
            }
            if (pokes[pokeBox.SelectedIndex].eggmoves.Count == 0) { removeEggmoveBtn.Enabled = false; }
            else { removeEggmoveBtn.Enabled = true; }
        }

        private void evoBox_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < pokes.Count; i++)
            {
                if (pokes[i].intname == pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].name)
                { pokeBox.SelectedIndex = i; break; }
            }
        }
        private void evoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0)
            {
                evoSpeciesBox.Text = pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].name;
                evoMethodBox.Text = pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].method;
                evoParamBox.Text = pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].param;
                label39.Enabled = true;
                label40.Enabled = true;
                label41.Enabled = true;
                evoSpeciesBox.Enabled = true;
                evoMethodBox.Enabled = true;
                evoParamBox.Enabled = true;
                removeEvoBtn.Enabled = true;
            }
            else { removeEvoBtn.Enabled = false; }
        }
        private void addEvoBtn_Click(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evolutions.Add(new Evo("EVOPOKE", "Level", "32"));
            evolutionBinder.ResetBindings(false);
            evoBox.SelectedIndex = pokes[pokeBox.SelectedIndex].evolutions.Count - 1;
            removeEvoBtn.Enabled = true;
        }
        private void removeEvoBtn_Click(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].evolutions.RemoveAt(evoBox.SelectedIndex);
            evolutionBinder.ResetBindings(false);
            if (pokes[pokeBox.SelectedIndex].evolutions.Count <= 0) { removeEvoBtn.Enabled = false; evoSpeciesBox.Clear(); evoMethodBox.Clear(); evoParamBox.Clear(); }
            else { removeEvoBtn.Enabled = true; }
        }
        private void evoSpeciesBox_TextChanged(object sender, EventArgs e)
        {
            if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0)
            {
                pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].name = evoSpeciesBox.Text;
                evolutionBinder.ResetBindings(false);
            }
        }
        private void evoMethodBox_TextChanged(object sender, EventArgs e)
        {
            if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0)
            {
                pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].method = evoMethodBox.Text;
            }
        }
        private void evoParamBox_TextChanged(object sender, EventArgs e)
        {
            if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0)
            {
                pokes[pokeBox.SelectedIndex].evolutions[evoBox.SelectedIndex].param = evoParamBox.Text;
            }
        }

        private void defaultPY_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultPY.Checked)
            {
                plyBox.Enabled = false;
                pokes[pokeBox.SelectedIndex].battlerpy = 0;
                plyBox.ResetText();
            }
            else { plyBox.Enabled = true; }
        }
        private void defaultEY_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultEY.Checked)
            {
                enyBox.Enabled = false;
                pokes[pokeBox.SelectedIndex].battlerey = 0;
                enyBox.ResetText();
            }
            else { enyBox.Enabled = true; }
        }
        private void defaultAlt_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultAlt.Checked)
            {
                altBox.Enabled = false;
                pokes[pokeBox.SelectedIndex].battleralt = 0;
                altBox.ResetText();
            }
            else { altBox.Enabled = true; }
        }

        private void formnameBox_TextChanged(object sender, EventArgs e)
        {
            pokes[pokeBox.SelectedIndex].formnames = formnameBox.Text;
        }
        private void noFormnames_CheckedChanged(object sender, EventArgs e)
        {
            if (noFormnames.Checked)
            {
                pokes[pokeBox.SelectedIndex].formnames = null;
                formnameBox.Enabled = false;
            }
            else
            {
                pokes[pokeBox.SelectedIndex].formnames = formnameBox.Text;
                formnameBox.Enabled = true;
            }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pokes.Count > 0)
            {
            pokes[pokeBox.SelectedIndex].moveset.Sort(delegate (Moveset m1, Moveset m2) { return m1.level.CompareTo(m2.level); });
            movelistBinder.ResetBindings(false);
            if (string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1) && !string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2)) { pokes[pokeBox.SelectedIndex].ability1 = pokes[pokeBox.SelectedIndex].ability2; pokes[pokeBox.SelectedIndex].ability2 = null; }
            GeneratePokemon pokeGen = new GeneratePokemon(); pokeGen.gennedPokemon =
$@"[{pokes[pokeBox.SelectedIndex].id}]
Name={pokes[pokeBox.SelectedIndex].name}
InternalName={pokes[pokeBox.SelectedIndex].intname}
Type1={pokes[pokeBox.SelectedIndex].type1}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].type2)) { pokeGen.gennedPokemon += $@"Type2={pokes[pokeBox.SelectedIndex].type2}
"; } pokeGen.gennedPokemon +=
$@"BaseStats={pokes[pokeBox.SelectedIndex].stats[0]},{pokes[pokeBox.SelectedIndex].stats[1]},{pokes[pokeBox.SelectedIndex].stats[2]},{pokes[pokeBox.SelectedIndex].stats[5]},{pokes[pokeBox.SelectedIndex].stats[3]},{pokes[pokeBox.SelectedIndex].stats[4]}
GenderRate={pokes[pokeBox.SelectedIndex].genderratio}
GrowthRate={pokes[pokeBox.SelectedIndex].growthrate}
BaseEXP={pokes[pokeBox.SelectedIndex].exp}
EffortPoints={pokes[pokeBox.SelectedIndex].evyield[0]},{pokes[pokeBox.SelectedIndex].evyield[1]},{pokes[pokeBox.SelectedIndex].evyield[2]},{pokes[pokeBox.SelectedIndex].evyield[5]},{pokes[pokeBox.SelectedIndex].evyield[3]},{pokes[pokeBox.SelectedIndex].evyield[4]}
Rareness={pokes[pokeBox.SelectedIndex].catchrate}
Happiness={pokes[pokeBox.SelectedIndex]._happiness}";
if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1)) { pokeGen.gennedPokemon += $@"
Abilities={pokes[pokeBox.SelectedIndex].ability1}"; }
if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2)) { pokeGen.gennedPokemon += $@",{pokes[pokeBox.SelectedIndex].ability2}
"; } else { pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability3)) { pokeGen.gennedPokemon += $@"HiddenAbility={pokes[pokeBox.SelectedIndex].ability3}
"; } pokeGen.gennedPokemon += $@"Moves="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].moveset.Count; i++)
{ if (i != 0) { pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].moveset[i].level + "," + pokes[pokeBox.SelectedIndex].moveset[i].name; } else {
pokeGen.gennedPokemon += pokes[pokeBox.SelectedIndex].moveset[i].level + "," + pokes[pokeBox.SelectedIndex].moveset[i].name; } }
pokeGen.gennedPokemon += @"
"; if (pokes[pokeBox.SelectedIndex].eggmoves.Count > 0) {
pokeGen.gennedPokemon += "EggMoves="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].eggmoves.Count; i++) {
if (i != 0) { pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].eggmoves[i]; }
else { pokeGen.gennedPokemon += pokes[pokeBox.SelectedIndex].eggmoves[i]; } } pokeGen.gennedPokemon += @"
"; } pokeGen.gennedPokemon +=
$@"Compatibility={pokes[pokeBox.SelectedIndex].egg1}"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].egg2)) { pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].egg2; }
pokeGen.gennedPokemon += $@"
StepsToHatch={pokes[pokeBox.SelectedIndex].hatchsteps}
Height={pokes[pokeBox.SelectedIndex].height}
Weight={pokes[pokeBox.SelectedIndex].weight}
Color={pokes[pokeBox.SelectedIndex].color}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].habitat)) { pokeGen.gennedPokemon += $@"Habitat={pokes[pokeBox.SelectedIndex].habitat}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].dexnums)) { pokeGen.gennedPokemon += $@"RegionalNumbers={pokes[pokeBox.SelectedIndex].dexnums}
"; } pokeGen.gennedPokemon +=
$@"Kind={pokes[pokeBox.SelectedIndex].kind}
Pokedex={pokes[pokeBox.SelectedIndex].dexentry}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].formnames)) { pokeGen.gennedPokemon += $@"FormNames={pokes[pokeBox.SelectedIndex].formnames}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemcmn)) { pokeGen.gennedPokemon += $@"WildItemCommon={ pokes[pokeBox.SelectedIndex].itemcmn}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemuncmn)) { pokeGen.gennedPokemon += $@"WildItemUncommon={ pokes[pokeBox.SelectedIndex].itemuncmn}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemrare)) { pokeGen.gennedPokemon += $@"WildItemRare={ pokes[pokeBox.SelectedIndex].itemrare}
"; } if (pokes[pokeBox.SelectedIndex].battlerpy != 0) { pokeGen.gennedPokemon += $@"BattlerPlayerY={pokes[pokeBox.SelectedIndex].battlerpy}
"; } if (pokes[pokeBox.SelectedIndex].battlerey != 0) { pokeGen.gennedPokemon += $@"BattlerEnemyY={pokes[pokeBox.SelectedIndex].battlerey}
"; } if (pokes[pokeBox.SelectedIndex].battleralt != 0) { pokeGen.gennedPokemon += $@"BattlerAltitude={pokes[pokeBox.SelectedIndex].battleralt}
"; } if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0) { pokeGen.gennedPokemon += "Evolutions="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].evolutions.Count; i++)
{ if (i != 0) { pokeGen.gennedPokemon += $@",{pokes[pokeBox.SelectedIndex].evolutions[i].name},{pokes[pokeBox.SelectedIndex].evolutions[i].method},{pokes[pokeBox.SelectedIndex].evolutions[i].param}";
} else { pokeGen.gennedPokemon += $@"{pokes[pokeBox.SelectedIndex].evolutions[i].name},{pokes[pokeBox.SelectedIndex].evolutions[i].method},{pokes[pokeBox.SelectedIndex].evolutions[i].param}"; } } pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].incense)) { pokeGen.gennedPokemon += $@"Incense={pokes[pokeBox.SelectedIndex].incense}
"; } if (show_shape) { pokeGen.gennedPokemon += $@"Shape={pokes[pokeBox.SelectedIndex].shape}
"; } pokeGen.Show();
            }
            else
            {
                MessageBox.Show("There are no Pokémon to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pokes.Count > 0)
            {
                getAllPokemon(true);
            }
            else
            {
                MessageBox.Show("There are no Pokémon to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pokes.Count > 0) {
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); });
            pokeBinder.ResetBindings(false);
            GeneratePokemon pokeGen = new GeneratePokemon(); pokeGen.gennedPokemon = null; pokeGen.gennedPokemon =
$@"[{pokes[pokeBox.SelectedIndex].id}]
Name={pokes[pokeBox.SelectedIndex].name}
InternalName={pokes[pokeBox.SelectedIndex].intname}
Type1={pokes[pokeBox.SelectedIndex].type1}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].type2)) { pokeGen.gennedPokemon += $@"Type2={pokes[pokeBox.SelectedIndex].type2}
"; } pokeGen.gennedPokemon +=
$@"BaseStats={pokes[pokeBox.SelectedIndex].stats[0]},{pokes[pokeBox.SelectedIndex].stats[1]},{pokes[pokeBox.SelectedIndex].stats[2]},{pokes[pokeBox.SelectedIndex].stats[5]},{pokes[pokeBox.SelectedIndex].stats[3]},{pokes[pokeBox.SelectedIndex].stats[4]}
GenderRate={pokes[pokeBox.SelectedIndex].genderratio}
GrowthRate={pokes[pokeBox.SelectedIndex].growthrate}
BaseEXP={pokes[pokeBox.SelectedIndex].exp}
EffortPoints={pokes[pokeBox.SelectedIndex].evyield[0]},{pokes[pokeBox.SelectedIndex].evyield[1]},{pokes[pokeBox.SelectedIndex].evyield[2]},{pokes[pokeBox.SelectedIndex].evyield[5]},{pokes[pokeBox.SelectedIndex].evyield[3]},{pokes[pokeBox.SelectedIndex].evyield[4]}
Rareness={pokes[pokeBox.SelectedIndex].catchrate}
Happiness={pokes[pokeBox.SelectedIndex]._happiness}";
if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability1)) { pokeGen.gennedPokemon += $@"
Abilities={pokes[pokeBox.SelectedIndex].ability1}"; }
if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability2)) { pokeGen.gennedPokemon += $@",{pokes[pokeBox.SelectedIndex].ability2}
"; } else { pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].ability3)) { pokeGen.gennedPokemon += $@"HiddenAbility={pokes[pokeBox.SelectedIndex].ability3}
"; } pokeGen.gennedPokemon += $@"Moves="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].moveset.Count; i++) { if (i != 0) {
pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].moveset[i].level + "," + pokes[pokeBox.SelectedIndex].moveset[i].name; } else {
pokeGen.gennedPokemon += pokes[pokeBox.SelectedIndex].moveset[i].level + "," + pokes[pokeBox.SelectedIndex].moveset[i].name; } } pokeGen.gennedPokemon += @"
"; if (pokes[pokeBox.SelectedIndex].eggmoves.Count > 0) {
pokeGen.gennedPokemon += "EggMoves="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].eggmoves.Count; i++) { if (i != 0) {
pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].eggmoves[i]; } else {
pokeGen.gennedPokemon += pokes[pokeBox.SelectedIndex].eggmoves[i]; } } pokeGen.gennedPokemon += @"
"; } pokeGen.gennedPokemon +=
$@"Compatibility={pokes[pokeBox.SelectedIndex].egg1}"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].egg2)) { pokeGen.gennedPokemon += "," + pokes[pokeBox.SelectedIndex].egg2; }
pokeGen.gennedPokemon += $@"
StepsToHatch={pokes[pokeBox.SelectedIndex].hatchsteps}
Height={pokes[pokeBox.SelectedIndex].height}
Weight={pokes[pokeBox.SelectedIndex].weight}
Color={pokes[pokeBox.SelectedIndex].color}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].habitat)) { pokeGen.gennedPokemon += $@"Habitat={pokes[pokeBox.SelectedIndex].habitat}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].dexnums)) { pokeGen.gennedPokemon += $@"RegionalNumbers={pokes[pokeBox.SelectedIndex].dexnums}
"; } pokeGen.gennedPokemon +=
$@"Kind={pokes[pokeBox.SelectedIndex].kind}
Pokedex={pokes[pokeBox.SelectedIndex].dexentry}
"; if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].formnames)) { pokeGen.gennedPokemon += $@"FormNames={pokes[pokeBox.SelectedIndex].formnames}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemcmn)) { pokeGen.gennedPokemon += $@"WildItemCommon={ pokes[pokeBox.SelectedIndex].itemcmn}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemuncmn)) { pokeGen.gennedPokemon += $@"WildItemUncommon={ pokes[pokeBox.SelectedIndex].itemuncmn}
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].itemrare)) { pokeGen.gennedPokemon += $@"WildItemRare={ pokes[pokeBox.SelectedIndex].itemrare}
"; } if (pokes[pokeBox.SelectedIndex].battlerpy != 0) { pokeGen.gennedPokemon += $@"BattlerPlayerY={pokes[pokeBox.SelectedIndex].battlerpy}
"; } if (pokes[pokeBox.SelectedIndex].battlerey != 0) { pokeGen.gennedPokemon += $@"BattlerEnemyY={pokes[pokeBox.SelectedIndex].battlerey}
"; } if (pokes[pokeBox.SelectedIndex].battleralt != 0) { pokeGen.gennedPokemon += $@"BattlerAltitude={pokes[pokeBox.SelectedIndex].battleralt}
"; } if (pokes[pokeBox.SelectedIndex].evolutions.Count > 0) {
pokeGen.gennedPokemon += "Evolutions="; for (int i = 0; i < pokes[pokeBox.SelectedIndex].evolutions.Count; i++) { if (i != 0) {
pokeGen.gennedPokemon += $@",{pokes[pokeBox.SelectedIndex].evolutions[i].name},{pokes[pokeBox.SelectedIndex].evolutions[i].method},{pokes[pokeBox.SelectedIndex].evolutions[i].param}"; } else {
pokeGen.gennedPokemon += $@"{pokes[pokeBox.SelectedIndex].evolutions[i].name},{pokes[pokeBox.SelectedIndex].evolutions[i].method},{pokes[pokeBox.SelectedIndex].evolutions[i].param}"; } } pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[pokeBox.SelectedIndex].incense)) { pokeGen.gennedPokemon += $@"Incense={pokes[pokeBox.SelectedIndex].incense}
"; } if (show_shape) { pokeGen.gennedPokemon += $@"Shape={pokes[pokeBox.SelectedIndex].shape}
"; }
                exportFile("pokemon.txt", pokeGen.gennedPokemon);
            }
            else
            {
                MessageBox.Show("There are no Pokémon to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pokes.Count > 0)
            {
                exportFile("pokemon.txt", getAllPokemon());
            }
            else
            {
                MessageBox.Show("There are no Pokémon to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pokes.Count > 0)
            {
                pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); });
                pokeBinder.ResetBindings(false);
                DialogResult r = MessageBox.Show("You are about to overwrite pokemon.txt. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    pbsFile("pokemon.txt", getAllPokemon());
                }
            }
            else
            {
                MessageBox.Show("There are no Pokémon to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getAllPokemon(bool show = false)
        {
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); });
            pokeBinder.ResetBindings(false);
            GeneratePokemon pokeGen = new GeneratePokemon();
            pokeGen.gennedPokemon = null;
            for (int a = 0; a < pokes.Count; a++)
            {
                Text = "Pokémon Editor - "+(Convert.ToInt16(Convert.ToDouble(a) / Convert.ToDouble(pokes.Count) * 100)).ToString()+"%";
                pokes[a].moveset.Sort(delegate (Moveset m1, Moveset m2) { return m1.level.CompareTo(m2.level); });
                movelistBinder.ResetBindings(false);
                if (string.IsNullOrEmpty(pokes[a].ability1) && !string.IsNullOrEmpty(pokes[a].ability2)) { pokes[a].ability1 = pokes[a].ability2; pokes[a].ability2 = null; }
pokeGen.gennedPokemon +=
$@"[{pokes[a].id}]
Name={pokes[a].name}
InternalName={pokes[a].intname}
Type1={pokes[a].type1}
"; if (!string.IsNullOrEmpty(pokes[a].type2)) { pokeGen.gennedPokemon += $@"Type2={pokes[a].type2}
"; } pokeGen.gennedPokemon +=
$@"BaseStats={pokes[a].stats[0]},{pokes[a].stats[1]},{pokes[a].stats[2]},{pokes[a].stats[5]},{pokes[a].stats[3]},{pokes[a].stats[4]}
GenderRate={pokes[a].genderratio}
GrowthRate={pokes[a].growthrate}
BaseEXP={pokes[a].exp}
EffortPoints={pokes[a].evyield[0]},{pokes[a].evyield[1]},{pokes[a].evyield[2]},{pokes[a].evyield[5]},{pokes[a].evyield[3]},{pokes[a].evyield[4]}
Rareness={pokes[a].catchrate}
Happiness={pokes[a]._happiness}";
if (!string.IsNullOrEmpty(pokes[a].ability1)) { pokeGen.gennedPokemon += $@"
Abilities={pokes[a].ability1}"; }
if (!string.IsNullOrEmpty(pokes[a].ability2)) { pokeGen.gennedPokemon += $@",{pokes[a].ability2}
"; } else { pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[a].ability3)) { pokeGen.gennedPokemon += $@"HiddenAbility={pokes[a].ability3}
"; } pokeGen.gennedPokemon += $@"Moves="; for (int i = 0; i < pokes[a].moveset.Count; i++) { if (i != 0) {
pokeGen.gennedPokemon += "," + pokes[a].moveset[i].level + "," + pokes[a].moveset[i].name; } else {
pokeGen.gennedPokemon += pokes[a].moveset[i].level + "," + pokes[a].moveset[i].name; } } pokeGen.gennedPokemon += @"
"; if (pokes[a].eggmoves.Count > 0) {
pokeGen.gennedPokemon += "EggMoves="; for (int i = 0; i < pokes[a].eggmoves.Count; i++) { if (i != 0)
{ pokeGen.gennedPokemon += "," + pokes[a].eggmoves[i]; } else { pokeGen.gennedPokemon += pokes[a].eggmoves[i]; } } pokeGen.gennedPokemon += @"
"; } pokeGen.gennedPokemon +=
$@"Compatibility={pokes[a].egg1}"; if (!string.IsNullOrEmpty(pokes[a].egg2)) { pokeGen.gennedPokemon += "," + pokes[a].egg2; }
pokeGen.gennedPokemon += $@"
StepsToHatch={pokes[a].hatchsteps}
Height={pokes[a].height}
Weight={pokes[a].weight}
Color={pokes[a].color}
"; if (!string.IsNullOrEmpty(pokes[a].habitat)) { pokeGen.gennedPokemon += $@"Habitat={pokes[a].habitat}
"; } if (!string.IsNullOrEmpty(pokes[a].dexnums)) { pokeGen.gennedPokemon += $@"RegionalNumbers={pokes[a].dexnums}
"; } pokeGen.gennedPokemon +=
$@"Kind={pokes[a].kind}
Pokedex={pokes[a].dexentry}
"; if (!string.IsNullOrEmpty(pokes[a].formnames)) { pokeGen.gennedPokemon += $@"FormNames={pokes[a].formnames}
"; } if (!string.IsNullOrEmpty(pokes[a].itemcmn)) { pokeGen.gennedPokemon += $@"WildItemCommon={ pokes[a].itemcmn}
"; } if (!string.IsNullOrEmpty(pokes[a].itemuncmn)) { pokeGen.gennedPokemon += $@"WildItemUncommon={ pokes[a].itemuncmn}
"; } if (!string.IsNullOrEmpty(pokes[a].itemrare)) { pokeGen.gennedPokemon += $@"WildItemRare={ pokes[a].itemrare}
"; } if (pokes[a].battlerpy != 0) { pokeGen.gennedPokemon += $@"BattlerPlayerY={pokes[a].battlerpy}
"; } if (pokes[a].battlerey != 0) { pokeGen.gennedPokemon += $@"BattlerEnemyY={pokes[a].battlerey}
"; } if (pokes[a].battleralt != 0) { pokeGen.gennedPokemon += $@"BattlerAltitude={pokes[a].battleralt}
"; } if (pokes[a].evolutions.Count > 0) {
pokeGen.gennedPokemon += "Evolutions="; for (int i = 0; i < pokes[a].evolutions.Count; i++) { if (i != 0) {
pokeGen.gennedPokemon += $@",{pokes[a].evolutions[i].name},{pokes[a].evolutions[i].method},{pokes[a].evolutions[i].param}"; } else {
pokeGen.gennedPokemon += $@"{pokes[a].evolutions[i].name},{pokes[a].evolutions[i].method},{pokes[a].evolutions[i].param}"; } } pokeGen.gennedPokemon += @"
"; } if (!string.IsNullOrEmpty(pokes[a].incense)) { pokeGen.gennedPokemon += $@"Incense={pokes[a].incense}
"; } if (show_shape) { pokeGen.gennedPokemon += $@"Shape={pokes[a].shape}
"; } }
            Text = "Pokémon Editor";
            if (show)
            {
                pokeGen.Show();
                return null;
            }
            return pokeGen.gennedPokemon;
        }

        private void statTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.statTotal.CompareTo(p2.statTotal); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatTotal";
        }
        private void hPStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[0].CompareTo(p2.stats[0]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatHP";
        }
        private void attackStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[1].CompareTo(p2.stats[1]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatAtk";
        }
        private void defenseStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[2].CompareTo(p2.stats[2]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatDef";
        }
        private void specialAttackStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[3].CompareTo(p2.stats[3]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatSpAtk";
        }
        private void specialDefenseStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[4].CompareTo(p2.stats[4]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatSpDef";
        }
        private void speedStatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[5].CompareTo(p2.stats[5]); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "StatSpeed";
        }

        private void loadImageFootprint()
        {
            if (File.Exists($@"Graphics\Icons\Footprints\footprint{thisid}.png"))
            {
                Image im;
                using (var img = new Bitmap($@"Graphics\Icons\Footprints\footprint{thisid}.png")) { im = new Bitmap(img); }
                pictureBox1.Width = im.Width;
                pictureBox1.Height = im.Height;
                pictureBox1.Image = im;
            }
            else
            {
                pictureBox1.Image = SuperGen.Properties.Resources.nil;
            }
        }

        private void loadImagePartyIcon(string ex)
        {
            if (File.Exists($@"Graphics\Icons\icon{thisid}{ex}.gif"))
            {
                Image im;
                using (var img = new Bitmap($@"Graphics\Icons\icon{thisid}{ex}.gif")) { im = new Bitmap(img); }
                pictureBox3.Width = im.Width;
                pictureBox3.Height = im.Height;
                pictureBox3.ImageLocation = $@"Graphics\Icons\icon{thisid}{ex}.gif";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                animatedSprite2.Sprite = SuperGen.Properties.Resources.nil;
                pictureBox3.Location = animatedSprite1.Location;
                pictureBox3.BringToFront();
            }
            else if (File.Exists($@"Graphics\Icons\icon{thisid}{ex}.png"))
            {
                Image im;
                using (var img = new Bitmap($@"Graphics\Icons\icon{thisid}{ex}.png")) { im = new Bitmap(img); }
                animatedSprite2.Sprite = im;
                animatedSprite2.Frame_Height = im.Height;
                animatedSprite2.Frame_Width = im.Height;
                animatedSprite2.Width = im.Height;
                animatedSprite2.Height = im.Height;
                animatedSprite2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = SuperGen.Properties.Resources.nil;
                pictureBox3.SendToBack();
            }
            else
            {
                animatedSprite2.Sprite = SuperGen.Properties.Resources.nil;
                pictureBox3.Image = SuperGen.Properties.Resources.nil;
                pictureBox3.SendToBack();
            }
        }

        private void loadImageFront(string ex)
        {
            bool usingEBS = Directory.Exists(@"Graphics\Battlers\Front");
            string ebsPath = @"Graphics\Battlers\Front";
            string normalPath = @"Graphics\Battlers";
            if (usingEBS)
            {
                if (File.Exists($@"{ebsPath}\{thisid}{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{ebsPath}\{thisid}{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{ebsPath}\{thisid}{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
            else
            {
                if (File.Exists($@"{normalPath}\{thisid}{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{normalPath}\{thisid}{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{normalPath}\{thisid}{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
        }
        private void loadImageBack(string ex)
        {
            bool usingEBS = Directory.Exists(@"Graphics\Battlers\Back");
            string ebsPath = @"Graphics\Battlers\Back";
            string normalPath = @"Graphics\Battlers";
            if (usingEBS)
            {
                if (File.Exists($@"{ebsPath}\{thisid}{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{ebsPath}\{thisid}{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{ebsPath}\{thisid}{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
            else
            {
                if (File.Exists($@"{normalPath}\{thisid}b{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}b{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{normalPath}\{thisid}b{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{normalPath}\{thisid}b{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}b{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
        }
        private void loadImageFrontShiny(string ex)
        {
            bool usingEBS = Directory.Exists(@"Graphics\Battlers\FrontShiny");
            string ebsPath = @"Graphics\Battlers\FrontShiny";
            string normalPath = @"Graphics\Battlers";
            if (usingEBS)
            {
                if (File.Exists($@"{ebsPath}\{thisid}{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{ebsPath}\{thisid}{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{ebsPath}\{thisid}{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
            else
            {
                if (File.Exists($@"{normalPath}\{thisid}s{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}s{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{normalPath}\{thisid}s{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{normalPath}\{thisid}s{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}s{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
        }
        private void loadImageBackShiny(string ex)
        {
            bool usingEBS = Directory.Exists(@"Graphics\Battlers\BackShiny");
            string ebsPath = @"Graphics\Battlers\BackShiny";
            string normalPath = @"Graphics\Battlers";
            if (usingEBS)
            {
                if (File.Exists($@"{ebsPath}\{thisid}{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{ebsPath}\{thisid}{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{ebsPath}\{thisid}{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{ebsPath}\{thisid}{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
            else
            {
                if (File.Exists($@"{normalPath}\{thisid}sb{ex}.gif"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}sb{ex}.gif")) { im = new Bitmap(img); }
                    pictureBox2.Width = im.Width;
                    pictureBox2.Height = im.Height;
                    pictureBox2.ImageLocation = $@"{normalPath}\{thisid}sb{ex}.gif";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Location = animatedSprite1.Location;
                    pictureBox2.BringToFront();
                }
                else if (File.Exists($@"{normalPath}\{thisid}sb{ex}.png"))
                {
                    Image im;
                    using (var img = new Bitmap($@"{normalPath}\{thisid}sb{ex}.png")) { im = new Bitmap(img); }
                    animatedSprite1.Sprite = im;
                    animatedSprite1.Frame_Height = im.Height;
                    animatedSprite1.Frame_Width = im.Height;
                    animatedSprite1.Width = im.Height;
                    animatedSprite1.Height = im.Height;
                    animatedSprite1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
                else
                {
                    animatedSprite1.Sprite = SuperGen.Properties.Resources.nil;
                    pictureBox2.Image = SuperGen.Properties.Resources.nil;
                    pictureBox2.SendToBack();
                }
            }
        }

        private void frontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frontToolStripMenuItem.Checked = true;
            backToolStripMenuItem.Checked = false;
            shinyFrontToolStripMenuItem.Checked = false;
            shinyBackToolStripMenuItem.Checked = false;
            showFront.Checked = true;
            showBack.Checked = false;
            showShinyFront.Checked = false;
            showShinyBack.Checked = false;
            loadImageFront(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frontToolStripMenuItem.Checked = false;
            backToolStripMenuItem.Checked = true;
            shinyFrontToolStripMenuItem.Checked = false;
            shinyBackToolStripMenuItem.Checked = false;
            showFront.Checked = false;
            showBack.Checked = true;
            showShinyFront.Checked = false;
            showShinyBack.Checked = false;
            loadImageBack(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }
        private void shinyFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frontToolStripMenuItem.Checked = false;
            backToolStripMenuItem.Checked = false;
            shinyFrontToolStripMenuItem.Checked = true;
            shinyBackToolStripMenuItem.Checked = false;
            showFront.Checked = false;
            showBack.Checked = false;
            showShinyFront.Checked = true;
            showShinyBack.Checked = false;
            loadImageFrontShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }
        private void shinyBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frontToolStripMenuItem.Checked = false;
            backToolStripMenuItem.Checked = false;
            shinyFrontToolStripMenuItem.Checked = false;
            shinyBackToolStripMenuItem.Checked = true;
            showFront.Checked = false;
            showBack.Checked = false;
            showShinyFront.Checked = false;
            showShinyBack.Checked = true;
            loadImageBackShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }

        private void showFront_CheckedChanged(object sender, EventArgs e)
        {
            if (showFront.Checked)
            {
                showBack.Checked = false;
                showShinyFront.Checked = false;
                showShinyBack.Checked = false;
                loadImageFront(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            }
        }
        private void showBack_CheckedChanged(object sender, EventArgs e)
        {
            if (showBack.Checked)
            {
                showFront.Checked = false;
                showShinyFront.Checked = false;
                showShinyBack.Checked = false;
                loadImageBack(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            }
        }
        private void showShinyFront_CheckedChanged(object sender, EventArgs e)
        {
            if (showShinyFront.Checked)
            {
                showFront.Checked = false;
                showBack.Checked = false;
                showShinyBack.Checked = false;
                loadImageFrontShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            }
        }
        private void showShinyBack_CheckedChanged(object sender, EventArgs e)
        {
            if (showShinyBack.Checked)
            {
                showFront.Checked = false;
                showBack.Checked = false;
                showShinyFront.Checked = false;
                loadImageBackShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            }
        }

        private void formSpriteBox_ValueChanged(object sender, EventArgs e)
        {
            string val = $"_{formSpriteBox.Value}";
            if (showFront.Checked)
            { loadImageFront(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null); }
            else if (showBack.Checked)
            { loadImageBack(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null); }
            else if (showShinyFront.Checked)
            { loadImageFrontShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null); }
            else if (showShinyFront.Checked)
            { loadImageBackShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            } else { loadImageFront(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null); }
            loadImagePartyIcon(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }

        private void setDexNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DexManager dm = new DexManager();
            dm.pokemon = pokes;
            dm.ShowDialog();
            if (!dm.error)
            {
                for (int i = 0; i < pokes.Count; i++)
                {
                    pokes[i].dexnums = null;
                    for (int j = 0; j < dm.dexes.Count; j++)
                    {
                        bool found_in_dex = false;
                        for (int k = 0; k < dm.dexes[j].entries.Count; k++)
                        {
                            if (pokes[i].id == dm.dexes[j].entries[k].id)
                            {
                                pokes[i].dexnums += $"{dm.dexes[j].entries[k].index},";
                                found_in_dex = true;
                            }
                        }
                        if (!found_in_dex)
                        {
                            pokes[i].dexnums += ",";
                        }
                    }
                    try
                    {
                        List<char> chars = new List<char>();
                        chars = pokes[i].dexnums.ToCharArray().ToList();
                        bool allcommas = true;
                        for (int j = 0; j < chars.Count; j++)
                        {
                            if (chars[j] != ',') allcommas = false;
                        }
                        if (allcommas) { pokes[i].dexnums = null; }
                        else
                        {
                            chars.RemoveAt(chars.Count - 1);
                            pokes[i].dexnums = null;
                            for (int j = 0; j < chars.Count; j++)
                            {
                                pokes[i].dexnums += chars[j];
                            }
                        }
                    }
                    catch (Exception) { }

                    try
                    {
                        List<char> chars = new List<char>();
                        chars = pokes[i].dexnums.ToCharArray().ToList();
                        chars.Reverse();
                        while (chars[0] == ',')
                        {
                            chars.RemoveAt(0);
                        }
                        chars.Reverse();
                        string ret = null;
                        for (int j = 0; j < chars.Count; j++)
                        {
                            ret += chars[j];
                        }
                        pokes[i].dexnums = ret;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            
            pokeBinder.ResetBindings(false);
            pokeBox_SelectedIndexChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ext = formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            if (!Directory.Exists("Audio") || !Directory.Exists(@"Audio\SE") || !Directory.Exists(@"Audio\SE\Cries")) { MessageBox.Show("One or more audio folders are missing. The cry cannot play.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (File.Exists($@"Audio\SE\Cries\{thisid}Cry{ext}.wav"))
            {
                sp = new System.Media.SoundPlayer($@"Audio\SE\Cries\{thisid}Cry{ext}.wav");
                sp.Play();
            }
            else
            {
                try { sp = new System.Media.SoundPlayer($@"Audio\SE\Cries\{thisid}Cry.wav"); sp.Play(); }
                catch (FileNotFoundException) { if (ext != null) { MessageBox.Show($"\"{thisid}Cry{ext}.wav\" nor \"{thisid}Cry.wav\" could be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } else { MessageBox.Show($"\"{thisid}Cry.wav\" couldn't be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } return; }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string ext = null;
            if (formSpriteBox.Value > 0) { ext = "_" + formSpriteBox.Value; }

            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = $"Choose a cry for {pokes[pokeBox.SelectedIndex].name}";
            fd.Filter = "Audio Files (*.wav)|*.wav|"
                        + "All Files (*.*)|*.*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(fd.FileName, $@"Audio\SE\Cries\{thisid}Cry{ext}.wav", true);
            }
        }

        private void showFront_Click(object sender, EventArgs e)
        {
            if (!showFront.Checked) { animatedSprite1.Sprite = SuperGen.Properties.Resources.nil; pictureBox2.Image = SuperGen.Properties.Resources.nil; }
        }
        private void showBack_Click(object sender, EventArgs e)
        {
            if (!showBack.Checked) { animatedSprite1.Sprite = SuperGen.Properties.Resources.nil; pictureBox2.Image = SuperGen.Properties.Resources.nil; }
        }
        private void showShinyFront_Click(object sender, EventArgs e)
        {
            if (!showShinyFront.Checked) { animatedSprite1.Sprite = SuperGen.Properties.Resources.nil; pictureBox2.Image = SuperGen.Properties.Resources.nil; }
        }
        private void showShinyBack_Click(object sender, EventArgs e)
        {
            if (!showShinyBack.Checked) { animatedSprite1.Sprite = SuperGen.Properties.Resources.nil; pictureBox2.Image = SuperGen.Properties.Resources.nil; }
        }

        private void disposeData()
        {
            thisid = null;
            pokes = new List<Poke>();
            moves = new List<string>();
            abilities = new List<string>();
            items = new List<string>();
            types = new List<string>();
            eggmoves = new List<string>();
            evopoke = new List<string>();
            evomethod = new List<string>();
            evoparam = new List<string>();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                SuperGen.Properties.Settings.Default.SizeX = Width;
                SuperGen.Properties.Settings.Default.SizeY = Height;
                if (frontToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "Front"; }
                else if (backToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "Back"; }
                else if (shinyFrontToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "FrontShiny"; }
                else if (shinyBackToolStripMenuItem.Checked) { SuperGen.Properties.Settings.Default.Show = "BackShiny"; }
                else { SuperGen.Properties.Settings.Default.Show = "Front"; }
                SuperGen.Properties.Settings.Default.IntName = pokes[pokeBox.SelectedIndex].intname;
                SuperGen.Properties.Settings.Default.FormSprite = Convert.ToInt32(formSpriteBox.Value);
                if (formSpriteBox.Value > 0) { SuperGen.Properties.Settings.Default.SelForm = "_" + formSpriteBox.Value.ToString(); }
                else { SuperGen.Properties.Settings.Default.SelForm = "0"; }
                SuperGen.Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
                disposeData();
            }
        }

        private void PokeGenerator_SizeChanged(object sender, EventArgs e)
        {
            pokeBox.Height = Height - 95;
            addPokeBtn.Location = new Point(addPokeBtn.Location.X, pokeBox.Height + 32);
            button2.Location = new Point(button2.Location.X, pokeBox.Height + 32);
            AutoScrollPosition = new Point(0, 0);
        }

        private void refreshBattleSprites(object sender, EventArgs e)
        {
            if (showFront.Checked) loadImageFront(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            else if (showBack.Checked) loadImageBack(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            else if (showShinyFront.Checked) loadImageFrontShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
            else if (showShinyBack.Checked) loadImageBackShiny(formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null);
        }

        private void openPokemontxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"PBS\pokemon.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = $" sprite for {pokes[pokeBox.SelectedIndex].name}";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png";
            ofd.Title = "Choose a ";
            string l = null;
            string dir = null;
            if (showFront.Checked) { ofd.Title += $"front{t}"; l = null; dir = "Front"; }
            else if (showBack.Checked) { ofd.Title += $"back{t}"; l = "b"; dir = "Back"; }
            else if (showShinyFront.Checked) { ofd.Title += $"shiny front{t}"; l = "s"; dir = "FrontShiny"; }
            else if (showShinyBack.Checked) { ofd.Title += $"shiny back{t}"; l = "sb"; dir = "BackShiny"; }
            else { showFront.Checked = true; button1_Click(sender, e); }

            bool usingEBS = Directory.Exists(@"Graphics\Battlers\Front");
            string ext = usingEBS ? null : l;
            ext += formSpriteBox.Value > 0 ? $"_{formSpriteBox.Value}" : null;

            string path = usingEBS ? $@"Graphics\Battlers\{dir}\" : @"Graphics\Battlers\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists($"{path}{thisid}{ext}.png")) { File.Delete($"{path}{thisid}{ext}.png"); }
                File.Copy(ofd.FileName, $"{path}{thisid}{ext}.png");
            }
            pokeBox.SelectedIndex = pokeBox.SelectedIndex;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label2, "The internal ID of the species. This\r\nShould increment without missing numbers.");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label1, "The name of the species as displayed.");
        }

        private void label48_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label48, "The internal name of the species. This can\r\n be referred to with a symbol (e.g. :PICHU)");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            typesTip.SetToolTip(label3, "What types the species has. The species has to\r\nHave one type, but can have two.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            statsTip.SetToolTip(label4, "The Base Stats of the species. This\r\nDetermines how strong the species is.");
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            femaleRatioTip.SetToolTip(label11, "The chance for the species to\r\nGenerate as a female.");
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            growthRateTip.SetToolTip(label12, "How quickly the species levels\r\nUp at its specific level.");
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            baseEXPTip.SetToolTip(label13, "How much experience you gain\r\nFor defeating this species.");
        }

        private void label21_MouseHover(object sender, EventArgs e)
        {
            catchRateTip.SetToolTip(label21, "How hard this species is to catch.\r\nThe lower, the harder.");
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            happinessTip.SetToolTip(label22, "How happy this species is towards\r\nThe trainer by default.");
        }

        private void label26_MouseHover(object sender, EventArgs e)
        {
            eggGroupsTip.SetToolTip(label26, "What species this species\r\nCan breed with.");
        }

        private void label27_MouseHover(object sender, EventArgs e)
        {
            hatchTimeTip.SetToolTip(label27, "How many steps are required\r\nFor this species to hatch.");
        }

        private void label28_MouseHover(object sender, EventArgs e)
        {
            heightTip.SetToolTip(label28, "How tall this species is.");
        }

        private void label29_MouseHover(object sender, EventArgs e)
        {
            weightTip.SetToolTip(label29, "How heavy this species is.");
        }

        private void label30_MouseHover(object sender, EventArgs e)
        {
            colorTip.SetToolTip(label30, "What color the species is\r\nAccording to the Pokédex.");
        }

        private void label31_MouseHover(object sender, EventArgs e)
        {
            kindTip.SetToolTip(label31, "What kind of Pokémon this species is\r\n(e.g. \"The Seed Pokémon\")");
        }

        private void label20_MouseHover(object sender, EventArgs e)
        {
            evYieldTip.SetToolTip(label20, "What EVs you gain for defeating this species.");
        }

        private void findInternalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < pokes.Count; i++)
            {
                if (pokes[i].intname == IntNameFinder.result.ToUpper())
                {
                    pokeBox.SelectedIndex = pokes.IndexOf(pokes[i]);
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
                pokes.Clear();
                moves.Clear();
                abilities.Clear();
                items.Clear();
                types.Clear();
                eggmoves.Clear();
                evopoke.Clear();
                evomethod.Clear();
                evoparam.Clear();
                PokeGen_Load(sender, e);
            }
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            movesetTip.SetToolTip(label23, "What moves this species learns at what levels.");
        }

        private void label32_MouseHover(object sender, EventArgs e)
        {
            descTip.SetToolTip(label32, "The description of the species as shown in the Pokédex.");
        }

        private void label33_MouseHover(object sender, EventArgs e)
        {
            abilityTip.SetToolTip(label33, "What abilities this species can have.");
        }

        private void label34_MouseHover(object sender, EventArgs e)
        {
            hiddenAbilTip.SetToolTip(label34, "What Hidden Ability this species can have.");
        }

        private void label35_MouseHover(object sender, EventArgs e)
        {
            habitatTip.SetToolTip(label35, "What habitat this species is naturally found in, according to the Pokédex.");
        }

        private void label42_MouseHover(object sender, EventArgs e)
        {
            cmnItemTip.SetToolTip(label42, "What item this species can hold in the wild with a 50% chance.\r\nIf all wild items are set to the same item, the species will always hold this in the wild.");
        }

        private void label43_MouseHover(object sender, EventArgs e)
        {
            uncmnItemTip.SetToolTip(label43, "What item this species can hold in the wild with a 5% chance.\r\nIf all wild items are set to the same item, the species will always hold this in the wild.");
        }

        private void label44_MouseHover(object sender, EventArgs e)
        {
            rareItemTip.SetToolTip(label44, "What item this species can hold in the wild with a 1% chance.\r\nIf all wild items are set to the same item, the species will always hold this in the wild.");
        }

        private void label45_MouseHover(object sender, EventArgs e)
        {
            dexNumsTip.SetToolTip(label45, "What numbers this species has in the Pokédexes.\r\nA more organized editor for this is found under \"More\"");
        }

        private void label37_MouseHover(object sender, EventArgs e)
        {
            eggmovesTip.SetToolTip(label37, "What moves this species can learn if its parents have one of these moves.");
        }

        private void label46_MouseHover(object sender, EventArgs e)
        {
            incenseTip.SetToolTip(label46, "Incense");
        }

        private void label50_MouseHover(object sender, EventArgs e)
        {
            playerYTip.SetToolTip(label50, "The positioning of the battler sprite of the Player's species.");
        }

        private void label51_MouseHover(object sender, EventArgs e)
        {
            enemyYTip.SetToolTip(label51, "The positioning of the battler sprite of the Opponent's species.");
        }

        private void label52_MouseHover(object sender, EventArgs e)
        {
            altitudeTip.SetToolTip(label52, "The altitude positioning of the species. Determines shadow if not using the Elite Battle System.");
        }

        private void label53_MouseHover(object sender, EventArgs e)
        {
            formNamesTip.SetToolTip(label53, "The names of the multiple forms this species has. Separate forms with commas.");
        }

        private void label39_MouseHover(object sender, EventArgs e)
        {
            speciesTip.SetToolTip(label39, "What species this species evolves into if evolving with this Evolution Method.");
        }

        private void label40_MouseHover(object sender, EventArgs e)
        {
            methodTip.SetToolTip(label40, "What method this species evolves with.");
        }

        private void label41_MouseHover(object sender, EventArgs e)
        {
            paramTip.SetToolTip(label41, "The parameter passed along with the evolution method.");
        }

        private void label58_MouseHover(object sender, EventArgs e)
        {
            speciesIconTip.SetToolTip(label58, "The Icon of the species as appears in the party scene.");
        }

        private void label56_MouseHover(object sender, EventArgs e)
        {
            formTip.SetToolTip(label56, "What form of this species the party icon and cry will be set for. This does not apply to the footprint.");
        }

        private void label57_MouseHover(object sender, EventArgs e)
        {
            speciesPrintTip.SetToolTip(label57, "The footprint of the species as appears in the Pokédex.");
        }

        private void label60_MouseHover(object sender, EventArgs e)
        {
            speciesCryTip.SetToolTip(label60, "The cry of the species as played in battle.");
        }

        private void label61_MouseHover(object sender, EventArgs e)
        {
            shapeTip.SetToolTip((Label) fieldSplitter.TabPages[0].Controls["label61"], "The shape of the Pokémon as shown in the Pokédex.");
        }

        private void shapeBox_ValueChanged(object sender, EventArgs e)
        {
            if (starting) return;
            pokes[pokeBox.SelectedIndex].shape = (int) ((NumericUpDown) fieldSplitter.TabPages[0].Controls[shapeIndex]).Value;
            int shape = pokes[pokeBox.SelectedIndex].shape;
            Bitmap bmp = null;
            if (shape == 1)
                bmp = SuperGen.Properties.Resources.shape1;
            else if (shape == 2)
                bmp = SuperGen.Properties.Resources.shape2;
            else if (shape == 3)
                bmp = SuperGen.Properties.Resources.shape3;
            else if (shape == 4)
                bmp = SuperGen.Properties.Resources.shape4;
            else if (shape == 5)
                bmp = SuperGen.Properties.Resources.shape5;
            else if (shape == 6)
                bmp = SuperGen.Properties.Resources.shape6;
            else if (shape == 7)
                bmp = SuperGen.Properties.Resources.shape7;
            else if (shape == 8)
                bmp = SuperGen.Properties.Resources.shape8;
            else if (shape == 9)
                bmp = SuperGen.Properties.Resources.shape9;
            else if (shape == 10)
                bmp = SuperGen.Properties.Resources.shape10;
            else if (shape == 11)
                bmp = SuperGen.Properties.Resources.shape11;
            else if (shape == 12)
                bmp = SuperGen.Properties.Resources.shape12;
            else if (shape == 13)
                bmp = SuperGen.Properties.Resources.shape13;
            else if (shape == 14)
                bmp = SuperGen.Properties.Resources.shape14;
            else
                bmp = SuperGen.Properties.Resources.shape1;
            ((PictureBox) fieldSplitter.TabPages[0].Controls[shapeImageIndex]).Image = bmp;
        }

        private void byShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poke curPoke = pokes[pokeBox.SelectedIndex];
            pokes.Sort(delegate (Poke p1, Poke p2) { return p1.shape.CompareTo(p2.shape); });
            pokes.Reverse();
            pokeBinder.ResetBindings(false);
            pokeBox.SelectedIndex = pokes.IndexOf(curPoke);
            SuperGen.Properties.Settings.Default.SortMethod = "Shape";
        }
    }
}