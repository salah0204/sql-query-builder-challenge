namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Column
{
    public Table Table { get; }

    public string Name { get; }

    public Column(Table table, string name)
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
    }
}