namespace SQLQueryBuilderChallenge.QueryBuilder;

public class SelectQuery
{
    public Table FromTable { get; }

    public List<Column> Columns { get; } = new();

    public List<Join> Joins { get; } = new();

    public Condition? WhereCondition { get; private set; }

    public SelectQuery(Table fromTable)
    {
        FromTable = fromTable ?? throw new ArgumentNullException(nameof(fromTable));
    }

    public SelectQuery Select(params Column[] columns)
    {
        Columns.AddRange(columns);
        return this;
    }

    public SelectQuery InnerJoin(Table table, Column leftColumn, Column rightColumn)
    {
        Joins.Add(new Join("INNER JOIN", table, leftColumn, rightColumn));
        return this;
    }

    public SelectQuery LeftOuterJoin(Table table, Column leftColumn, Column rightColumn)
    {
        Joins.Add(new Join("LEFT OUTER JOIN", table, leftColumn, rightColumn));
        return this;
    }

    public SelectQuery Where(Condition condition)
    {
        WhereCondition = condition;
        return this;
    }

    public string ToSql()
    {
        var selectedColumns = Columns.Count == 0
            ? "*"
            : string.Join(", ", Columns.Select(FormatColumn));

        var sql = $"SELECT {selectedColumns} FROM {FormatTable(FromTable)}";

        foreach (var join in Joins)
        {
            sql += $" {join.Type} {FormatTable(join.Table)} ON {FormatColumnReference(join.LeftColumn)} = {FormatColumnReference(join.RightColumn)}";
        }

        if (WhereCondition != null)
        {
            sql += $" WHERE {FormatCondition(WhereCondition)}";
        }

        return sql;
    }

    private static string FormatTable(Table table)
    {
        return string.IsNullOrWhiteSpace(table.Alias)
            ? table.Name
            : $"{table.Name} AS {table.Alias}";
    }

    private static string FormatColumn(Column column)
    {
        var columnText = FormatColumnReference(column);

        return string.IsNullOrWhiteSpace(column.Alias)
            ? columnText
            : $"{columnText} AS {column.Alias}";
    }

    private static string FormatColumnReference(Column column)
    {
        var tableName = string.IsNullOrWhiteSpace(column.Table.Alias)
            ? column.Table.Name
            : column.Table.Alias;

        return $"{tableName}.{column.Name}";
    }

    private static string FormatCondition(Condition condition)
    {
        if (condition.Left != null && condition.Right != null && condition.Connector != null)
        {
            return $"({FormatCondition(condition.Left)} {condition.Connector} {FormatCondition(condition.Right)})";
        }

        return $"{FormatColumnReference(condition.Column!)} {condition.Operator} {FormatValue(condition.Value)}";
    }

    private static string FormatValue(object? value)
    {
        if (value is string text)
        {
            return $"'{text.Replace("'", "''")}'";
        }

        return value?.ToString() ?? "NULL";
    }
}