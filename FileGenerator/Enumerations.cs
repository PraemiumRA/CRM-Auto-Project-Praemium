namespace FileGenerator
{
    /// <summary>
    /// File count selection
    /// </summary>
    public enum FileCount : byte
    {
        Single = 0,
        Multiple = 1,
        Count = 2
    }

    /// <summary>
    /// File Type selection
    /// </summary>
    public enum FileType : byte
    {
        Csv = 0,
        Xml = 1,
        Random = 2,
        Count = 3
    }

    /// <summary>
    /// Data model fields
    /// </summary>
    public enum DataSource : byte
    {
        TeamID = 0,
        TeamName,
        MemberID,
        MemeberName,
        MemberSurname,
        ProjectID,
        ProjectName,
        ProjectCreateDate,
        ProjectDueDate,
        ProjectDescription,
        count = ProjectDescription + 1

    }

   
}