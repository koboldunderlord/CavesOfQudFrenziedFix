using System;
using XRL.World.Parts;

namespace XRL.World.Parts.Effects
{
    [Serializable]
    public class AddFrenziedFix : Effect
    {
        
        public AddFrenziedFix()
        {
        }

        public override bool SameAs(Effect e)
        {
            AddFrenziedFix addFrenziedFix = e as AddFrenziedFix;
            return base.SameAs(e);
        }

        public override string GetDetails()
        {
            return "Temporary effect to attach a FrenziedFix part.";
        }

        public override bool Apply(GameObject Object)
        {
            if (!Object.HasPart("FrenziedFix")) 
            {
                Object.AddPart<FrenziedFix>(new FrenziedFix(), true);
            }
            Object.RemoveEffect("AddFrenziedFix", false);
            return true;
        }
    }
}
