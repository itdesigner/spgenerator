using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.SPGenerator
{
    public partial class frmTableSelector : Form
    {
        public List<AliasTable> Selected { get; set; }
        public List<string> Choices { get; set; }
        public frmTableSelector()
        {
            InitializeComponent();
        }
        public frmTableSelector(List<string> choices, List<AliasTable> selected)
        {
            InitializeComponent();
            Choices = choices;
            foreach (string s in choices)
            {
                lstAvailTables.Items.Add(s);
            }
            Selected = selected;
            foreach (AliasTable s in selected)
            {
                lstSelectedTables.Items.Add(s);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Selected.Clear();
            foreach (AliasTable s in lstSelectedTables.Items)
            {
                if (!Selected.Contains(s))
                {
                    Selected.Add(s);
                }
            }
            this.Hide();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailTables.SelectedItems != null)
            {
                foreach (var item in lstAvailTables.SelectedItems)
                {
                    // prompt user if they want to use an alias for this table
                    string alias = DS.UIControls.Boxes.InputPrompt.Show("Provide an Alias for this table '" + item + "'" + System.Environment.NewLine + "or leave blank for no Alias...", "Table Alias", null, FormStartPosition.CenterParent);
                    if (alias != null)
                    {
                        AliasTable at = new AliasTable(item.ToString(), alias);
                        bool found = false;
                        foreach (AliasTable itemsel in lstSelectedTables.Items)
                        {
                            if (itemsel.Equals(at) || (itemsel.Alias == at.Alias && !string.IsNullOrEmpty(at.Alias))) { found = true; break; }
                        }
                        if (!found)
                        {
                            lstSelectedTables.Items.Add(at);
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("A table with that alias has already been added." + System.Environment.NewLine + "Either choose a different table and alias or use a free alias.", "Alias or Table Already Used", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void cmdDeSelect_Click(object sender, EventArgs e)
        {
            if (lstSelectedTables.SelectedItems != null && lstSelectedTables.SelectedItems.Count>0)
            {
                for (int i = lstSelectedTables.SelectedItems.Count - 1; i >= 0;i-- )
                {
                    var item = lstSelectedTables.SelectedItems[i];
                    lstSelectedTables.Items.Remove(item);
                }
            }
        }
    }
}
