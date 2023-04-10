namespace StaffManagment.Models;

public interface IStaffRepository
{
    Staff Get(int id);
    IEnumerable<Staff> GetAll();
    Staff Create(Staff staff);
    Staff Update(Staff updateStaff);
    Staff Delete(int id);
}
