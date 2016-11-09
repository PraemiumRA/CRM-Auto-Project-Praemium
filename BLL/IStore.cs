using System.Collections.Generic;
using DataModelLibrary;

namespace BLL
{
    interface IStore
    {
        string Path { get; set; }  
        IEnumerable<DataModel> Read(); 
    }
}
