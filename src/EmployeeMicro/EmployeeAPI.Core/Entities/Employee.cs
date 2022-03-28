using EmployeeApi.SharedKernel;
using EmployeeApi.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace EmployeeAPI.Core.Entities
{
    public class Employee : IdentityUser<Guid>, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
