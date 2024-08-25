﻿namespace GameZone.ViewModels
{
	public class EditGameFormViewModel : GameFormViewModel
	{
		public int Id { get; set; }
		public string? CurrentCover { get; set; }

		[AllowedExtensions(FileSetting.AllowedExtensions)
			,AllowedLength(FileSetting.MaxFileSizeInByte)]
		public IFormFile? Cover { get; set; }
	}
}
