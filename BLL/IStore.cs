using System.Collections.Generic;
using DataModelLibrary;

namespace BLL
{
    interface IStore
    {
        string Path { get; set; }
        string jsonPath { get; set; }//
        IEnumerable<DataModel> Read(); 
    }
}
