using System.Collections.Generic;
using DataModelLibrary;

namespace BLL
{
    /// <summary>
    /// Contract, which is providing necessary functionality for handling entered data.
    /// </summary>
    public interface IStore
    {
        string path { get; set; }
        string jsonPath { get; set; }
        string fileName { get; set; }
        IEnumerable<DataModel> Read(); 
    }
}
