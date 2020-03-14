using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;

namespace VehiclesSource
{
	[DefOf]
	class PawnTableDefOfLoacl
    {
		static PawnTableDefOfLoacl()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(PawnTableDefOfLoacl));
		}

		public static PawnTableDef Vehicles;

	}
}
