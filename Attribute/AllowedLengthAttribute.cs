namespace GameZone.Attribute
{
	public class AllowedLengthAttribute :ValidationAttribute
	{
		private readonly int _allowedSize;
		public AllowedLengthAttribute(int allowedSize)
		{
			_allowedSize = allowedSize;
		}
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;

			if (file is not null)
			{
				if(file.Length > _allowedSize)
				{
					return new ValidationResult(errorMessage : $"Maximum Allowed Size is {_allowedSize} bytes");
				}
			}
			return ValidationResult.Success;
		}
	}
}
