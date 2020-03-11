using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace VehiclesSource
{
    class GameComps : GameComponent
    {
        public Thing spawn;
        public GameComps()
        {
            
        }
        public GameComps(Game game)
        {
            
        }
        public override void ExposeData()
        {
            Scribe_Values.Look(ref spawn, "savedpawn");
        }
    }
}
