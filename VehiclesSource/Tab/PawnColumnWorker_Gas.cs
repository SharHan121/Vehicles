using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;



namespace VehiclesSource.Tab
{

    class PawnColumnWorker_Gas : PawnColumnWorker_Text
    {
		protected override GameFont DefaultHeaderFont => GameFont.Tiny;

		public override int Compare(Pawn a, Pawn b)
		{
			return a.ageTracker.AgeBiologicalYears.CompareTo(b.ageTracker.AgeBiologicalYears);
		}

		protected override string GetTextFor(Pawn pawn)
		{
			return Current.Game.GetComponent<VehicleComponent>().GetVehicle(pawn).gas.ToString();
		}

	}
}
