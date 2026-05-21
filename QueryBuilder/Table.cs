namespace SQLQueryBuilderChallenge.QueryBuilder;

public class Table
{
    public string Name { get; }

    public Table(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Table name cannot be empty.", nameof(name));
        }

        Name = name;
    }

    public Column Column(string name)
{
    return new Column(this, name);
}

}