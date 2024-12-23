namespace CDE_Exellence.Model
{
    public class Permission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool AllAccess { get; set; } // Quyền xem tất cả lịch
    }
}
