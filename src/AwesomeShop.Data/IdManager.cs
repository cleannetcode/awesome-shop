using System;

namespace AwesomeShop.Data
{
    public static class IdManager
    {
        public static Guid MemberRoleId => new("75ad3dca-3eda-4086-8672-992a26016a68");

        public static Guid AdminRoleId => new Guid("b4a87d46-f7bf-4339-8223-a3ce07ede3c1");
    }
}