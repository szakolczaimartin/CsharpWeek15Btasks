using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SerializerPerson
{
    public partial class Form1 : Form
    {
        private int serial;
        

        public Form1()
        {
            InitializeComponent();
        }

        

        private void saveButton_Click(object sender, EventArgs e)
        {
            serial++;

            if (serial < 100)
            {

                Person person = new Person(nameTextBox.Text, addressTextbox.Text, phoneTextBox.Text);
                Serialize(person,new SoapFormatter(),"person"+ serial + ".dat" );
                
            }
            

        }


        private static Person Deserialize(IFormatter iFormatte , string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Person p = (Person)iFormatte.Deserialize(fileStream);
            fileStream.Close();
            return p;

        }

        private static void Serialize(Person person, IFormatter iFormatter , string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            iFormatter.Serialize(fileStream, person);
            fileStream.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path =
                "C:\\Users\\Szakolczai Martin\\Documents\\Visual Studio 2015\\Projects\\Week15B\\SerializerPerson\\bin\\Debug";
            string[] personEntries = Directory.GetFiles(path, "*.dat");

            if (personEntries[0].Length != 0)
            {
                Person person = Deserialize(new SoapFormatter(), personEntries[0]);

                nameTextBox.Text = person.Name;
                addressTextbox.Text = person.Address;
                phoneTextBox.Text = person.Phone;
            }
              
            
           

        }
    }
}
