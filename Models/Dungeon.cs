using System.ComponentModel.DataAnnotations;

namespace TrabEFCore.Models
{
    public class Dungeon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A dificuldade é obrigatória")]
        [Range(1, 10, ErrorMessage = "A dificuldade deve estar entre 1 e 10")]
        [Display(Name = "Dificuldade")]
        public int Difficulty { get; set; }

        [Required(ErrorMessage = "A recompensa é obrigatória")]
        [Range(0, 1000000, ErrorMessage = "A recompensa deve estar entre 0 e 1000000")]
        [Display(Name = "Recompensa")]
        public int Reward { get; set; }

        public ICollection<Monster> Monsters { get; set; }
    }
}
