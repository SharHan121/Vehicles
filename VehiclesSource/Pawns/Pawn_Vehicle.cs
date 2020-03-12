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
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);

            
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            yield return new FloatMenuOption("LALALALALALLALAL", delegate
            {
                Log.Message(selPawn.Name.ToString());
                this.inventory.TryAddItemNotForSale(selPawn.SplitOff(1));
            });
        }


    }
}
