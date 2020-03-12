using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;


namespace VehiclesSource.Buildings
{
    class Building_TestB : Building
    {

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            //base.SpawnSetup(map, respawningAfterLoad);
            PawnKindDef mytest = DefDatabase<PawnKindDef>.GetNamed("VehiclesTest");
            Pawn pawn;
            if (mytest != null)
            {
                pawn = PawnGenerator.GeneratePawn(mytest,this.Faction);
                GenPlace.TryPlaceThing(pawn, this.Position, map, ThingPlaceMode.Near, null);
                Log.Message("yayayayay!!");
            }
        }

    }
}