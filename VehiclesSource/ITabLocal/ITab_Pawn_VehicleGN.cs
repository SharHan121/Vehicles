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
		private Pawns.Pawn_Vehicle PawnV => Current.Game.GetComponent<VehicleComponent>().GetVehicle(base.SelPawn);

		public ITab_Pawn_VehicleGN()
		{
			size = new Vector2(0f, 0f);
			labelKey = "TabVehicle";
			tutorTag = "Gear";
		}

		protected override void FillTab()
		{
			size = new Vector2(20f + PawnV.maxPawnOnVehicle * 84f, 320f);
			DrawPawnsCells();
		}

		private void DrawPawnsCells()
		{
			for (int i = 0; i < PawnV.maxPawnOnVehicle; i++)
			{
				Rect HumanlikeCell_Rect = new Rect(20f + i * 84f, 25f, 64f, 64f);
				GUI.DrawTexture(HumanlikeCell_Rect, ContentFinder<Texture2D>.Get("UI/Widgets/DesButBG"));
			}
			for (int i = 0; i < PawnV.pawnsInVehicle.Count; i++)
			{
				Rect Cell = new Rect(20f + i * 84f, 25f, 64f, 64f);
				GUI.DrawTexture(Cell, PortraitsCache.Get(PawnV.pawnsInVehicle.ElementAt(i),
					new Vector2(64f, 64f), default(Vector3), 1.13f));
			}
		}

	}
}
