using System;
using System.Collections.Generic;
using System.Text;

namespace HMunozS6.Models
{
    public class Estudiante 
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string BrandModel
        {
            get
            {
                return nombre + " - " + edad;
            }
        }

    }
}
