using System.ComponentModel.DataAnnotations;

namespace cliente_api.Modelos.Dtos
{
    public class CrearClienteDto
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }

        [Required(ErrorMessage = "La identificacion es obligatoria")]
        [MaxLength(13, ErrorMessage = "El número máximo de caracteres es de 13!")]
        public string Identificacion { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Contrasena { get; set; }

        public bool Estado { get; set; }
    }
}
