using SQLQueryBuilderChallenge.QueryBuilder;

var attendees = new Table("Attendees", "a");
var events = new Table("Events", "e");

var attendeeName = attendees.Column("Name");
var important = events.Column("Important");

var nameCondition = attendeeName.EqualsTo("Salah");
var importantCondition = important.EqualsTo(1);

var combinedCondition = nameCondition.Or(importantCondition);

Console.WriteLine($"{nameCondition.Column?.Name} {nameCondition.Operator} {nameCondition.Value}");
Console.WriteLine($"{importantCondition.Column?.Name} {importantCondition.Operator} {importantCondition.Value}");
Console.WriteLine($"Combined with: {combinedCondition.Connector}");