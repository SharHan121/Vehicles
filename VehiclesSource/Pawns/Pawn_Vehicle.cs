using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Verse.AI;

namespace VehiclesSource.Pawns
{
    class Pawn_Vehicle : Pawn, IAttackTarget, IThingHolder
    {
        public int pawnOnVehicle = 0;
        public int barel = 0;

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
        }

        public void SeatToCar(Pawn pawn)
        {
            this.inventory.TryAddItemNotForSale(pawn.SplitOff(1));
            pawnOnVehicle++;
        }

        public override string GetInspectString()
        {
            string istring = "";
            foreach(Pawn pawn in this.inventory.innerContainer)
            {
                if(pawn.IsColonist)
                {
                    istring += pawn.Name.ToString() + "\n";
                }
            }
            return istring != "" ? istring : "Nothing";
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            if (pawnOnVehicle < 4 && !this.Downed) 
            yield return new FloatMenuOption("Seat on the car", delegate
            {
                Job job = new Job(JobDefOfLocal.SeatPawnToCar, this);
                job.count = 1;
                job.playerForced = true;
                selPawn.jobs.TryTakeOrderedJob(job);
            });
        }



    }
}
