namespace Domain.Migrations
{
     using System.Data.Entity.Migrations;

     internal sealed class Configuration : DbMigrationsConfiguration<Domain.Concrete.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Domain.Concrete.ShopDBContext context)
        {

        }
    }
}
