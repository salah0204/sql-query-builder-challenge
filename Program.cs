using SQLQueryBuilderChallenge.QueryBuilder;

var events = new Table("Events");

var eventId = events.Column("Id");
var eventName = events.Column("Name");

Console.WriteLine(events.Name);
Console.WriteLine(eventId.Name);
Console.WriteLine(eventName.Name);