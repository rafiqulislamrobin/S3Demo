using Custom.GenericCustomLayerAdo;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.GenericCustomLayerAdo
{
    public class ChildRepositoryAdoGeneric : RepositoryGeneric<Customer>
    {
        //public ChildRepositoryAdoGeneric(IOptions<ConnectionString> connectionString) : base(connectionString)
        //{
        //}
    }
}
