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
            int code;
            string name;
            Subject subject = new Subject();
            if (int.TryParse(this.textBoxSubjectCode.Text, out code))
            {
                name = this.textBoxSubjectName.Text;
                subject.Code = code;
                subject.Name = name;

                var systemDataInstance = SystemData.GetInstance.GetSystemSubjects();
                systemDataInstance.Add(subject);

            }
            else
            {
                // buscar excepcion
            }
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
