using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Objects.BusinessObjects
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int LocationId { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateimTime { get; set; }
        public string FirstName { get; set; } //Patient
        public string LastName { get; set; } //Patient
    }
}
