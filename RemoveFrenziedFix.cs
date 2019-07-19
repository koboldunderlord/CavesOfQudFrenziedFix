using System;
using XRL.World.Parts;
using XRL;
using XRL.World;

namespace XRL.World.Parts.Effects
{
    [Serializable]
    public class RemoveFrenziedFix : Effect
    {
        
        public RemoveFrenziedFix()
        {
        }

        public override bool SameAs(Effect e)
        {
            RemoveFrenziedFix addFrenziedFix = e as RemoveFrenziedFix;
            return base.SameAs(e);
        }

        public override string GetDetails()
        {
            return "Temporary effect to remove a FrenziedFix part.";
        }

        public override bool Apply(GameObject Object)
        {
            if (Object.HasPart("FrenziedFix")) 
            {
                Object.RemovePart("FrenziedFix");
            }
            Object.RemoveEffect("RemoveFrenziedFix", false);
            return true;
        }
    }
}
