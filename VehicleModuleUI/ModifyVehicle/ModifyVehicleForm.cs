using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using CoreLogic.Interfaces;
using FrameworkCommon;
using FrameworkCommon.MethodParameters;
using ProviderManager;
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
            IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
            var vehicles = vehicleOperations.GetVehicles();
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
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = vehicleOperations.GetVehicles();
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
            this.numericUpDownFuelConsumption.Value = selectedVehicleToModify.FuelConsumptionKmsPerLtr;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedVehicleToModify = this.comboBoxSelectVehicleToModify.SelectedItem as Vehicle;
                var newCapacity = (int) this.numericUpDownCapacity.Value;
                var newFuelConsumption = (int)this.numericUpDownFuelConsumption.Value;
                ModifyVehicleInput newVehicleValues = new ModifyVehicleInput
                {
                    Registration = selectedVehicleToModify.Registration,
                    NewCapacity = newCapacity,
                    FuelConsumptionKmsPerLtr = newFuelConsumption
                };

                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                vehicleOperations.ModifyVehicle(newVehicleValues);
                this.labelSuccess.Visible = true;
                this.labelSuccess.Text = "The vehicle was succesfully modified.";
                this.ClearForm();
                this.ReloadComboBoxSelectVehicleToModify();
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

        private void ReloadComboBoxSelectVehicleToModify()
        {
            this.comboBoxSelectVehicleToModify.Items.Clear();
            this.FillVehiclesComboBox();
        }

        private void ClearForm()
        {
            this.numericUpDownCapacity.Value = 0;
            this.numericUpDownFuelConsumption.Value = 0;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
