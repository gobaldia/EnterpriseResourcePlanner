﻿using CoreEntities.Entities;
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
                    this.listBoxVehiclesOrderedByEfficiency.Items.Add(vehicles[index]);
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
            //Vehicle vehicle = this.listBoxVehiclesOrderedByEfficiency.SelectedItem as Vehicle;
            int position = this.listBoxVehiclesOrderedByEfficiency.SelectedIndex;
            if(position >= 0)
                this.FillListBoxStudentsInVehicle(position);
        }

        private void FillListBoxStudentsInVehicle(int position)
        {
            this.listBoxStudentsInVehicle.Items.Clear();
            //IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
            //var vehicles = vehicleOperations.GetVehiclesOrderedByCapacityConsideringStudentsNumber();
            //var students = vehicles[position].Item2;
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
            try
            {
                IVehicleLogic vehicleOperations = Provider.GetInstance.GetVehicleOperations();
                //var vehicles = vehicleOperations.GetVehiclesOrderedByEfficiencyConsideringStudentsNumber();
                var vehicles = this.listBoxVehiclesOrderedByEfficiency.Items.Cast<Tuple<Vehicle, List<Student>>>().ToList();
                var orderedVehicles = vehicles.OrderByDescending(v => this.CalculateDistanceToCoverByVehicle(v)).ToList();
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
        }

        private double CalculateDistanceToCoverByVehicle(Tuple<Vehicle, List<Student>> vehiclesWithStudents)
        {
            var students = vehiclesWithStudents.Item2;
            var school = new Student();
            school.SetLocation(new Location());
            students.Insert(0, school);
            students.Add(school);
            var distance = 0.0;
            for (int index = 1; index < students.Count(); index ++)
            {
                var studentLocation = students[index].Location;
                distance += Distance(students[index].Location, students[index - 1].Location);
            }
            students.RemoveAll(s => s.Location.Equals(new Location()));
            return distance;
        }

        private double Distance(Location from, Location to)
        {
            return Math.Sqrt(Math.Pow(from.Latitud - to.Latitud, 2) + Math.Pow(from.Longitud - to.Longitud, 2));
        }
    }
}
