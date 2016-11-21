using System.Collections.Generic;
using DataModelLibrary;

namespace BLL
{
    public interface IStore
    {
        string path { get; set; }
        string jsonPath { get; set; }
        string fileName { get; set; }
        IEnumerable<DataModel> Read(); 
    }
}
