﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace VehiclesSource
{
    class VehicleComponent : GameComponent
    {
        public List<Pawns.Pawn_Vehicle> VehiclesOnMap = new List<Pawns.Pawn_Vehicle>();

        public bool isVehicle(Pawn pawn)
        {
            foreach (Pawns.Pawn_Vehicle pv in Current.Game.GetComponent<VehicleComponent>().VehiclesOnMap)
            {
                if (string.Equals(pawn.ThingID, pv.ThingID))
                    return true;
            }
            return false;
        }

        public Pawns.Pawn_Vehicle GetVehicle(Pawn pawn)
        {
            return pawn as Pawns.Pawn_Vehicle;
        }

        public VehicleComponent()
        {
            
        }
        public VehicleComponent(Game game)
        {
            
        }

    }

    }

