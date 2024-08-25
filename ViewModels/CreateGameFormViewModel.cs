using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {
     
        [AllowedExtensions(FileSetting.AllowedExtensions),
            AllowedLength(FileSetting.MaxFileSizeInByte)]
        public IFormFile Cover { get; set; } = default!;

    }
}
