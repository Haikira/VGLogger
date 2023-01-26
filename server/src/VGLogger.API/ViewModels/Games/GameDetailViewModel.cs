namespace VGLogger.API.ViewModels
{
    public class GameDetailViewModel : GameViewModel
    {
        public DeveloperViewModel Developer { get; set; }

        public List<PlatformViewModel> Platforms { get; set; }
    }
}