﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GalacticImperialism
{
    [Serializable] class Computer : Player
    {
        Random random = new Random();

        public Computer(int startingGold, Board b, Vector3 empireColor, Flag empireFlag) : base(startingGold, b, empireColor, empireFlag)
        {

        }

        public void OnTurn()
        {
            base.OnTurn();
            CheckTech();

            for (int i = 0; i <= 5; i++)
                MoveShips();

            NewUnits();
            Buildings();
            EndTurn();
        }

        private void CheckTech()
        {

        }

        private void MoveShips()
        {
            foreach (Planet p in ownedPlanets)
            {
                int numOfShips = random.Next(0, p.planetShips.Count + 1);
                List<Ship> selectedShips = new List<Ship>();
                for (int i = 0; i < numOfShips; i++)
                {
                    selectedShips.Add(p.planetShips[i]);
                }

                foreach (Ship ship in selectedShips)
                {
                    if (CanShipMove(ship))
                    {
                        List<Planet> planets = NearbyPlanets(p);
                        int planetSel = random.Next(0, planets.Count);

                        moveShip(ship, planets[planetSel], p);
                    }
                }
            }
        }

        private void NewUnits()
        {
        }

        private void Buildings()
        {
            foreach (Planet p in ownedPlanets)
            {
                int i = 0;

                if (random.Next(0, 3) == 0)
                {

                    foreach (BuildingSlot slot in p.buildingSlotsList)
                    {
                        foreach (BuildingQueued building in p.buildingQueue.queuedBuildings)
                        {
                            if (building.buildingSlotIndex == i)
                                continue;
                        }

                        if (slot.typeOfBuilding == BuildingSlot.BuildingType.Empty)
                        {
                            string[] types = { "ResearchFacility", "MilitaryBase", "Factory" };

                            int index = random.Next(0, 3);

                            p.buildingQueue.AddBuildingToQueue(types[index], i);
                            break;
                        }

                        i++;
                    }
                }
            }
        }

    }
}
