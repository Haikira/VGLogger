namespace VGLogger.Service.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeveloperDto Developer { get; set; }
        public IList<PlatformDto> Platforms { get; set; }
    }
}
