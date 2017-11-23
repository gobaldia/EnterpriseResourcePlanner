using CoreEntities.Entities;
using CoreEntities.Exceptions;
using CoreLogic.Interfaces;
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
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(vehicles[index]);
                    this.listBoxVehiclesOrderedByEfficiency.DisplayMember = "Item1";
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
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(vehicles[index]);
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
            int position = this.listBoxVehiclesOrderedByEfficiency.SelectedIndex;
            if(position >= 0)
                this.FillListBoxStudentsInVehicle(position);
        }

        private void FillListBoxStudentsInVehicle(int position)
        {
            this.listBoxStudentsInVehicle.Items.Clear();
            var vehicles = this.listBoxVehiclesOrderedByEfficiency.Items.Cast<Tuple<Vehicle, List<Student>>>().ToList();
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

        private void buttonOrderByDistanceDesc_Click(object sender, EventArgs e)
        {
            this.orderByDistance("DESC");
        }

        private void buttonOrderByDistanceAsc_Click(object sender, EventArgs e)
        {
            this.orderByDistance("ASC");
        }

        private void orderByDistance(string direction)
        {
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = this.listBoxVehiclesOrderedByEfficiency.Items.Cast<Tuple<Vehicle, List<Student>>>().ToList();

                var orderedVehicles = new List<Tuple<Vehicle, List<Student>>>();

                if (direction.Equals("ASC"))
                    orderedVehicles = vehicles.OrderBy(v => vehicleOperations.CalculateDistanceToCoverByVehicle(v)).ToList();
                else
                    orderedVehicles = vehicles.OrderByDescending(v => vehicleOperations.CalculateDistanceToCoverByVehicle(v)).ToList();

                this.listBoxVehiclesOrderedByEfficiency.Items.Clear();
                for (int index = 0; index < orderedVehicles.Count; index++)
                {
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(orderedVehicles[index]);
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private void buttonOrderByNumberOfTripsDesc_Click(object sender, EventArgs e)
        {
            this.OrderByNumberOfTrips("DESC");
        }

        private void buttonOrderByNumberOfTripsAsc_Click(object sender, EventArgs e)
        {
            this.OrderByNumberOfTrips("ASC");
        }

        private void OrderByNumberOfTrips(string direction)
        {
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                var vehicles = this.listBoxVehiclesOrderedByEfficiency.Items.Cast<Tuple<Vehicle, List<Student>>>().ToList();

                var orderedVehicles = new List<Tuple<Vehicle, List<Student>>>();

                if (direction.Equals("ASC"))
                    orderedVehicles = vehicles.OrderBy(v => this.occurrences(v, vehicles)).ToList();
                else
                    orderedVehicles = vehicles.OrderByDescending(v => this.occurrences(v, vehicles)).ToList();

                this.listBoxVehiclesOrderedByEfficiency.Items.Clear();
                for (int index = 0; index < orderedVehicles.Count; index++)
                {
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(orderedVehicles[index]);
                }
            }
            catch (CoreException ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelError.Text = ex.Message;
                this.labelError.Visible = true;
            }
        }

        private int occurrences(Tuple<Vehicle, List<Student>> vehicle, List<Tuple<Vehicle, List<Student>>> vehicles)
        {
            var occurrences = 0;
            foreach (var v in vehicles)
            {
                if (v.Item1.Equals(vehicle.Item1))
                    occurrences++;
            }
            return occurrences;
        }
    }
}
