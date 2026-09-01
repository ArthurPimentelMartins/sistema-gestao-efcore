using System.ComponentModel.DataAnnotations;

namespace TrabEFCore.Models
{
    public class Hero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O nível é obrigatório")]
        [Range(1, 100, ErrorMessage = "O nível deve estar entre 1 e 100")]
        public int Level { get; set; }

        [Required(ErrorMessage = "A vida é obrigatória")]
        [Range(1, 10000, ErrorMessage = "A vida deve estar entre 1 e 10000")]
        public int Health { get; set; }

        [Required(ErrorMessage = "O ataque é obrigatório")]
        [Range(1, 1000, ErrorMessage = "O ataque deve estar entre 1 e 1000")]
        public int Attack { get; set; }

        [Required(ErrorMessage = "A defesa é obrigatória")]
        [Range(1, 1000, ErrorMessage = "A defesa deve estar entre 1 e 1000")]
        public int Defense { get; set; }

        public int? PartyId { get; set; }
        public Party? Party { get; set; }

        public ICollection<Item>? Items { get; set; }
    }
}
