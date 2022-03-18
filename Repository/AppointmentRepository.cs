using IRMS.IRepository;
using IRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repository
{
    public class AppointmentRepository : IAppointment
    {
        private readonly IRMSContext irmsDBContext;

        public AppointmentRepository(IRMSContext irmsDBContext)
        {
            this.irmsDBContext = irmsDBContext;
        }

        public async Task<IEnumerable<Appointment>> GetAllRecords()
        {
            return await irmsDBContext.Appointment.ToListAsync();
        }

        public async Task<Appointment> GetRecord(int iD)
        {
            return await irmsDBContext.Appointment
                .FirstOrDefaultAsync(e => e.ID == iD);
        }

        public async Task<Appointment> AddRecord(Appointment appointment)
        {
            var result = await irmsDBContext.Appointment.AddAsync(appointment);
            await irmsDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Appointment> UpdateRecord(Appointment appointment)
        {
            var result = await irmsDBContext.Appointment
                .FirstOrDefaultAsync(e => e.ID == appointment.ID);

            if (result != null)
            {
                // I Will add later

                await irmsDBContext.SaveChangesAsync();

                return result;
            }

            return result;
        }

        public async Task<Appointment> DeleteRecord(int iD)
        {
            var result = await irmsDBContext.Appointment
                .FirstOrDefaultAsync(e => e.ID == iD);
            if (result != null)
            {
                irmsDBContext.Appointment.Remove(result);
                await irmsDBContext.SaveChangesAsync();
            }
            return result;
        }
    }
}
