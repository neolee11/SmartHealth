using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business_Logic.RepositoryContracts;
using Business_Objects.BusinessObjects;

namespace AP_RepoImplementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetWhere(Expression<Func<Appointment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Appointment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Appointment t)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
