using System;

namespace WebApplication3.App.Model
{
    public class Dispositivo
    {

        public int Id { get; set; }
        public int Temperatura { get; set; }
        public string Ambiente { get; set; }
        public string DataHora { get; set; }

        public Dispositivo()
        {
            
          
        }
    }
}