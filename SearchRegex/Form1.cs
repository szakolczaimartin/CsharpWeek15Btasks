using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchRegex
{
    public partial class matcherForm : Form
    {
        public matcherForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultListBox.Items.Clear();

            string field = fieldTextBox.Text;
            string regString = searchText.Text;

            Regex regex = new Regex(regString);
            MatchCollection match = regex.Matches(field);

            foreach (var item in match)
            {
                resultListBox.Items.Add(item);

            }

            resultListBox.Show();
        }

     
    }
}
