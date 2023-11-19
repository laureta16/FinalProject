using FinalProjeckt.Data.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace FinalProjeckt.Data
{
    public static class FakeDB
    {
        public static List<Tasks> TasksDb = new List<Tasks>()
        {
            new Tasks()
            {
                Id = 1,
                Title = "laundry",
                Status = "Done",
                Description = "Performed before noon",
                DueDate = "Before Sunday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Tasks()
            {
                Id = 2,
                Title = "cooking",
                Status = "Done",
                Description = "Performed before noon",
                DueDate = "Before Monday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Tasks()
            {
                Id = 3,
                Title = "mopping",
                Status = "Done",
                Description = "Performed before noon",
                DueDate = "Before Tuesday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Tasks()
            {
                Id = 4,
                Title = "Cleaning",
                Status = "Unfished",
                Description = "Performed before noon",
                DueDate = "Before friday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
        };


        public static List<Tasks> GetAllTasks()
        {
            return TasksDb;
        }

        public static List<User> UserDb = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Android01",
                LastName = "Lastname01",
                Email = "Email01@gmail.com",
                Role = "Account Manager",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new User()
            {
                Id = 2,
                FirstName = "Android02",
                LastName = "Lastname02",
                Email = "Email02@gmail.com",
                Role = "ProjectManager",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
             new User()
            {
                Id = 3,
                FirstName = "Android03",
                LastName = "Lastname03",
                Email = "Email03@gmail.com",
                Role = "Manager",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
              new User()
            {
                Id = 4,
                FirstName = "Android04",
                LastName = "Lastname04",
                Email = "Email04@gmail.com",
                Role = "Web Dev",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },

        };


        public static List<User> GetAllUsers()
        {
            return UserDb;
        }

        public static List<Project> ProjectDb = new List<Project>()
        {
            new Project()
            {
                Id = 1,
                Name = "Android01",
                Description = "Lastname01",
                StartDate = "Monday",
                EndDate = "Friday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Project()
            {
                Id = 2,
                Name = "Android02",
                Description = "Lastname02",
                StartDate = "Friday",
                EndDate = "Tuesday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Project()
            {
                Id = 3,
                Name = "Android03",
                Description = "Lastname03",
                StartDate = "Monday",
                EndDate = "Friday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Project()
            {
                Id = 4,
                Name = "Android04",
                Description = "Lastname04",
                StartDate = "Tuesday",
                EndDate = "Sunday",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow

            },



        };

        public static List<Project> GetAllProjects()
        {
            return ProjectDb;
        }

        public static List<Customer> GetAllCustomers()
        {
            return CustomerDb;
        }

        public static List<Customer> CustomerDb = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                Name = "Android01",
                ContactPerson = "Lastname01",
                Email = "Laureta16@gmail.com",
                Phone = "066778886",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Customer()
            {
                Id = 2,
                Name = "Android01",
                ContactPerson = "Lastname01",
                Email = "User@gmail.com",
                Phone = "98876766",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Customer()
            {
               Id = 3,
                Name = "Android01",
                ContactPerson = "Lastname01",
                Email = "Monday@fhsjja.com",
                Phone = "0090998",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Customer()
            {
                Id = 4,
                Name = "Android01",
                ContactPerson = "Lastname01",
                Email = "Monday@fhhfhf.com",
                Phone = "47474747",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow

            },



        };

        public static List<Customer> GetAllCustomer ()
        {
            return CustomerDb;
        }


    }
}
