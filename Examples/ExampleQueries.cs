using SQLQueryBuilderChallenge.QueryBuilder;

namespace SQLQueryBuilderChallenge.Examples;

public static class ExampleQueries
{
    public static void SimpleQueryExample()
    {   

        // Create a table with an alias
        var users = new Table("Users", "u");

        var userId = users.Column("Id");
        var userName = users.Column("Name");

        // Build a simple SELECT query
        var query = new SelectQuery(users)
            .Select(userId, userName)
            .Where(userName.EqualsTo("Salah"));

        Console.WriteLine(query.ToSql());
    }

    public static void JoinQueryExample()
    {
        // Build the example from the challenge brief
        var events = new Table("Events", "e");
        var attendees = new Table("Attendees", "a");
        var eventAttendees = new Table("EventAttendees", "ea");

        var eventId = events.Column("Id");
        var eventName = events.Column("Name", "EventName");
        var important = events.Column("Important");

        var attendeeId = attendees.Column("Id");
        var attendeeName = attendees.Column("Name", "AttendeeName");

        var eventAttendeeEventId = eventAttendees.Column("EventId");
        var eventAttendeeAttendeeId = eventAttendees.Column("AttendeeId");

        var query = new SelectQuery(events)
            .Select(eventName, attendeeName)
            .InnerJoin(eventAttendees, eventId, eventAttendeeEventId)
            .InnerJoin(attendees, eventAttendeeAttendeeId, attendeeId)
            .Where(attendeeName.EqualsTo("Salah").Or(important.EqualsTo(1)));

        Console.WriteLine(query.ToSql());
    }

    public static void LeftOuterJoinExample()
    {
        var customers = new Table("Customers", "c");
        var orders = new Table("Orders", "o");

        var customerId = customers.Column("Id");
        var customerName = customers.Column("Name");

        var orderCustomerId = orders.Column("CustomerId");
        var orderId = orders.Column("Id");

        var query = new SelectQuery(customers)
            .Select(customerName, orderId)
            .LeftOuterJoin(orders, customerId, orderCustomerId);

        Console.WriteLine(query.ToSql());
    }
}

