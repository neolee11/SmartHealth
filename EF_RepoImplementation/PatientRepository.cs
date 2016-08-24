using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Business_Logic.RepositoryContracts;
using Business_Objects.BusinessObjects;

namespace EF_RepoImplementation
{
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetWhere(Expression<Func<Patient, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Patient t)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
