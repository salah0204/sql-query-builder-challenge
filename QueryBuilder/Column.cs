namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Column
{
    public Table Table { get; }

    public string Name { get; }

    public string? Alias { get; }

    public Column(Table table, string name, string? alias = null)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Column name cannot be empty.", nameof(name));
        }

        Table = table;
        Name = name;
        Alias = alias;
    }
}