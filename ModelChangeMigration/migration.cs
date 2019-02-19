//below is the property that was removed
public class TimeOffEvent:Event
    {
        [Key]
        /// <summary>
        /// ID for the event
        /// </summary>
        public Guid TimeOffEventID { get; set; }
        /// <summary>
        /// DateTime that displays date and time the time off event was requested.
        /// </summary>
        
        [DataType(DataType.Date)]
        [Display(Name = "Submitted")]
        public DateTime? Submitted { get; set; 

//adding migration generated several new files.  Below is one example.

namespace ScheduleUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeOffEventID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "TimeOffEventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TimeOffEventID", c => c.Guid());
        }
    }
}
