using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LabWork1TC
{
    public partial class AddForm : Form
    {
        XmlDocument doc = new XmlDocument();

        public AddForm(){
            InitializeComponent();
            LoadXMLDoc();
        }


        public void LoadXMLDoc()
        {
            //path of internal xml file place
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            doc.Load(path + @"\New XML document.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["Name"].InnerText;
                string identifier = node["Identifier"].InnerText;
                string priority = node["Priority"].InnerText;
                string requirement = node["Requirement"].InnerText;
                string module = node["Module"].InnerText;
                string submodule = node["Submodule"].InnerText;
                string titleAndSteps = node["TitleAndSteps"].InnerText;
                string requiredStepresult = node["RequiredStepResult"].InnerText;

                listBox1.Items.Add(new XMLDocumentOne(name, identifier, priority, requirement, module,
                    submodule, titleAndSteps, requiredStepresult));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }

        //save
        private void button1_Click(object sender, EventArgs e){

            string name1 = textBox1.Text;
            string identifier1 = textBox2.Text;
            string priority1 = textBox3.Text;
            string requirement1 = textBox4.Text;
            string module1 = textBox5.Text;
            string submodule1 = textBox6.Text;
            string titleAndSteps1 = textBox7.Text;
            string requiredStepResult1 = textBox8.Text;


            try
            {

                DataSet ds = new DataSet(); //Create a empty cache of table
                DataTable dt = new DataTable(); //Empty table 
                dt.TableName = "Autotest";
                dt.Columns.Add("Name");
                dt.Columns.Add("Identifier");
                dt.Columns.Add("Priority");
                dt.Columns.Add("Requirement");
                dt.Columns.Add("Module");
                dt.Columns.Add("Submodule");
                dt.Columns.Add("TitleAndSteps");
                dt.Columns.Add("RequiredStepResult");

                ds.Tables.Add(dt);

                DataRow row = ds.Tables["Autotest"].NewRow(); 
                row["Name"] = "Название кейса";
                row["Identifier"] = "Идентификатор";
                row["Priority"] = "Приоритет";
                row["Requirement"] = "Требование";
                row["Module"] = "Модуль";
                row["Submodule"] = "Подмодуль";
                row["TitleAndSteps"] = "Заглавие тест-кейса";
                row["RequiredStepResult"] = "Ожидаемый результат";
                ds.Tables["Autotest"].Rows.Add(row);

                DataRow row1 = ds.Tables["Autotest"].NewRow();

                row1["Name"] = name1;
                row1["Identifier"] = identifier1;
                row1["Priority"] = priority1;
                row1["Requirement"] = requirement1;
                row1["Module"] = module1;
                row1["Submodule"] = submodule1;
                row1["TitleAndSteps"] = titleAndSteps1;
                row1["RequiredStepResult"] = requiredStepResult1;
                ds.Tables["Autotest"].Rows.Add(row1);

                //Save a XML document into internal place of project
                String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                ds.WriteXml(path + @"\New XML document.xml");

                MessageBox.Show("File saved!", "Successful");

            }
            catch
            {
                MessageBox.Show("The document wasn't saved", "Save error");
            }
            
        }

  
        //save as
        private void button3_Click(object sender, EventArgs e)
        {
            string name1 = textBox1.Text;
            string identifier1 = textBox2.Text;
            string priority1 = textBox3.Text;
            string requirement1 = textBox4.Text;
            string module1 = textBox5.Text;
            string submodule1 = textBox6.Text;
            string titleAndSteps1 = textBox7.Text;
            string requiredStepResult1 = textBox8.Text;

            try
            {

                DataSet ds = new DataSet(); //Create a empty cache of table
                DataTable dt = new DataTable(); //Empty table 
                dt.TableName = "Autotest";
                dt.Columns.Add("Name");
                dt.Columns.Add("Identifier");
                dt.Columns.Add("Priority");
                dt.Columns.Add("Requirement");
                dt.Columns.Add("Module");
                dt.Columns.Add("Submodule");
                dt.Columns.Add("TitleAndSteps");
                dt.Columns.Add("RequiredStepResult");

                ds.Tables.Add(dt);

                //Title row
                DataRow row = ds.Tables["Autotest"].NewRow();
                row["Name"] = "Название кейса";
                row["Identifier"] = "Идентификатор";
                row["Priority"] = "Приоритет";
                row["Requirement"] = "Требование";
                row["Module"] = "Модуль";
                row["Submodule"] = "Подмодуль";
                row["TitleAndSteps"] = "Заглавие тест-кейса";
                row["RequiredStepResult"] = "Ожидаемый результат";
                ds.Tables["Autotest"].Rows.Add(row);

                //Row of typed values
                DataRow row1 = ds.Tables["Autotest"].NewRow();
                row1["Name"] = name1;
                row1["Identifier"] = identifier1;
                row1["Priority"] = priority1;
                row1["Requirement"] = requirement1;
                row1["Module"] = module1;
                row1["Submodule"] = submodule1;
                row1["TitleAndSteps"] = titleAndSteps1;
                row1["RequiredStepResult"] = requiredStepResult1;
                ds.Tables["Autotest"].Rows.Add(row1);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.WriteXml(saveFileDialog.FileName);
                }

                MessageBox.Show("File saved!", "Successful");
            }
            catch
            {
                MessageBox.Show("The document wasn't saved!", "Save error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
