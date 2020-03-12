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
        public int gas = 0;
        public int maxGase = 500;
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
            pawnOnVehicle = 0; // оптимизированая проверка количеста людей в машине
            foreach(Pawn pawn in this.inventory.innerContainer)
            {
                if(pawn.IsColonist)
                {
                    istring +=  pawn.Name.ToString() + "\n";
                    pawnOnVehicle++;
                }
            }
            istring += "\0" + "\n" + $"Gas left: {this.gas}";
            return istring;
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            if (!this.Downed && !this.Dead)
            {
                if (pawnOnVehicle < 4)
                    yield return new FloatMenuOption("Seat on the car", delegate
                    {
                        Job job = new Job(JobDefOfLocal.SeatPawnToCar, this);
                        job.count = 1;
                        job.playerForced = true;
                        selPawn.jobs.TryTakeOrderedJob(job);
                    });
                if (gas < 500)
                    yield return new FloatMenuOption("Fill with gasoline", delegate
                    {
                        IEnumerable<Thing> GasOnMap = Map.listerThings.ThingsOfDef(ThingDef.Named("Chemfuel"));
                        Job job = new Job(JobDefOfLocal.FillTheCar, this, GasOnMap.RandomElement());
                        job.playerForced = true;
                        job.count = 1;
                        selPawn.jobs.TryTakeOrderedJob(job);
                    });
            }
            }




    }
}
