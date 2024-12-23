namespace CDE_Exellence.Model
{
    public class Visit
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CreatedBy { get; set; } // ID người tạo
        public int? AssignedTo { get; set; } // ID người thực hiện
        public string Region { get; set; } = null!; // Vùng áp dụng
        public DateTime VisitDate { get; set; }
        public string Status { get; set; } = "Pending"; // Trạng thái
    }
}
