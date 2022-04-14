using System.ComponentModel.DataAnnotations;

namespace NyFTraining.Controllers
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is not provided.")]
        public string Name { get; set; }
    }
}
