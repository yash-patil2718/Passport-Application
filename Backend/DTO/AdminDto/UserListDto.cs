using PassportWebApplication.Enums;

namespace PassportWebApplication.DTO.AdminDto
{
    public class UserListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Username { get; set; }
        public DateTime AccountCretedOn { get; set; }
    }
}
