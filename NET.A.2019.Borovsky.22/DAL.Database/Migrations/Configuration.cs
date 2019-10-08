namespace DAL.Database.Migrations
{
    using DAL.Database.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountContext>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "DAL.Database.Context.AccountContext";
        }

        /// <summary>
        /// Method, which will be called after migrating to the latest version
        /// </summary>
        /// <param name="context">Context</param>
        protected override void Seed(AccountContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method
            // to avoid creating duplicate seed data.
        }
    }
}