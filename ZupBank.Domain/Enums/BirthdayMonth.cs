using System.Runtime.Serialization;

namespace ZupBank.Domain.Enums
{
    public enum BirthdayMonth
    {
        [EnumMember(Value = "JANEIRO")]
        J,
        [EnumMember(Value = "FEVEREIRO")]
        F,
        [EnumMember(Value = "MARCO")]
        M
    }
}
