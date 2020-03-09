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
            base.SpawnSetup(map, respawningAfterLoad);
            Log.Message("spawnrd!");
            foreach (var pawnf in map.mapPawns.FreeColonists)
            {
                Log.Message(pawnf.Name.ToString());
            }
        }
        public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
        {
            yield return new FloatMenuOption("Label", delegate
            {
                Log.Message(selPawn.Name.ToString());
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
                Log.Message("backup!!");
            };
            yield return command_Action;
        }
    }
}