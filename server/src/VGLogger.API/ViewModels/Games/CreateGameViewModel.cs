namespace VGLogger.API.ViewModels
{
    public class CreateGameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public List<PlatformViewModel> Platforms { get; set; }
    }
}