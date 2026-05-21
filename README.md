# SQL Query Builder Challenge

A lightweight SQL query builder written in C#

The project shows how SQL queries can be constructed programmatically using strongly-typed code objects rather than raw SQL strings

## Features

- SELECT queries
- Table and column aliases
- INNER JOIN support
- LEFT OUTER JOIN support
- WHERE clauses
- AND / OR condition handling
- SQL generation output
- Multiple query examples

## Running the project

Run the application using:

```bash
dotnet run
```

## Example Output

```sql
SELECT e.Name AS EventName, a.Name AS AttendeeName
FROM Events AS e
INNER JOIN EventAttendees AS ea ON e.Id = ea.EventId
INNER JOIN Attendees AS a ON ea.AttendeeId = a.Id
WHERE (a.Name = 'Salah' OR e.Important = 1)
```