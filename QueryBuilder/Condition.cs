namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Condition
{
    public Column? Column { get; }

    public string Operator { get; }

    public object? Value { get; }

    public Condition? Left { get; }

    public Condition? Right { get; }

    public string? Connector { get; }

    public Condition(Column column, string @operator, object value)
    {
        if (column == null)
        {
            throw new ArgumentNullException(nameof(column));
        }

        if (string.IsNullOrWhiteSpace(@operator))
        {
            throw new ArgumentException("Operator cannot be empty.", nameof(@operator));
        }

        Column = column;
        Operator = @operator;
        Value = value;
    }

    private Condition(Condition left, string connector, Condition right)
    {
        Left = left;
        Connector = connector;
        Right = right;
        Operator = string.Empty;
    }

    public Condition And(Condition other)
    {
        return new Condition(this, "AND", other);
    }

    public Condition Or(Condition other)
    {
        return new Condition(this, "OR", other);
    }
}