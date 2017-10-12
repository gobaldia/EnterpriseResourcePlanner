using BusinessLogic.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubjectModuleUI
{
    public partial class AddSubjectForm : Form
    {
        public AddSubjectForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            int code;
            string name;
            Subject subject = new Subject();
            if (int.TryParse(this.textBoxSubjectCode.Text, out code))
            {
                if (!string.IsNullOrWhiteSpace(this.textBoxSubjectName.Text))
                {
                    subject.Code = code;
                    name = this.textBoxSubjectName.Text;
                    subject.Name = name;

                    var systemDataInstance = SystemData.GetInstance;
                    systemDataInstance.AddSubject(subject);

                    this.ClearAddSubjectForm();
                    this.ShowCorrectlyAddedSubjectMessage(code, name);
                }
                else
                {
                    this.labelError.Visible = true;
                    this.labelError.Text = "Subject's name must be a not empty string";
                }
            }
            else
            {
                this.labelError.Visible = true;
                this.labelError.Text = "Subject's code must be a number";
            }
        }

        private void ClearAddSubjectForm()
        {
            this.textBoxSubjectCode.Clear();
            this.textBoxSubjectName.Clear();
        }

        private void ShowCorrectlyAddedSubjectMessage(int code, string name)
        {
            labelOk.Visible = true;
            this.labelOk.Text = "Subject " + name + " with code " + code + " was correctly added";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        //private void buttonAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        AgregarASistema();
        //    }
        //    catch (Exception ex)
        //    {
        //        this.labelError.Visible = true;
        //        this.labelError.Text = ex.Message;
        //    }
        //    var code = textBoxSubjectCode.Text;

        //}


        //private void AgregarASistema()
        //{
        //    if(Valida())
        //    {
        //        haceLaMagia();
        //    }

        //}

        //private bool Valida()
        //{
        //    if(estaEnSistema)
        //    {
        //        throw new Exception("Ya exista");
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
