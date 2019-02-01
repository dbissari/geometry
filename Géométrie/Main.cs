using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Géométrie
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        System.Drawing.Point positionClick;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                positionClick = e.Location;
        }

        private void cbtypefigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();
            lbinfo.Text = "";
            btannuler.Enabled = true;
            gbinfo.Visible = false;
            if (cbtypefigure.SelectedIndex==0)
            {
                lbfigure.Visible = true;
                cbfigure.Visible = true;
                lbmethode.Visible = false;
                cbmethode.Visible = false;
                cbfigure.Items.Clear();
                cbfigure.Items.Add("Quelconque");
                cbfigure.Items.Add("Isocèle");
                cbfigure.Items.Add("Equilateral");
            }
            else if (cbtypefigure.SelectedIndex==1)
            {
                lbfigure.Visible = true;
                cbfigure.Visible = true;
                lbmethode.Visible = false;
                cbmethode.Visible = false;
                cbfigure.Items.Clear();
                cbfigure.Items.Add("Carré");
                cbfigure.Items.Add("Rectangle");
                cbfigure.Items.Add("Losange");
                cbfigure.Items.Add("Trapèze");
            }
            else if (cbtypefigure.SelectedIndex==2)
            {
                lbfigure.Visible = false;
                cbfigure.Visible = false;
                lbmethode.Visible = true;
                cbmethode.Visible = true;
                cbmethode.Items.Clear();
                cbmethode.Items.Add("Exemple");
                cbmethode.Items.Add("Centre connu");
                cbmethode.Items.Add("Rayon connu");
                cbmethode.Items.Add("Centre et rayon connus");
            }
            else
            {
                lbfigure.Visible = false;
                cbfigure.Visible = false;
                lbmethode.Visible = false;
                cbmethode.Visible = false;
            }
        }

        private void cbfigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbinfo.Visible = false;
            reset();
            lbinfo.Text = "";
            if (cbtypefigure.SelectedIndex == 0)
            {
                lbmethode.Visible = true;
                cbmethode.Visible = true;
                gbinfo.Visible = false;
                if (cbfigure.SelectedIndex == 0)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Un point connu");
                    cbmethode.Items.Add("Deux points connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
                else if (cbfigure.SelectedIndex == 1)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Côté double connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Côté connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
            }
            else if (cbtypefigure.SelectedIndex==1)
            {
                lbmethode.Visible = true;
                cbmethode.Visible = true;
                if (cbfigure.SelectedIndex==0)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Côté connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
                else if (cbfigure.SelectedIndex==1)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Dimensions connues");
                    cbmethode.Items.Add("Tous les points connus");
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Côté connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
                else if (cbfigure.SelectedIndex==3)
                {
                    cbmethode.Items.Clear();
                    cbmethode.Items.Add("Exemple");
                    cbmethode.Items.Add("Un côté connu");
                    cbmethode.Items.Add("Tous les points connus");
                }
            }
            else
            {
                lbmethode.Visible = true;
                cbmethode.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox1.Text.Length; i++)
                        if (textBox1.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox1.Text == "0")
                    {
                        textBox1.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox1.Text.Length; i++)
                            if (textBox1.Text[i] == '-' || (textBox1.Text != "" && textBox1.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox2.Text.Length; i++)
                        if (textBox2.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox2.Text == "0")
                    {
                        textBox2.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox2.Text.Length; i++)
                            if (textBox2.Text[i] == '-' || (textBox2.Text != "" && textBox2.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < tbvar.Text.Length; i++)
                        if (tbvar.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox4.Text.Length; i++)
                        if (textBox4.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox4.Text == "0")
                    {
                        textBox4.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox4.Text.Length; i++)
                            if (textBox4.Text[i] == '-' || (textBox4.Text != "" && textBox4.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox9.Text.Length; i++)
                        if (tbvar.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox9.Text == "0")
                    {
                        textBox9.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox9.Text.Length; i++)
                            if (textBox9.Text[i] == '-' || (textBox9.Text != "" && textBox9.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox6.Text.Length; i++)
                        if (textBox6.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox6.Text == "0")
                    {
                        textBox6.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox6.Text.Length; i++)
                            if (textBox6.Text[i] == '-' || (textBox6.Text != "" && textBox6.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox5.Text.Length; i++)
                        if (textBox5.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox5.Text == "0")
                    {
                        textBox5.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox5.Text.Length; i++)
                            if (textBox5.Text[i] == '-' || (textBox5.Text != "" && textBox5.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox8.Text.Length; i++)
                        if (textBox8.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox8.Text == "0")
                    {
                        textBox8.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox8.Text.Length; i++)
                            if (textBox8.Text[i] == '-' || (textBox8.Text != "" && textBox8.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '-')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
                if (e.KeyChar == ',')
                {
                    bool virg = false;
                    for (int i = 0; i < textBox7.Text.Length; i++)
                        if (textBox7.Text[i] == ',')
                            virg = true;
                    if (virg)
                        e.Handled = true;
                }
                if (e.KeyChar == '-')
                {
                    bool virg = false;
                    if (textBox7.Text == "0")
                    {
                        textBox7.Text = "";
                        e.Handled = false;
                    }
                    else
                        for (int i = 0; i < textBox7.Text.Length; i++)
                            if (textBox7.Text[i] == '-' || (textBox7.Text != "" && textBox7.Text[0] != '-'))
                                virg = true;
                    if (virg)
                        e.Handled = true;
                }
            }
            else
                e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text == "-")
                textBox1.Text = "0";
            if (textBox1.Text.Length != 0 && textBox1.Text[0] == ',')
                textBox1.Text = "0" + textBox1.Text;
            if (cbtypefigure.SelectedIndex == 0)
            {
                if (cbfigure.SelectedIndex == 1)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) - 4);
                        textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) - 4);
                    }
                }
                else if (cbfigure.SelectedIndex == 2)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                        textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                    }
                }
            }
            else if (cbtypefigure.SelectedIndex == 1)
            {
                if (cbfigure.SelectedIndex == 0)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text));
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
                else if (cbfigure.SelectedIndex == 1)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text));
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
                else if (cbfigure.SelectedIndex == 2)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) + 4);
                        textBox6.Text = "" + (double.Parse(textBox1.Text));
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 8);
                        textBox8.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 4);
                    }
                }
                else if (cbfigure.SelectedIndex == 3)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 4);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text) + 1);
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox2.Text == "-")
                textBox2.Text = "0";
            if (textBox2.Text.Length != 0 && textBox2.Text[0] == ',')
                textBox2.Text = "0" + textBox2.Text;
                if (cbtypefigure.SelectedIndex == 0)
                {
                    if (cbfigure.SelectedIndex == 1)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                            textBox5.Text = "" + (double.Parse(textBox2.Text) - 4);
                            textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                            textBox7.Text = "" + (double.Parse(textBox2.Text) - 4);
                        }
                    }
                    else if (cbfigure.SelectedIndex == 2)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                            textBox5.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                            textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                            textBox7.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                        }
                    }
                }
                else if (cbtypefigure.SelectedIndex == 1)
                {
                    if (cbfigure.SelectedIndex == 0)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                            textBox5.Text = "" + (double.Parse(textBox2.Text));
                            textBox6.Text = "" + (double.Parse(textBox1.Text) + 3);
                            textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                            textBox8.Text = "" + (double.Parse(textBox1.Text));
                            textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                        }
                    }
                    else if (cbfigure.SelectedIndex == 1)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                            textBox5.Text = "" + (double.Parse(textBox2.Text));
                            textBox6.Text = "" + (double.Parse(textBox1.Text) + 5);
                            textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                            textBox8.Text = "" + (double.Parse(textBox1.Text));
                            textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                        }
                    }
                    else if (cbfigure.SelectedIndex == 2)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                            textBox5.Text = "" + (double.Parse(textBox2.Text) + 4);
                            textBox6.Text = "" + (double.Parse(textBox1.Text));
                            textBox7.Text = "" + (double.Parse(textBox2.Text) + 8);
                            textBox8.Text = "" + (double.Parse(textBox1.Text) - 3);
                            textBox9.Text = "" + (double.Parse(textBox2.Text) + 4);
                        }
                    }
                    else if (cbfigure.SelectedIndex == 3)
                    {
                        if (cbmethode.SelectedIndex == 2)
                        {
                            textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                            textBox5.Text = "" + (double.Parse(textBox2.Text));
                            textBox6.Text = "" + (double.Parse(textBox1.Text) + 4);
                            textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                            textBox8.Text = "" + (double.Parse(textBox1.Text) + 1);
                            textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                        }
                    }
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 0 || textBox9.Text == "-")
                textBox9.Text = "0";
            if (textBox9.Text.Length != 0 && textBox9.Text[0] == ',')
                textBox9.Text = "0" + textBox9.Text;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0 || textBox4.Text == "-")
                textBox4.Text = "0";
            if (textBox4.Text.Length != 0 && textBox4.Text[0] == ',')
                textBox4.Text = "0" + textBox4.Text;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (tbvar.Text.Length == 0)
                tbvar.Text = "0";
            if (tbvar.Text.Length != 0 && tbvar.Text[0] == ',')
                tbvar.Text = "0" + tbvar.Text;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 || textBox5.Text == "-")
                textBox5.Text = "0";
            if (textBox5.Text.Length != 0 && textBox5.Text[0] == ',')
                textBox5.Text = "0" + textBox5.Text;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 0 || textBox8.Text == "-")
                textBox8.Text = "0";
            if (textBox8.Text.Length != 0 && textBox8.Text[0] == ',')
                textBox8.Text = "0" + textBox8.Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0 || textBox7.Text == "-")
                textBox7.Text = "0";
            if (textBox7.Text.Length != 0 && textBox7.Text[0] == ',')
                textBox7.Text = "0" + textBox7.Text;
        }

        private void cbmethode_SelectedIndexChanged(object sender, EventArgs e)
        {
            btvalider.Enabled = true;
            gbinfo.Visible = false;
            label2.Text = "Abscisse";
            label3.Text = "Ordonnée";
            lbinfo.Text = "";
            reset();
            if (cbtypefigure.SelectedIndex==0)
            {
                if (cbfigure.SelectedIndex==0)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==3)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = false;
                    }
                }
                else if (cbfigure.SelectedIndex==1)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = false;
                        lbvar.Visible = true;
                        lbvar.Text = "Côté commun";
                        tbvar.Visible = true;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = false;
                    }
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = false;
                        lbvar.Visible = true;
                        lbvar.Text = "Côté";
                        tbvar.Visible = true;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = false;
                    }
                }
            }else if (cbtypefigure.SelectedIndex==1)
            {
                if (cbfigure.SelectedIndex==0)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = false;
                        lbvar.Visible = true;
                        lbvar.Text = "Côté";
                        tbvar.Visible = true;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                    }
                }
                else if (cbfigure.SelectedIndex==1)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        label2.Text = "Longueur";
                        label3.Text = "Largeur";
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                    }
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = false;
                        lbvar.Visible = true;
                        lbvar.Text = "Côté";
                        tbvar.Visible = true;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                    }
                }
                else if (cbfigure.SelectedIndex==3)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        gbinfo.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 1)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = false;
                        lbvar.Visible = true;
                        lbvar.Text = "Côté connu";
                        tbvar.Visible = true;
                        groupBox2.Visible = false;
                        groupBox3.Visible = false;
                        groupBox4.Visible = false;
                    }
                    else if (cbmethode.SelectedIndex == 2)
                    {
                        gbinfo.Visible = true;
                        groupBox1.Visible = true;
                        lbvar.Visible = false;
                        tbvar.Visible = false;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                    }
                }
            }
            else if (cbtypefigure.SelectedIndex==2)
            {
                if (cbmethode.SelectedIndex==0)
                {
                    gbinfo.Visible = true;
                    lbvar.Visible = false;
                    tbvar.Visible = false;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                }
                else if (cbmethode.SelectedIndex==1)
                {
                    gbinfo.Visible = true;
                    groupBox1.Visible = true;
                    lbvar.Visible = false;
                    tbvar.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                }
                else if (cbmethode.SelectedIndex==2)
                {
                    gbinfo.Visible = true;
                    groupBox1.Visible = false;
                    lbvar.Visible = true;
                    lbvar.Text = "Rayon";
                    tbvar.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                }
                else if (cbmethode.SelectedIndex==3)
                {
                    gbinfo.Visible = true;
                    groupBox1.Visible = true;
                    lbvar.Visible = true;
                    lbvar.Text = "Rayon";
                    tbvar.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox4.Visible = false;
                }
            }
            if (cbtypefigure.SelectedIndex == 0)
            {
                if (cbfigure.SelectedIndex == 1)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) - 4);
                        textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) - 4);
                    }
                }
                else if (cbfigure.SelectedIndex == 2)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                        textBox6.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) - 5.2);
                    }
                }
            }
            else if (cbtypefigure.SelectedIndex == 1)
            {
                if (cbfigure.SelectedIndex == 0)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text));
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
                else if (cbfigure.SelectedIndex == 1)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text));
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
                else if (cbfigure.SelectedIndex == 2)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 3);
                        textBox5.Text = "" + (double.Parse(textBox2.Text) + 4);
                        textBox6.Text = "" + (double.Parse(textBox1.Text));
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 8);
                        textBox8.Text = "" + (double.Parse(textBox1.Text) - 3);
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 4);
                    }
                }
                else if (cbfigure.SelectedIndex == 3)
                {
                    if (cbmethode.SelectedIndex == 2)
                    {
                        textBox4.Text = "" + (double.Parse(textBox1.Text) + 5);
                        textBox5.Text = "" + (double.Parse(textBox2.Text));
                        textBox6.Text = "" + (double.Parse(textBox1.Text) + 4);
                        textBox7.Text = "" + (double.Parse(textBox2.Text) + 3);
                        textBox8.Text = "" + (double.Parse(textBox1.Text) + 1);
                        textBox9.Text = "" + (double.Parse(textBox2.Text) + 3);
                    }
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Location = new System.Drawing.Point(this.Location.X + e.X - positionClick.X, this.Location.Y + e.Y - positionClick.Y);
        }

        private void btannuler_Click(object sender, EventArgs e)
        {
            cbtypefigure.SelectedIndex = -1;
            btannuler.Enabled = true;
            btvalider.Enabled = true;
            reset();
        }

        private void btvalider_Click(object sender, EventArgs e)
        {
            launch();
            if (cbtypefigure.SelectedIndex==0)
            {
                if (cbfigure.SelectedIndex==0)
                {
                    if (cbmethode.SelectedIndex == 0)
                    {
                        Triangle figure = new Triangle();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Triangle figure = new Triangle(A);
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Point B = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        Triangle figure = new Triangle(A, B);
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==3)
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Point B = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        Point C = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        Point[] param = new Point[3]; param[0] = A; param[1] = B; param[2] = C;
                        Triangle figure = new Triangle(param);
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        textBox1.Focus();
                        opere(figure.points);
                    }
                }
                else if (cbfigure.SelectedIndex==1)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Isocele figure = new Isocele();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        if (double.Parse(tbvar.Text)==0)
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Le côté ne doit pas être nul";
                            tbvar.Focus();
                        }
                        else
                        { 
                            Isocele figure = new Isocele(double.Parse(tbvar.Text));
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            groupBox1.Visible = true;
                            groupBox2.Visible = true;
                            groupBox3.Visible = true;
                            textBox1.Text = "" + figure.points[0].x;
                            textBox2.Text = "" + figure.points[0].y;
                            textBox4.Text = "" + figure.points[1].x;
                            textBox5.Text = "" + figure.points[1].y;
                            textBox6.Text = "" + figure.points[2].x;
                            textBox7.Text = "" + figure.points[2].y;
                            textBox1.Focus();
                            opere(figure.points);
                        }
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Point B = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        Point C = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        if ((A.x == B.x && A.y == B.y) || (A.x == C.x && A.y == C.y) || (B.x == C.x && B.y == C.y))
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Il n'y a pas de points confondus dans un triangle";
                            textBox1.Focus();
                        }
                        else if (A.Distance(B) != A.Distance(C) && B.Distance(A) != B.Distance(C) && C.Distance(B) != C.Distance(A))
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un triangle isocèle";
                            textBox1.Focus();
                        }
                        else
                        {
                             Point[] param = new Point[3]; param[0] = A; param[1] = B; param[2] = C;
                             Isocele figure = new Isocele(param);
                             lbinfo.ForeColor = Color.Blue;
                             lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                             textBox1.Focus();
                             opere(figure.points);
                        }
                    }
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Equilateral figure = new Equilateral();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        if (double.Parse(tbvar.Text)==0)
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Le côté ne peut être nul";
                            tbvar.Focus();
                        }
                        else
                        { 
                        Equilateral figure = new Equilateral(double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox1.Focus();
                        opere(figure.points);
                        }
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Point B = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        Point C = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        if ((A.x == B.x && A.y == B.y) || (A.x == C.x && A.y == C.y) || (B.x == C.x && B.y == C.y))
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Il n'y a pas de points confondus dans un triangle";
                            textBox1.Focus();
                        }
                        else if (A.Distance(B)!=A.Distance(C))
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un triangle équilatéral";
                            textBox1.Focus();
                        }
                        else
                        {
                             Point[] param = new Point[3]; param[0] = A; param[1] = B; param[2] = C;
                             Equilateral figure = new Equilateral(param);
                             lbinfo.ForeColor = Color.Blue;
                             lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                             textBox1.Focus();
                             opere(figure.points);
                        }
                    }
                }
            }
            else if (cbtypefigure.SelectedIndex==1)
            {
                if (cbfigure.SelectedIndex==0)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Carre figure = new Carre();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        if (double.Parse(tbvar.Text)==0)
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Le côté ne peut être nul";
                            tbvar.Focus();
                        }
                        else
                        { 
                        Carre figure = new Carre(double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                        }
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point[] param = new Point[4];
                        double[] coefdir = new double[4];
                        param[0] = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        param[1] = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        param[2] = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        param[3] = new Point(double.Parse(textBox8.Text), double.Parse(textBox9.Text));
                        for (int i = 0; i < 4; i++)
                        {
                            int s = i + 1;
                            if (s > 3)
                                s -= 4;
                            coefdir[i] = (param[s].y - param[i].y) / (param[s].x - param[i].x);
                        }
                        if ((coefdir[0] == coefdir[2] || coefdir[1] == coefdir[3]) && param[0].Distance(param[1]) == param[1].Distance(param[2]) && param[1].Distance(param[2]) == param[2].Distance(param[3]))
                        {
                            Carre figure = new Carre(param);
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            textBox1.Focus();
                            opere(figure.points);
                        }
                        else
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un carré";
                            textBox1.Focus();
                        }
                    }
                }
                else if (cbfigure.SelectedIndex==1)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Rectangle figure = new Rectangle();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        if (double.Parse(textBox1.Text)==0)
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "La longueur ne peut être nulle";
                            textBox1.Focus();
                        }
                        else if (double.Parse(textBox2.Text) == 0)
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "La largeur ne peut être nulle";
                            textBox2.Focus();
                        }
                        else
                        {
                            Rectangle figure = new Rectangle(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            groupBox1.Visible = true;
                            groupBox2.Visible = true;
                            groupBox3.Visible = true;
                            groupBox4.Visible = true;
                            textBox1.Text = "" + figure.points[0].x;
                            textBox2.Text = "" + figure.points[0].y;
                            textBox4.Text = "" + figure.points[1].x;
                            textBox5.Text = "" + figure.points[1].y;
                            textBox6.Text = "" + figure.points[2].x;
                            textBox7.Text = "" + figure.points[2].y;
                            textBox8.Text = "" + figure.points[3].x;
                            textBox9.Text = "" + figure.points[3].y;
                            textBox1.Focus();
                            opere(figure.points);
                        }
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point[] param = new Point[4];
                        double[] coefdir = new double[4];
                        param[0] = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        param[1] = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        param[2] = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        param[3] = new Point(double.Parse(textBox8.Text), double.Parse(textBox9.Text));
                        for (int i = 0; i < 4; i++)
                        {
                            int s = i + 1;
                            if (s > 3)
                                s -= 4;
                            coefdir[i] = (param[s].y - param[i].y) / (param[s].x - param[i].x);
                        }
                        if ((coefdir[0] == coefdir[2] || coefdir[1] == coefdir[3]) && param[0].Distance(param[1]) == param[2].Distance(param[3]) && param[1].Distance(param[2]) == param[3].Distance(param[0]))
                        {
                            Rectangle figure = new Rectangle(param);
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            textBox1.Focus();
                            opere(figure.points);
                        }
                        else
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un rectangle";
                            textBox1.Focus();
                        }
                    }
                }
                else if (cbfigure.SelectedIndex==2)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Losange figure = new Losange();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        Losange figure = new Losange(double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==2)
                    {
                        Point[] param = new Point[4];
                        double[] coefdir = new double[4];
                        param[0] = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        param[1] = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        param[2] = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        param[3] = new Point(double.Parse(textBox8.Text), double.Parse(textBox9.Text));
                        for (int i = 0; i < 4; i++)
                        {
                            int s = i + 1;
                            if (s > 3)
                                s -= 4;
                            coefdir[i] = (param[s].y - param[i].y) / (param[s].x - param[i].x);
                        }
                        if (param[0].Distance(param[1]) == param[1].Distance(param[2]) && coefdir[0] == coefdir[2] && coefdir[1] == coefdir[3])
                        {
                            Losange figure = new Losange(param);
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            textBox1.Focus();
                            opere(figure.points);
                        }
                        else
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un losange";
                            textBox1.Focus();
                        }
                    }
                }
                else if (cbfigure.SelectedIndex==3)
                {
                    if (cbmethode.SelectedIndex==0)
                    {
                        Trapeze figure = new Trapeze();
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex==1)
                    {
                        Trapeze figure = new Trapeze(double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        groupBox1.Visible = true;
                        groupBox2.Visible = true;
                        groupBox3.Visible = true;
                        groupBox4.Visible = true;
                        textBox1.Text = "" + figure.points[0].x;
                        textBox2.Text = "" + figure.points[0].y;
                        textBox4.Text = "" + figure.points[1].x;
                        textBox5.Text = "" + figure.points[1].y;
                        textBox6.Text = "" + figure.points[2].x;
                        textBox7.Text = "" + figure.points[2].y;
                        textBox8.Text = "" + figure.points[3].x;
                        textBox9.Text = "" + figure.points[3].y;
                        textBox1.Focus();
                        opere(figure.points);
                    }
                    else if (cbmethode.SelectedIndex == 2)
                    {
                        Point[] param = new Point[4];
                        double[] coefdir = new double[4];
                        param[0] = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        param[1] = new Point(double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                        param[2] = new Point(double.Parse(textBox6.Text), double.Parse(textBox7.Text));
                        param[3] = new Point(double.Parse(textBox8.Text), double.Parse(textBox9.Text));
                        for (int i = 0; i < 4; i++)
                        {
                            int s = i + 1;
                            if (s > 3)
                                s -= 4;
                            coefdir[i] = (param[s].y - param[i].y) / (param[s].x - param[i].x);
                        }
                        if ((coefdir[0] == coefdir[2] || coefdir[1] == coefdir[3]))
                        {
                            Trapeze figure = new Trapeze(param);
                            lbinfo.ForeColor = Color.Blue;
                            lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                            textBox1.Focus();
                            opere(figure.points);
                        }
                        else
                        {
                            lbinfo.ForeColor = Color.Red;
                            lbinfo.Text = "Vos points ne forment pas un trapeze";
                            textBox1.Focus();
                        }
                    }
                }
            }
            else if (cbtypefigure.SelectedIndex==2)
            {
                if (cbmethode.SelectedIndex==0)
                {
                    Cercle figure = new Cercle();
                    lbinfo.ForeColor = Color.Blue;
                    lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                    textBox1.Focus();
                    Point[] points=new Point[1];
                    points[0] = figure.centre;
                    tbvar.Text = "";
                    tbvar.Text = tbvar.Text+new Random().Next(1, 10);
                    groupBox1.Visible = true;
                    lbvar.Text = "Rayon";
                    lbvar.Visible = true;
                    tbvar.Visible = true;
                    tbvar.Text = "" + figure.rayon;
                    textBox1.Text = "" + figure.centre.x;
                    textBox2.Text = "" + figure.centre.y;
                    opere(points);
                }
                else if (cbmethode.SelectedIndex==1)
                {
                    Point A = new Point(double.Parse(textBox1.Text),double.Parse(textBox2.Text));
                    Cercle figure = new Cercle(A);
                    lbinfo.ForeColor = Color.Blue;
                    lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                    textBox1.Focus();
                    Point[] points = new Point[1];
                    points[0] = figure.centre;
                    tbvar.Text = "" + new Random().Next(1, 10);
                    groupBox1.Visible = true;
                    lbvar.Text = "Rayon";
                    lbvar.Visible = true;
                    tbvar.Visible = true;
                    textBox1.Text = "" + figure.centre.x;
                    textBox2.Text = "" + figure.centre.y;
                    opere(points);
                }
                else if (cbmethode.SelectedIndex==2)
                {
                    if (double.Parse(tbvar.Text) == 0)
                    {
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Le rayon ne peut être nul";
                        tbvar.Focus();
                    }
                    else
                    {
                        Cercle figure = new Cercle(double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        textBox1.Focus();
                        Point[] points = new Point[1];
                        points[0] = figure.centre;
                        groupBox1.Visible = true;
                        textBox1.Text = "" + figure.centre.x;
                        textBox2.Text = "" + figure.centre.y;
                        opere(points);
                    }
                }
                else if (cbmethode.SelectedIndex==3)
                {
                    if (double.Parse(tbvar.Text)==0)
                    {
                        lbinfo.ForeColor = Color.Red;
                        lbinfo.Text = "Le rayon ne peut être nul";
                        tbvar.Focus();
                    }
                    else
                    {
                        Point A = new Point(double.Parse(textBox1.Text), double.Parse(textBox2.Text));
                        Cercle figure = new Cercle(A, double.Parse(tbvar.Text));
                        lbinfo.ForeColor = Color.Blue;
                        lbinfo.Text = "Le périmètre est de " + Math.Round(figure.Perimetre(), 2) + " et l'aire est de " + Math.Round(figure.Aire(), 2);
                        textBox1.Focus();
                        Point[] points = new Point[1];
                        points[0] = figure.centre;
                        opere(points);
                    }
                }
            }
        }
        public void launch()
        {
            Graphics repere = panel2.CreateGraphics();
            repere.Clear(Color.White);
            Pen myGrayPen = new System.Drawing.Pen(System.Drawing.Color.Gray);
            repere.DrawLine(myGrayPen, new PointF(0, 290), new PointF(583, 290));
            repere.DrawLine(myGrayPen, new PointF(290, 0), new PointF(290, 583));
            for (int i=0;i<=583;i+=10)
            {
                repere.DrawLine(myGrayPen, new PointF(i, 291), new PointF(i, 289));
                repere.DrawLine(myGrayPen, new PointF(291, i), new PointF(289, i));
            }
            repere.Dispose();
            myGrayPen.Dispose();
        }
        public void reset()
        {
            Graphics repere = panel2.CreateGraphics();
            repere.Clear(Color.White);
            repere.Dispose();
        }
        public void opere(Point[] var)
        {
            Graphics repere = panel2.CreateGraphics();
            Pen myBluePen = new System.Drawing.Pen(System.Drawing.Color.Blue);
            if (cbtypefigure.SelectedIndex==0)
            {
                PointF[] param=new PointF[3];
                param[0].X=(float)(var[0].x*10+290);
                param[0].Y=(float)(290-var[0].y*10);
                param[1].X=(float)(var[1].x*10+290);
                param[1].Y=(float)(290-var[1].y*10);
                param[2].X=(float)(var[2].x*10+290);
                param[2].Y=(float)(290-var[2].y*10);
                repere.DrawPolygon(myBluePen,param);
            }
            else if (cbtypefigure.SelectedIndex==1)
            {
                PointF[] param = new PointF[4];
                param[0].X = (float)(var[0].x * 10 + 290);
                param[0].Y = (float)(290 - var[0].y * 10);
                param[1].X = (float)(var[1].x * 10 + 290);
                param[1].Y = (float)(290 - var[1].y * 10);
                param[2].X = (float)(var[2].x * 10 + 290);
                param[2].Y = (float)(290 - var[2].y * 10);
                param[3].X = (float)(var[3].x * 10 + 290);
                param[3].Y = (float)(290 - var[3].y * 10);
                repere.DrawPolygon(myBluePen, param);
            }
            else if (cbtypefigure.SelectedIndex==2)
            {
                PointF C = new PointF((float)((var[0].x-double.Parse(tbvar.Text))*10+290),(float)(290-(var[0].y+double.Parse(tbvar.Text))*10));
                repere.DrawEllipse(myBluePen, C.X, C.Y, float.Parse(tbvar.Text)*20, float.Parse(tbvar.Text)*20);
            }
            repere.Dispose();
            myBluePen.Dispose();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int a;
        }
    }
}
