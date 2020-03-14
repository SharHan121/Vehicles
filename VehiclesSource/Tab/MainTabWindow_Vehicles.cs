using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace VehiclesSource.Tab
{
    class MainTabWindow_Vehicles : MainTabWindow_PawnTable
    {
		protected override PawnTableDef PawnTableDef => PawnTableDefOfLoacl.Vehicles;

		protected override IEnumerable<Pawn> Pawns => from p in Find.CurrentMap.mapPawns.PawnsInFaction(Faction.OfPlayer)
													  where string.Equals(p.def.defName,"VehiclesTest")
													  select p;

		public override void PostOpen()
		{
			base.PostOpen();
			Find.World.renderer.wantedMode = WorldRenderMode.None;
		}
	}
}
