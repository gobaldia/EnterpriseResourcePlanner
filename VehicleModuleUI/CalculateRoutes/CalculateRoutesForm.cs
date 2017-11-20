using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic;
using CoreLogic.Interfaces;
using FrameworkCommon;
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

namespace VehicleModuleUI.CalculateRoutes
{
    public partial class CalculateRoutesForm : Form
    {
        public CalculateRoutesForm()
        {
            InitializeComponent();
            SetDefaultWindowsSize();
            FillListBoxVehiclesOrderedByEfficiency();
        }

        private void FillListBoxVehiclesOrderedByEfficiency()
        {
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = vehicleOperations.GetVehiclesOrderedByEfficiencyConsideringStudentsNumber();
                for (int index = 0; index < vehicles.Count; index++)
                {
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(vehicles[index].Item1);
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private void SetDefaultWindowsSize()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Size = new System.Drawing.Size(750, 550);
        }

        private void FillListBoxVehiclesOrderedByCapacity()
        {
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = vehicleOperations.GetVehiclesOrderedByCapacityConsideringStudentsNumber();
                for (int index = 0; index < vehicles.Count; index++)
                {
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(vehicles[index].Item1);
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private void listBoxVehiclesOrderedByCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle vehicle = this.listBoxVehiclesOrderedByEfficiency.SelectedItem as Vehicle;
            int position = this.listBoxVehiclesOrderedByEfficiency.SelectedIndex;
            if(position >= 0)
                this.FillListBoxStudentsInVehicle(vehicle, position);
        }

        private void FillListBoxStudentsInVehicle(Vehicle vehicle, int position)
        {
            this.listBoxStudentsInVehicle.Items.Clear();
            IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
            var vehicles = vehicleOperations.GetVehiclesOrderedByCapacityConsideringStudentsNumber();
            var students = vehicles[position].Item2;
            for (int index = 0; index < students.Count; index++)
            {
                this.listBoxStudentsInVehicle.Items.Add(students[index].GetFullNameAndLocation());
            }
        }

        private void buttonBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
