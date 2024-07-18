using Project.ModelsSchool;
using Project.RepositorySchool;
using Project.RepositorySchool.RepositorySchoolInterfaces;
using Project.ServicesSchool.ServicesSchoolInterfaces;
using System.Data;
using System.Security.Claims;

namespace Project.ServicesSchool
{
    public class AddressServices : IAddressServices
    {

        private IAddressRepository _addressRepository = new AddressRepository();



        public Address GetAddressById(int id)
        {


            DataTable dt = _addressRepository.GetAddressById(id);
            DataRow dr = dt.Rows[0];
            //Address address = new Address(dr["street"].ToString(), Convert.ToInt32(dr["number"].ToString()), dr["postalCode"].ToString(), dr["locale"].ToString());

            Address address = new Address
            {
                AddressId = id,
                Street = dr["street"].ToString(),
                Number = Convert.ToInt32(dr["number"].ToString()),
                PostalCode = dr["postalCode"].ToString(),
                Locale = dr["locale"].ToString()

            };

            return address;
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();

            try
            {
                DataTable dt = _addressRepository.GetAllAddresses();

                foreach (DataRow dr in dt.Rows)
                {
                    Address address = new Address(
                        dr["street"].ToString(),
                        Convert.ToInt32(dr["number"].ToString()),
                        dr["postalCode"].ToString(),
                        dr["locale"].ToString()
                    );

                    addresses.Add(address);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Is not Working");
            }

            return addresses;
        }
        public int InsertNewAddress(Address newAddress)
        {
            int addressId = 0;

            try
            {
                addressId = _addressRepository.InsertNewAddress(newAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return addressId;
        }

        public Boolean UpdateAddress(Address updatedAddress)
        {
            bool updated = false;

            try
            {
                _addressRepository.UpdateAddress(updatedAddress);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return updated;
        }

    }
}