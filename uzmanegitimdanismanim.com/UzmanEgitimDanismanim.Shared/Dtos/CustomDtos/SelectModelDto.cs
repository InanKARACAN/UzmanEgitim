namespace UzmanEgitimDanismanim.Shared.Dtos.CustomDtos
{
    [Serializable]
    public class SelectModelDto
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }

    [Serializable]
    public class SelectModelWithString
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
