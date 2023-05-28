using Neptuno2022EF.Entidades.Dtos.Cliente;
using Neptuno2022EF.Entidades.Entidades;
using System;

namespace NuevaAppComercial2022.Entidades.Entidades
{
    public class Cliente:Persona,ICloneable
    {
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public ClienteListDto ToClienteListDto()
        {
            return new ClienteListDto
            {
                ClienteId = this.Id,
                NombreCliente = this.Nombre,
                Pais = this.Pais.NombrePais,
                Ciudad = this.Ciudad.NombreCiudad
            };
        }
    }
}
