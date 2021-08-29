using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AwesomeShop.BusinessLogic.Products.Requests
{
    public class ProductImage : IValidatableObject
    {
        private static readonly string[] MimeFormats =
        {
            "image/apng", "image/avif", "image/gif", "image/jpeg", "image/png", "image/svg+xml", "image/webp"
        };

        
        [MinLength(100)]
        [MaxLength(1_000_000)]
        public string ImageBase64 { get; set; }

        public string ImageBase64Mime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!MimeFormats.Contains(ImageBase64Mime))
                yield return new("Invalid mime");
        }
    }
}