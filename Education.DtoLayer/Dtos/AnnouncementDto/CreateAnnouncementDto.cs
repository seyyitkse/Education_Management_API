namespace Education.DtoLayer.Dtos.AnnouncementDto
{
    public class CreateAnnouncementDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
    }
}
