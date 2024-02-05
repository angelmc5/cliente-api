using System.ComponentModel.DataAnnotations;

namespace cliente_api.Modelos
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; }
        
        public string Identificacion { get; set;}
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
