namespace StaffManagment.Models;

public class MockStaffRepository : IStaffRepository
{
    private List<Staff> _staffs;

    public MockStaffRepository()
    {
        _staffs = new List<Staff>()
        {
            new Staff() {Id = 1,FirstName = "AZ", LastName = "ZA",Email = "azza@gm.uz",Department = Departments.Sales},
            new Staff() {Id = 2,FirstName = "BF", LastName = "FB",Email = "bffb@gm.uz",Department = Departments.HR},
            new Staff() {Id = 3,FirstName = "HJ", LastName = "JH",Email = "hjjh@gm.uz",Department = Departments.Marketing}
        };
    }

    public Staff Create(Staff staff)
    {
        staff.Id = _staffs.Max(st => st.Id) + 1;
        _staffs.Add(staff);
        return staff;
    }

    public Staff Delete(int id)
    {
        var staff = _staffs.FirstOrDefault(st => st.Id == id);
        if (staff != null)
        {
            _staffs.Remove(staff);
        }
        return staff;
    }

    public Staff Get(int id)
    {
        return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
    }

    public IEnumerable<Staff> GetAll()
    {
        return _staffs;
    }

    public Staff Update(Staff updateStaff)
    {
        var staff = _staffs.FirstOrDefault(st => st.Id == updateStaff.Id);
        if (updateStaff != null)
        {
            staff.FirstName = updateStaff.FirstName;
            staff.LastName = updateStaff.LastName;
            staff.Email = updateStaff.Email;
            staff.Department = updateStaff.Department;
        }
        return staff;
    }
}
