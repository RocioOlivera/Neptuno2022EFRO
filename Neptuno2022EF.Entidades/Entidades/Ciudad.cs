using Neptuno2022EF.Entidades.Dtos.Ciudad;
using System;

namespace Neptuno2022EF.Entidades.Entidades
{
    public class Ciudad : ICloneable
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public int PaisId { get; set; }
        public byte[] RowVersion { get; set; }
        public Pais Pais { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public CiudadListDto ToCiudadListDto()
        {
            return new CiudadListDto()
            {
                CiudadId = this.CiudadId,
                NombreCiudad = this.NombreCiudad,
                NombrePais = this.Pais.NombrePais
            };
        }
    }
}
