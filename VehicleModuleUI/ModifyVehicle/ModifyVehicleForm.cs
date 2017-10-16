using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleModuleUI.ModifyVehicle
{
    public partial class ModifyVehicleForm : Form
    {
        public ModifyVehicleForm()
        {
            InitializeComponent();
            FillVehiclesComboBox();
        }

        private void CheckIfIsThereAnyVehicleInSystem()
        {
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();
            if (vehicles.Count() == 0)
            {
                this.labelError.Text = "Currently there is not any subject in the system.";
                this.labelError.Visible = true;
            }
        }

        private void FillVehiclesComboBox()
        {
            try
            {
                var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehicles();
                for (int index = 0; index < vehicles.Count; index++)
                {
                    this.comboBoxSelectVehicleToModify.Items.Add(vehicles[index]);
                }
                this.comboBoxSelectVehicleToModify.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private void comboBoxSelectVehicleToModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.labelError.Visible = false;
            this.labelSuccess.Visible = false;
            this.buttonModify.Enabled = true;
            var selectedVehicleToModify = this.comboBoxSelectVehicleToModify.SelectedItem as Vehicle;
            this.numericUpDownCapacity.Value = selectedVehicleToModify.Capacity;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedVehicleToModify = this.comboBoxSelectVehicleToModify.SelectedItem as Vehicle;
                var newCapacity = (int)this.numericUpDownCapacity.Value;
                ModifyVehicleInput newVehicleValues = new ModifyVehicleInput();
                newVehicleValues.Registration = selectedVehicleToModify.Registration;
                newVehicleValues.NewCapacity = newCapacity;
                ClassFactory.GetOrCreate<VehicleLogic>().ModifyVehicle(newVehicleValues);
                this.labelSuccess.Visible = true;
                this.labelSuccess.Text = "The vehicle was succesfully modified.";
            }
            catch (CoreException ex)
            {
                this.labelError.Visible = true;
                this.labelSuccess.Text = ex.Message;
            }
            catch (Exception ex)
            {
                this.labelError.Visible = true;
                this.labelSuccess.Text = ex.Message;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
