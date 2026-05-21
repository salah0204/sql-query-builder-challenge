using SQLQueryBuilderChallenge.QueryBuilder;

var events = new Table("Events", "e");
var attendees = new Table("Attendees", "a");
var eventAttendees = new Table("EventAttendees", "ea");

var eventId = events.Column("Id");
var eventName = events.Column("Name");
var attendeeId = attendees.Column("Id");
var attendeeName = attendees.Column("Name");
var eventAttendeeEventId = eventAttendees.Column("EventId");
var eventAttendeeAttendeeId = eventAttendees.Column("AttendeeId");

var query = new SelectQuery(events)
    .Select(eventName, attendeeName)
    .InnerJoin(eventAttendees, eventId, eventAttendeeEventId)
    .InnerJoin(attendees, eventAttendeeAttendeeId, attendeeId)
    .Where(attendeeName.EqualsTo("Salah"));

Console.WriteLine(query.ToSql());