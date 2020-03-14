using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Verse;
using Verse.AI;
using Verse.Sound;


namespace VehiclesSource.ITabLocal
{
    class ITab_Pawn_VehicleGN : ITab
    {
		private Vector2 scrollPosition = Vector2.zero;

		private float scrollViewHeight;

		private const float TopPadding = 20f;

		public static readonly Color ThingLabelColor = new Color(0.9f, 0.9f, 0.9f, 1f);

		public static readonly Color HighlightColor = new Color(0.5f, 0.5f, 0.5f, 1f);

		private const float ThingIconSize = 28f;

		private const float ThingRowHeight = 28f;

		private const float ThingLeftX = 36f;

		private const float StandardLineHeight = 22f;

		private static List<Thing> workingInvList = new List<Thing>();

		public static Vector3 PawnTextureCameraOffset = new Vector3(0f, 0f, 0f);

		public ITab_Pawn_VehicleGN()
		{
			this.size = new Vector2(460f, 450f);
			this.labelKey = "TabVehicleGear";
			this.tutorTag = "VehicleGear";
		}


		private Pawn SelPawnForGear
		{
			get
			{
				if (base.SelPawn != null)
				{
					return base.SelPawn;
				}
				Corpse corpse = base.SelThing as Corpse;
				if (corpse != null)
				{
					return corpse.InnerPawn;
				}
				throw new InvalidOperationException("Gear tab on non-pawn non-corpse " + base.SelThing);
			}
		}

		private bool CanControl
		{
			get
			{
				Pawn selPawnForGear = SelPawnForGear;
				if (selPawnForGear.Downed)
					return false;

				if (selPawnForGear.Faction != Faction.OfPlayer)
					return false;

				if (selPawnForGear.Spawned)
					return false;

				//else

				return true;
			}
		}

		protected override void FillTab()
        {
			Text.Font = GameFont.Small;
			Rect rect = new Rect(0f, 20f, size.x, size.y - 20f).ContractedBy(10f);
			Rect position = new Rect(rect.x, rect.y, rect.width, rect.height);
			GUI.BeginGroup(position);
			throw new NotImplementedException();
        }
    }
}
