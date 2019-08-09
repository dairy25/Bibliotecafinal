using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaDairy.Models
{
    public class Editoria
    {
        public int Ideditoria { get; set; }
        public string nombre { get; set; }
        public DateTime fechadefundacion { get; set; }

        public class map
        {
            public map(EntityTypeBuilder<Editoria> lb)
            {
                lb.HasKey(x => x.Ideditoria);
                lb.Property(x => x.nombre).HasMaxLength(100).HasColumnName("nombre");
                lb.Property(x => x.fechadefundacion).HasColumnName("fechadefundacion").HasColumnType("DateTime");

            }
        }
    }
}
