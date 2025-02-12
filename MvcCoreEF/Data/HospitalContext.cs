using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext : DbContext
    {
        //TENDREMOS UN CONSTRUCTOR QUE RECIBIRA LAS
        //OPCIONES DE INICIO PARA EL CONTEXT, COMO LA
        //CADENA DE CONEXION POR EJEMPLO
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) 
        { }
        //EN ESTA CLASE ESTARAN LAS COLECCIONES DE LOS MODELOS
        //QUE SERAN LAS QUE UTILIZAREMOS MEDIANTE LINQ
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
