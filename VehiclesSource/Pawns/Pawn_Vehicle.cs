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
        public int maxPawnOnVehicle = 6;

        public int maxGase = 500;

        public bool battleVehicle = false;

        public List<Pawn> pawnsInVehicle = new List<Pawn>();

        public int gas = 0;

        private VehicleComponent gs;

        public VehicleComponent gamecomps
        {
            get
            {
                if (gs == null) gs = Current.Game.GetComponent<VehicleComponent>();
                return gs;
            }
        }
        
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            gamecomps.VehiclesOnMap.Add(this);
        }


        public void SeatToCar(Pawn pawn)
        {
            this.inventory.TryAddItemNotForSale(pawn.SplitOff(1));
            pawnsInVehicle.Add(pawn);
        }

        public void UnSeatToCar(Pawn pawn)
        {
            this.inventory.innerContainer.TryDrop(pawn,ThingPlaceMode.Near,out Thing thing);
            this.
            pawnsInVehicle.Remove(pawn);
        }


        public override string GetInspectString()
        {
            string istring = "";
            foreach (Pawn pawn in this.pawnsInVehicle)
            {
                if (pawn.IsColonist)
                {
                    istring += pawn.Name.ToString() + "\n";
                }
            }
            istring += "\0" + "\n" + $"Gas left: {this.gas} \\ {this.maxGase}";
            return istring;
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            if (!this.Downed && !this.Dead)
            {
                if (pawnsInVehicle.Count < 4)
                    yield return new FloatMenuOption("Seat in", delegate
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
                 FloatMenuOption auebutton = new FloatMenuOption("viad loh", delegate { });
                 auebutton.Disabled = true;
                 yield return auebutton;

            }
        }
        
           
                    
        
    }
}


