namespace UzmanEgitimDanismanim.Shared.Dtos.CustomDtos
{
    public class CalenderDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public bool groupId { get; set; }
        public string overlap { get; set; }

    }
}
