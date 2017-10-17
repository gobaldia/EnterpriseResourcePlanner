﻿using CoreEntities.Entities;
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

namespace VehicleModuleUI.CalculateRoutes
{
    public partial class CalculateRoutesForm : Form
    {
        public CalculateRoutesForm()
        {
            InitializeComponent();
            FillListBoxVehiclesOrderedByCapacity();
        }

        private void FillListBoxVehiclesOrderedByCapacity()
        {
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehiclesOrderedByCapacityConsideringStudentsNumber();
            for (int index = 0; index < vehicles.Count; index++)
            {
                this.listBoxVehiclesOrderedByCapacity.Items.Add(vehicles[index].Item1);
            }
        }

        private void listBoxVehiclesOrderedByCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle vehicle = this.listBoxVehiclesOrderedByCapacity.SelectedItem as Vehicle;
            int position = this.listBoxVehiclesOrderedByCapacity.SelectedIndex;
            this.FillListBoxStudentsInVehicle(vehicle, position);
        }

        private void FillListBoxStudentsInVehicle(Vehicle vehicle, int position)
        {
            this.listBoxStudentsInVehicle.Items.Clear();
            var vehicles = ClassFactory.GetOrCreate<VehicleLogic>().GetVehiclesOrderedByCapacityConsideringStudentsNumber();
            var students = vehicles[position].Item2;
            for (int index = 0; index < students.Count; index++)
            {
                this.listBoxStudentsInVehicle.Items.Add(students[index].GetFullNameAndLocation());
            }
        }
    }
}