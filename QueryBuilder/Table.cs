namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Table
{
    public string Name { get; }

    public string? Alias { get; }

    public Table(string name, string? alias = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Table name cannot be empty.", nameof(name));
        }

        Name = name;
        Alias = alias;
    }

    public Column Column(string name, string? alias = null)
    {
        return new Column(this, name, alias);
    }
}