using System.ComponentModel.DataAnnotations;

namespace TrabEFCore.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        [Display(Name = "Data de Criação")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "O número máximo de membros é obrigatório")]
        [Range(1, 10, ErrorMessage = "O número de membros deve estar entre 1 e 10")]
        [Display(Name = "Máximo de Membros")]
        public int MaxMembers { get; set; }

        public ICollection<Hero> Heroes { get; set; }
    }
}
