using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;

namespace VehiclesSource.Jobs
{
    class JobDriver_FillTheCar : JobDriver
    {
        public VehiclesSource.Pawns.Pawn_Vehicle pawn_v => TargetA.Thing as VehiclesSource.Pawns.Pawn_Vehicle;

        Thing thing => TargetB.Thing;

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return pawn.Reserve(TargetA, job);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            

            yield return Toils_Reserve.Reserve(TargetIndex.B);

            yield return Toils_Goto.GotoThing(TargetIndex.B,PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.B);

            yield return Toils_Haul.TakeToInventory(TargetIndex.B, 
                thing.stackCount < (pawn_v.maxGase - pawn_v.gas) ? thing.stackCount : pawn_v.maxGase - pawn_v.gas);
            
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.A);

            yield return Toils_General.Wait(700).WithProgressBarToilDelay(TargetIndex.A).FailOnDespawnedNullOrForbidden(TargetIndex.A);

            Toil finish = new Toil
            {
                initAction = delegate
                {
                    
                    if (pawn_v != null)
                    {
                        pawn_v.gas += pawn.inventory.innerContainer.Last().stackCount;
                        pawn.inventory.innerContainer.Remove(thing);
                    }
                },
                defaultCompleteMode = ToilCompleteMode.Instant
            };

            yield return finish;
        }
    }
}
