namespace ReservationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Departure", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reservations", "ReservationNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "ReservationNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "Departure", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
