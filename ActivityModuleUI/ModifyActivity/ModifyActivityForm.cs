using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using FrameworkCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivityModuleUI.ModifyActivity
{
    public partial class ModifyActivityForm : Form
    {
        public ModifyActivityForm()
        {
            InitializeComponent();
            FillActivitiesCombo();
        }

        private void FillActivitiesCombo()
        {
            var activities = ClassFactory.GetOrCreate<ActivityLogic>().GetActivities();
            for(int index = 0; index < activities.Count(); index++)
            {
                this.comboBoxSelectActivityToModify.Items.Add(activities[index]);
            }
            this.comboBoxSelectActivityToModify.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSelectActivityToModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ClearListBoxes();
            var combo = (ComboBox)sender;
            var selected = (Activity) combo.SelectedItem;
            this.textBoxActivityName.Text = selected.Name;
            this.dateTimePickerActivityDate.Value = selected.Date;
            this.numericUpDownActivityCost.Value = selected.Cost;
            FillAvailableStudentsListBox(selected.Id);
            FillRegisteredStudentsListBox(selected.Id);
            this.buttonModify.Enabled = true;
        }

        private void FillAvailableStudentsListBox(int activityId)
        {
            var allStudents = ClassFactory.GetOrCreate<StudentLogic>().GetStudents();
            var activityStudents = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activityId).Students;

            var availableStudents = allStudents.Except(activityStudents).ToList();

            for(int index = 0; index < availableStudents.Count(); index++)
            {
                this.listBoxAvailableStudents.Items.Add(availableStudents[index]);
            }
        }


        private void FillRegisteredStudentsListBox(int activityId)
        {
            var activityStudents = ClassFactory.GetOrCreate<ActivityLogic>().GetActivityById(activityId).Students;

            for(int index = 0; index < activityStudents.Count(); index++)
            {
                this.listBoxAlreadyRegisteredStudents.Items.Add(activityStudents[index]);
            }
        }

        private void ClearListBoxes()
        {
            this.listBoxAvailableStudents.Items.Clear();
            this.listBoxAlreadyRegisteredStudents.Items.Clear();
        }

        private void buttonAddStudentToActivity_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxAvailableStudents, this.listBoxAlreadyRegisteredStudents);
        }

        private void MoveFromOneListBoxToAnother(ListBox listBoxFrom, ListBox listBoxTo)
        {
            var selectedItemsToMove = listBoxFrom.SelectedItem;
            if (selectedItemsToMove != null)
            {
                listBoxTo.Items.Add(selectedItemsToMove);
                listBoxFrom.Items.Remove(selectedItemsToMove);
            }
        }

        private void buttonDeleteStudentFromActivity_Click(object sender, EventArgs e)
        {
            this.MoveFromOneListBoxToAnother(this.listBoxAlreadyRegisteredStudents, this.listBoxAvailableStudents);
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.labelError.Visible = false;
                var originalActivity = (Activity)this.comboBoxSelectActivityToModify.SelectedItem;
                var newActivityValues = originalActivity;
                newActivityValues.Name = this.textBoxActivityName.Text;
                newActivityValues.Date = this.dateTimePickerActivityDate.Value;
                newActivityValues.Cost = (int) this.numericUpDownActivityCost.Value;
                newActivityValues.Students = this.listBoxAlreadyRegisteredStudents.Items.Cast<Student>().ToList();
                ClassFactory.GetOrCreate<ActivityLogic>().ModifyActivityById(originalActivity.Id, newActivityValues);
            }
            catch (CoreException ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Visible = true;
                this.labelError.Text = ex.Message;
            }
            this.ReloadComboBoxSelectActivitiesToModify();
            this.CleanFields();
        }

        private void ReloadComboBoxSelectActivitiesToModify()
        {
            this.comboBoxSelectActivityToModify.Items.Clear();
            this.FillActivitiesCombo();
        }

        private void CleanFields()
        {
            this.textBoxActivityName.Text = string.Empty;
            this.numericUpDownActivityCost.Value = 0;
            this.ClearListBoxes();
        }
    }
}
