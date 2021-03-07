using System.Runtime.Serialization;

namespace ZupBank.Domain.Enums
{
    public enum Gender
    {
        [EnumMember(Value = "M")]
        Male,
        [EnumMember(Value = "F")]
        Female,
        [EnumMember(Value = "O")]
        Other
    }
}
