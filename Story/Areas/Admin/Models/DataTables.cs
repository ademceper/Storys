namespace Story.Areas.Admin.Models;

public class DataTableColumn
{
    public string Data { get; set; }
    public string Name { get; set; }
    public bool Searchable { get; set; }
    public bool Orderable { get; set; }
    public DataTableSearch Search { get; set; }
}

public enum DataTableOrderDir
{
    ASC,
    DESC
}

public class DataTableOrder
{
    public int Column { get; set; }

    public DataTableOrderDir Dir { get; set; }
}
public class DataTableParameters
{
    public int Draw { get; set; }
    public DataTableColumn[]? Columns { get; set; }
    public DataTableOrder[]? Order { get; set; }
    public int Start { get; set; }
    public int Length { get; set; }
    public DataTableSearch? Search { get; set; }
    public int? ParentId { get; set; }

    public string? SortOrder
    {
        get
        {
            return Columns != null && Order != null && Order.Length > 0
                ? (Columns[Order[0].Column].Data + (Order[0].Dir == DataTableOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                : null;
        }
    }
}
public class DataTableResult
{
    public int draw { get; set; }
    public int recordsTotal { get; set; }
    public int recordsFiltered { get; set; }
    public IEnumerable<dynamic>? data { get; set; }
}
public abstract class DataTableRow
{
    public virtual string? DT_RowId => null;
    public virtual string? DT_RowClass => null;
    public virtual object? DT_RowData => null;
}
public class DataTableSearch
{
    public string? Value { get; set; }
    public bool Regex { get; set; }
}
