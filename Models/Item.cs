using System.ComponentModel.DataAnnotations;

namespace TrabEFCore.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        [StringLength(50, ErrorMessage = "O tipo deve ter no máximo 50 caracteres")]
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Required(ErrorMessage = "O bônus de ataque é obrigatório")]
        [Range(0, 500, ErrorMessage = "O bônus de ataque deve estar entre 0 e 500")]
        [Display(Name = "Bônus de Ataque")]
        public int AttackBonus { get; set; }

        [Required(ErrorMessage = "O bônus de defesa é obrigatório")]
        [Range(0, 500, ErrorMessage = "O bônus de defesa deve estar entre 0 e 500")]
        [Display(Name = "Bônus de Defesa")]
        public int DefenseBonus { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "O preço deve estar entre 0 e 1000000")]
        [Display(Name = "Preço")]
        public int Price { get; set; }

        public int? HeroId { get; set; }
        public Hero? Hero { get; set; }
    }
}
