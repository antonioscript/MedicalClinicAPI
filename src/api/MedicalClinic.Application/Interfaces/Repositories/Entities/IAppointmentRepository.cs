using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Repositories.Entities
{
    public interface IAppointmentRepository //: IRepositoryAsync<Appointment>
    {
        public Task<List<Appointment>> GetAppointmentListAsync();
        //public Task<StudentDetails> GetStudentByIdAsync(int Id);
        //public Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails);
        //public Task<int> UpdateStudentAsync(StudentDetails studentDetails);
        //public Task<int> DeleteStudentAsync(int Id);
    }
}
