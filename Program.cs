using SQLQueryBuilderChallenge.QueryBuilder;

var events = new Table("Events", "e");

var eventId = events.Column("Id");
var eventName = events.Column("Name", "EventName");

Console.WriteLine($"Table: {events.Name}");
Console.WriteLine($"Table Alias: {events.Alias}");

Console.WriteLine($"Column: {eventId.Name}");
Console.WriteLine($"Column Alias: {eventName.Alias}");