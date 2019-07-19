using System;
using HistoryKit;
using XRL.UI;
using XRL.World.Parts.Effects;
using XRL.Core;

namespace XRL.World.Parts
{

    [Serializable]
    public class FrenziedFix : IPart
    {
        public GameObject FrenziedEntity;
        public int LastDuration;

        public override bool SameAs(IPart p)
        {
            if (!base.SameAs(p)) return false;
            return true;
        }

        public override void Register(GameObject Object)
        {
            Object.RegisterPartEvent(this, "ApplyFrenzied");
            Object.RegisterPartEvent(this, "EndTurn");
            FrenziedEntity = Object;
            base.Register(Object);
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "ApplyFrenzied"){
                this.LastDuration = -1;
            } else if (this.FrenziedEntity != null && this.FrenziedEntity.HasEffect("Frenzied"))
            {
                Frenzied effect = this.FrenziedEntity.GetEffect("Frenzied") as Frenzied;
                if (E.ID == "EndTurn" && effect.Duration > 0 && (this.LastDuration == -1 || effect.Duration == this.LastDuration))
                {
                    effect.Duration--;
                }
                this.LastDuration = effect.Duration;
            }

            return base.FireEvent(E);
        }

    }

}