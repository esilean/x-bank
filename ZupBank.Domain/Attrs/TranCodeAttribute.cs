using System;

namespace ZupBank.Domain.Attrs
{
    public class TranCodeAttribute : Attribute
    {
        public TranCodeAttribute(int spaceBefore, int spaceAfter)
        {
            SpaceBefore = spaceBefore;
            SpaceAfter = spaceAfter;
        }

        public int SpaceBefore { get; private set; }
        public int SpaceAfter { get; private set; }
    }
}
