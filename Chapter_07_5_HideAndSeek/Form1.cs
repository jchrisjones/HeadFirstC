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
        int numberOfMoves;
        Location currentLocation;
        Room diningRoom, stairs;
        RoomWithDoor livingRoom, kitchen;
        RoomWithHidingPlace  upstairsHallway, masterBedroom, secondBedroom, bathroom;
        OutsideWithHidingPlace garden, driveway; 
        OutsideWithDoor frontYard, backYard;


        Opponent oppo;        
            
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room",
                    "antique carpet", "the closet", "oak door with a brass knob");    
            diningRoom = new Room("Dining Room", "crystal chandelier");
            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "the cabinet", "screen door");
            backYard = new OutsideWithDoor("Back Yard", true, "screen door");
            garden = new OutsideWithHidingPlace("Garden", false, "the shed");
            frontYard = new OutsideWithDoor("Front Yard", false, "oak door with a brass knob");
            stairs = new Room("Stairs", "bannister");
            upstairsHallway = new RoomWithHidingPlace("Upstairs Hallway", "picture of a dog", "the closet");
            masterBedroom = new RoomWithHidingPlace("Master Bedroom", "Large Bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("Second Bedroom", "Small Bed", "under the bed");
            bathroom = new RoomWithHidingPlace("Bathroom", "sink, toilet, and shower", "in the shower");
            driveway = new OutsideWithHidingPlace("Driveway", false, "the garage");

            livingRoom.Exits = new Location[] { frontYard, diningRoom, stairs };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            backYard.Exits = new Location[] { kitchen, garden, driveway };
            garden.Exits = new Location[] { backYard, frontYard };
            frontYard.Exits = new Location[] { garden, livingRoom, driveway };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };
            driveway.Exits = new Location[] { frontYard, backYard };


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
            numberOfMoves++;
            RedrawForm();
            CheckForDoor(newLocation);                   
        }

        private void SetTextBox(Location newLocation)
        {
            string discr = newLocation.Description + Environment.NewLine 
                + "\r\nNumber of moves made: " + numberOfMoves;
            if (newLocation is IHidingPlace)
                discr +=  "\r\nNumber of times this room has been checked: " + (newLocation as IHidingPlace).HidingPlaceChecked;
            description.Text = discr;
        }

        private void CheckForDoor(Location newLocation)
        {
            if (newLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void CheckForHidingPlace(Location newLocation)
        {
            if (newLocation is IHidingPlace)
            {
                check.Text = "Check " + (newLocation as IHidingPlace).HidingPlace;
                check.Visible = true;
            }
            else
                check.Visible = false;
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

        private void hide_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            oppo = new Opponent(frontYard);
            for (int i = 0; i < 10; i++)
            {
                oppo.Move();
                sb.Append((i+1).ToString());
                for (int j = 0; j < i + 1; j++)
                    sb.Append(".");
                sb.Append("\n\r");
                description.Text = sb.ToString();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                sb.Clear();
            }

            sb.Append("Ready or not, here I come!");
            description.Text = sb.ToString();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            goHere.Visible = true;
            exits.Visible = true;
            goThroughTheDoor.Visible = true;
            check.Visible = true;
            hide.Visible = false;
            MoveToANewLocation(diningRoom);
            numberOfMoves = 0;
            RedrawForm();
            Application.DoEvents();
            System.Threading.Thread.Sleep(2);

        }

        private void RedrawForm()
        {
            SetTextBox(currentLocation);
            CheckForHidingPlace(currentLocation);
        }

        private void ResetGame()
        {
            goHere.Visible = false;
            exits.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
            hide.Visible = true;

            description.Text = "You found me in the " + (currentLocation as IHidingPlace).HidingPlace 
                + " in the " + currentLocation.Name + "! It took you " + numberOfMoves + " moves.";            
        }

        private void check_Click(object sender, EventArgs e)
        {            
            (currentLocation as IHidingPlace).HidingPlaceChecked++;
            if (oppo.Check(currentLocation))
                ResetGame();
            else
                RedrawForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
