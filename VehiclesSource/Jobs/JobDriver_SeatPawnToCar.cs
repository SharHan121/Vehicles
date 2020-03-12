using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse.AI;

namespace VehiclesSource.Jobs
{
    class JobDriver_SeatPawnToCar : JobDriver
    {
        public VehiclesSource.Pawns.Pawn_Vehicle pawn_v => TargetA.Thing as VehiclesSource.Pawns.Pawn_Vehicle;

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            if (pawn_v.pawnOnVehicle < 4)
                return true;
            else
                return false;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.A);

            yield return Toils_General.Wait(200).WithProgressBarToilDelay(TargetIndex.A).FailOnDespawnedNullOrForbidden(TargetIndex.A);

            Toil seat = new Toil();
            seat.initAction = delegate
            {
                if (pawn_v != null)
                {
                    if (pawn_v.pawnOnVehicle < 4)
                    {
                        pawn_v.SeatToCar(this.pawn);
                    }
                }
            };

            seat.defaultCompleteMode = ToilCompleteMode.Instant;

            yield return seat;
        }
    
       
    }
}
