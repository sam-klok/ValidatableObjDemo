using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatableObjDemo
{
    public class Settings: IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Enum.IsDefined(typeof(Category), Category))
            {
                yield return new ValidationResult("Invalid Category", new[] { nameof(Category) });
            }
        }
    }
}
