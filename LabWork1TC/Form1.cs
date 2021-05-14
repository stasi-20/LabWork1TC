using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LabWork1TC
{
    public partial class Form1 : Form
    {

        public static XmlDocument doc = new XmlDocument();
        public static XmlDocument doc1 = new XmlDocument();
       

        public Form1()
        {
            InitializeComponent();
            LoadXmlDocument();
      
            
        }
        
        public void LoadXmlDocument()
        {
            doc.Load("xmltest.xml");
         
            foreach (XmlNode node in doc.DocumentElement)
            {
                
                string name = node.Attributes[0].Value;
                string identifier = node["Identifier"].InnerText;
                string priority = node["Priority"].InnerText;
                string requirement = node["Requirement"].InnerText;
                string module = node["Module"].InnerText;
                string subModule = node["SubModule"].InnerText;
                string titleAndSteps = node["TitleAndSteps"].InnerText;
                string requiredStepresult = node["RequiredStepResult"].InnerText;
               

                listBox1.Items.Add(new XMLDocumentOne(name, identifier, priority, requirement, module,
                    subModule, titleAndSteps, requiredStepresult));

            }

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddForm addDlg = new AddForm();
            addDlg.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
