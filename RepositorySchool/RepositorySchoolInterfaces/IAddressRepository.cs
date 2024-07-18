using Project.ModelsSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositorySchool.RepositorySchoolInterfaces
{
    public interface IAddressRepository
    {

        public DataTable GetAddressById(int id);
        public DataTable GetAllAddresses();
        public int InsertNewAddress(Address address);
        public void UpdateAddress(Address address);
    }
}
