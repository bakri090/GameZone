namespace GameZone.Setting
{
	public static class FileSetting
	{
		public const string ImagesPath = "/assets/images/games";
		public const string AllowedExtensions = ".jpg,.jpeg,.png,.webp";
		public const int MaxFileSizeInMB = 1;
		public const int MaxFileSizeInByte = MaxFileSizeInMB * 1024 * 1024;
	}
}
