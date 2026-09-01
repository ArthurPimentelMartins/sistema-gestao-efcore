using System.ComponentModel.DataAnnotations;

namespace TrabEFCore.Models
{
    public class Monster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A vida é obrigatória")]
        [Range(1, 100000, ErrorMessage = "A vida deve estar entre 1 e 100000")]
        [Display(Name = "Vida")]
        public int Health { get; set; }

        [Required(ErrorMessage = "O ataque é obrigatório")]
        [Range(1, 5000, ErrorMessage = "O ataque deve estar entre 1 e 5000")]
        [Display(Name = "Ataque")]
        public int Attack { get; set; }

        [Required(ErrorMessage = "A defesa é obrigatória")]
        [Range(1, 5000, ErrorMessage = "A defesa deve estar entre 1 e 5000")]
        [Display(Name = "Defesa")]
        public int Defense { get; set; }

        [Required(ErrorMessage = "O ouro dropado é obrigatório")]
        [Range(0, 100000, ErrorMessage = "O ouro deve estar entre 0 e 100000")]
        [Display(Name = "Ouro Dropado")]
        public int GoldDrop { get; set; }

        public int? DungeonId { get; set; }
        public Dungeon? Dungeon { get; set; }
    }
}
