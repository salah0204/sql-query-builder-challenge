namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Join
{
    public string Type { get; }

    public Table Table { get; }

    public Column LeftColumn { get; }

    public Column RightColumn { get; }

    public Join(string type, Table table, Column leftColumn, Column rightColumn)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Join type cannot be empty.", nameof(type));
        }

        Table = table ?? throw new ArgumentNullException(nameof(table));
        LeftColumn = leftColumn ?? throw new ArgumentNullException(nameof(leftColumn));
        RightColumn = rightColumn ?? throw new ArgumentNullException(nameof(rightColumn));
        Type = type;
    }
}