using Microsoft.EntityFrameworkCore;
using StaffManagment.Models;

namespace StaffManagment.DataAccess.Models;

public static class ModelBuildrExtenstions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>().HasData(
                    new Staff()
                    {
                        Id = 1,
                        FirstName = "Zuhriddin",
                        LastName = "Zayniddinov",
                        Email = "zuhriddin@gmail.com",
                        Department = Departments.Admin
                    },
                    new Staff()
                    {
                        Id = 2,
                        FirstName = "Dilfuza",
                        LastName = "Zayniddinova",
                        Email = "dilfuza@gmail.com",
                        Department = Departments.Marketing
                    }
                );
    }
}
