namespace AppStudent.Data
{
    public class RolePrivilege
    {
        public int Id { get; set; }
        public string RolePrivilegeName { get; set; }
        public string Description { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
