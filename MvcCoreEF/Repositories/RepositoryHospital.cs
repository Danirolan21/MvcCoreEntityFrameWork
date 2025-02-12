using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHospital
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task
            InsertHospitalAsync(int idHospital, string nombre
            , string direccion, string telefono, int camas)
        {
            //CREAMOS UN MODEL
            Hospital hosp = new Hospital();
            //ASIGNAMOS SUS PROPIEDADES
            hosp.IdHospital = idHospital;
            hosp.Nombre = nombre;
            hosp.Direccion = direccion;
            hosp.Telefono = telefono;
            hosp.Camas = camas;
            //AÑADIMOS NUESTRO MODEL A LA COLECCION DBSET DEL CONTEXT
            await this.context.Hospitales.AddAsync(hosp);
            //INDICAMOS QUE ALMACENE LOS DATOS EN LA BBDD
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteHospitalAsync(int idHospital)
        {
            Hospital hospital =
                await this.FindHospitalAsync(idHospital);
            this.context.Hospitales.Remove(hospital);
            await this.context.SaveChangesAsync();
        }

        public async Task
            UpdateHospitalAsync(int idHospital, string nombre
            , string direccion, string telefono, int camas)
        {
            //BUSCAMOS EL OBJETO HOSPITAL A MODIFICAR
            Hospital hosp =
                await this.FindHospitalAsync(idHospital);
            //PODEMOS MODIFICAR TODO LO QUE DESEEMOS EXCEPTO
            //EL CAMPO [Key]
            hosp.Nombre = nombre;
            hosp.Direccion = direccion;
            hosp.Telefono = telefono;
            hosp.Camas = camas;
            //NO TENEMOS NINGUN METODO PARA REALIZAR UN UPDATE
            //DENTRO DEL CONTEXT Y DbSet<Y>
            await this.context.SaveChangesAsync();
        }
    }
}
