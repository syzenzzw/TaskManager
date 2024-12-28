using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dtos
{
    public class UpdateRequestTarefa
    {
        [Required]
        [MinLength(2, ErrorMessage = "O titulo requer pelo menos 2 caracteres")]
        [MaxLength(20, ErrorMessage = "O titulo pode ter no máximo 20 caracteres")]
        public string Tittle { get; set; } = string.Empty;


        [Required]
        [MinLength(5, ErrorMessage = "O conteúdo pode ter no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O conteúdo pode ter no máximo 100 caracteres")]
        public string Content { get; set; } = string.Empty;
    }
}
