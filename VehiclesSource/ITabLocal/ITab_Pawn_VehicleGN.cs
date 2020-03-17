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

		private bool AdvancedMode = false;

		private Pawn localSelPawn;

		private Rect AdvancedMode_Rect;

		Color Whiteblue = new Color(0.45f, 1.0f, 0.9f,1f);



		private float WindowSizeY
		{
			get
			{
				return AdvancedMode ? 520f : 320f;
			}
		}

		private float ElementsY
		{
			get
			{
				return WindowSizeY - 320f;
			}
		}


		public ITab_Pawn_VehicleGN()
		{
			size = new Vector2(0f, 0f);
			labelKey = "TabVehicle";
			tutorTag = "Gear";
		}

		protected override void FillTab()
		{
			size = new Vector2(20f + PawnV.maxPawnOnVehicle * 84f, WindowSizeY);
			Text.Font = GameFont.Small;
			GUI.color = Color.white;
			DrawPawnsCells();
			if (this.AdvancedMode)
			DrawAdwanceMod();
		}

		protected override void CloseTab()
		{
			if (this.AdvancedMode)
				this.AdvancedMode = false;
			else
			    base.CloseTab();
		}

		private void DrawPawnsCells()
		{
			for (int i = 0; i < PawnV.maxPawnOnVehicle; i++)
			{
				Rect HumanlikeCell_Rect = new Rect(20f + i * 84f, ElementsY + 25f, 64f, 64f);
				GUI.DrawTexture(HumanlikeCell_Rect, ContentFinder<Texture2D>.Get("UI/Widgets/DesButBG"));
			}
			for (int i = 0; i < PawnV.pawnsInVehicle.Count; i++)
			{
				Rect Cell_Rect = new Rect(20f + i * 84f, ElementsY + 25f, 64f, 64f);
				Pawn pawn = PawnV.pawnsInVehicle.ElementAt(i);

				GUI.DrawTexture(Cell_Rect, PortraitsCache.Get(pawn,     // pawn
					new Vector2(64f, 64f), new Vector3(0f, 10f, 0f), 1.35f,true,false),
					ScaleMode.StretchToFill, true, 1f, 
					pawn == this.localSelPawn && this.AdvancedMode || Mouse.IsOver(Cell_Rect) ? Whiteblue : Color.white,
					0f, 0f);
				DrawCellRows(Cell_Rect, pawn);
			}
		}

		private void DrawCellRows(Rect rect,Pawn pawn)
		{
			if(pawn != null && Mouse.IsOver(rect))
			{
				//Rect DropCell_Rect = new Rect(rect.xMax - 20f, rect.yMax - 20.5f, 20f, 20f);
				Rect DropCell_Rect = new Rect(rect.xMax - 20f, rect.yMin + 0.5f, 20f, 20f);

				if (Widgets.ButtonImage(rect, null))
					if (localSelPawn != pawn || !this.AdvancedMode)
					{
						this.localSelPawn = pawn;
						this.AdvancedMode_Rect = new Rect(size.x, 200f, size.x, 200f);
						this.AdvancedMode = true;
					}
				    else
					{
						this.AdvancedMode = false;
					}

				if (Widgets.ButtonImage(DropCell_Rect, ContentFinder<Texture2D>.Get("UI/Buttons/Drop")))
				{
					PawnV.UnSeatToCar(pawn);
				}
			}
		}

		public void DrawAdwanceMod()
		{
			GUI.color = Color.gray;
			Widgets.DrawLineHorizontal(20f, AdvancedMode_Rect.y, AdvancedMode_Rect.x-40f);
			HealthCardUtility.DrawHediffListing(new Rect(20f, 30f, AdvancedMode_Rect.x-40f, AdvancedMode_Rect.y), localSelPawn, true);
		}
	}
}
