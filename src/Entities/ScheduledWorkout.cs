using System;
using System.Text.Json.Serialization;
using Ical.Net.DataTypes;

namespace WorkoutHub.Models;

public class ScheduledWorkout
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public required string WorkoutId {get; set;}
    [JsonIgnore]
    public Workout Workout { get; set; } = null!;
    public required RecurrencePattern RecurrenceRule { get; set; } // RRULE format
}
// Reoccurence Rule Examples:
// "FREQ=DAILY" - Every day
// "FREQ=WEEKLY;BYDAY=MO,WE,FR" - Mon/Wed/Fri
// "FREQ=WEEKLY;INTERVAL=2;BYDAY=MO" - Every other Monday
// "FREQ=MONTHLY;BYMONTHDAY=1,15" - 1st and 15th of month