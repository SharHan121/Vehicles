using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace VehiclesSource.Pawns
{
    class Pawn_Vehicle : Pawn
    {
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            Log.Message("I A'LIVE");
            base.SpawnSetup(map, respawningAfterLoad);
        }
    }
}
