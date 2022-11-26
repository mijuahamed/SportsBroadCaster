using System.ComponentModel.DataAnnotations;

namespace BroadcasterApi.ViewModel.File
{
    public class FileViewModel
    {
        [Required]
        public string Name { set; get; }
        [Required]
        public string Path { set; get; }
        [Required]
        public string Type { set; get; }
        public string Source { set; get; }
    }
}
