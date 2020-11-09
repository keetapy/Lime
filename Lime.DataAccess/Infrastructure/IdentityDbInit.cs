using System.Data.Entity;

namespace Lime.DataAccess.Infrastructure
{
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<UsersDBContext>
    {
        protected override void Seed(UsersDBContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(UsersDBContext context)
        {
            // настройки конфигурации контекста будут указываться здесь
        }
    }
}