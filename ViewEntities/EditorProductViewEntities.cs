using System.ComponentModel.DataAnnotations;

namespace ProdManager.ViewEntities
{
    public class EditorProductViewEntities
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo código de barras é obrigatório")]
        [MaxLength(13, ErrorMessage = "Campo código de barras deve ter no máximo 13 caracteres")]
        public string CodeBar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo categoria é obrigatório")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo fornecedor é obrigatório")]
        public string Supplier { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo preço é obrigatório")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Campo quantidade é obrigatório")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Campo lote é obrigatório")]
        public string Lot { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo fabricação é obrigatório")]
        public DateTime Manufacture { get; set; }

        [Required(ErrorMessage = "Campo validade é obrigatório")]
        public DateTime Expiration { get; set; }
    }
}
