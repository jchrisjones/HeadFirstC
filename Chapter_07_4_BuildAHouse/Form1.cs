using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_07_5_HideAndSeek
{
    public partial class Form1 : Form
    {
        Location currentLocation;
        Room diningRoom;
        RoomWithDoor livingRoom, kitchen;
        Outside garden;
        OutsideWithDoor frontYard, backYard;
            
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);

        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room",
                    "antique carpet", "oak door with a brass knob");    
            diningRoom = new Room("Dining Room", "crystal chandelier");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "screen door");
            backYard = new OutsideWithDoor("Back Yard", true, "screen door");
            garden = new Outside("Garden", false);
            frontYard = new OutsideWithDoor("Front Yard", false, "oak door with a brass knob");

            livingRoom.Exits = new Location[] { frontYard, diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            backYard.Exits = new Location[] { kitchen, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++ )
                exits.Items.Add(currentLocation.Exits[i].Name);
            exits.SelectedIndex = 0;
            SetTextBox(newLocation);
            CheckForDoor(newLocation);
        }

        private void SetTextBox(Location newLocation)
        {
            description.Text = newLocation.Description;
        }

        private void CheckForDoor(Location newLocation)
        {
            if (newLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }
    }
}
