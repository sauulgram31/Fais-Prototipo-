using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS_PROTOTIPO_.Models
{
    public class Contacto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Asunto { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        public string Mensaje { get; set; }


    }

}

