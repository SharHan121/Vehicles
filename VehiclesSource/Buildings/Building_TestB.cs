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

        public override void Tick()
        {
            base.Tick();
        }

        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            yield return new FloatMenuOption("LALALALALALLALAL", delegate
            {
                Log.Message(selPawn.Name.ToString());
                Current.Game.GetComponent<GameComps>().spawn = selPawn;
                selPawn.DeSpawn();
                
            });
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
            {
                yield return gizmo;
            }
            Command_Action command_Action = new Command_Action();
            command_Action.defaultLabel = "Backup";
            command_Action.defaultDesc = "Backup your colonist";
            command_Action.action = delegate
            {
                
                Current.Game.GetComponent<GameComps>().spawn.SpawnSetup(this.Map,true);
                

            };
            yield return command_Action;
        }
    }
}