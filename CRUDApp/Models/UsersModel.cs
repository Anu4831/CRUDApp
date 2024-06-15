namespace CRUDApp.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
            

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string MunicipalityName { get; set; }
        public string WardNo { get; set; }

    }
}
