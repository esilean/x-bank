using System.Linq;
using ZupBank.Domain.Attrs;

namespace ZupBank.Domain.Entities
{
    public class TranCodeAccess
    {
        [TranCode(3, 10)]
        public string User { get; private set; }

        [TranCode(10, 10)]
        public string Pass { get; private set; }

        [TranCode(1, 1)]
        public string Domain { get; private set; }

        public TranCodeAccess(string user, string pass, string domain)
        {
            User = user;
            Pass = pass;
            Domain = domain;
            AddSpace();
        }

        private void AddSpace()
        {
            var properties = typeof(TranCodeAccess)
              .GetProperties();

            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(false)
                    .ToDictionary(a => a.GetType().Name, a => a);

                var spaceBefore = ((TranCodeAttribute)(attrs["TranCodeAttribute"])).SpaceBefore;
                var spaceAfter = ((TranCodeAttribute)(attrs["TranCodeAttribute"])).SpaceAfter;

                switch (prop.Name)
                {
                    case nameof(User):
                        User = User.PadLeft(User.Length + spaceBefore).PadRight(User.Length + spaceBefore + spaceAfter);
                        break;
                    case nameof(Pass):
                        Pass = Pass.PadLeft(Pass.Length + spaceBefore).PadRight(Pass.Length + spaceBefore + spaceAfter);
                        break;
                    case nameof(Domain):
                        Domain = Domain.PadLeft(Domain.Length + spaceBefore).PadRight(Domain.Length + spaceBefore + spaceAfter);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
