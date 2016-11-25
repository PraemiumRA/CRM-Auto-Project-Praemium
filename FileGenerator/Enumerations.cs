namespace FileGenerator
{
    /// <summary>
    /// Contains selection of File Type. 
    /// </summary>
    public enum FileType : byte
    {
        Csv = 0,
        Xml = 1,
        Count = 2
    }

    /// <summary>
    /// Contains data model fields.
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