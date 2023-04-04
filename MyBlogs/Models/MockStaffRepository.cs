namespace MyBlogs.Models;

public class MockStaffRepository : IStaffRepository
{
    private List<Staff> _staffs;

    public MockStaffRepository()
    {
        _staffs = new List<Staff>()
        {
            new Staff() {Id = 1,FirstName = "AZ", LastName = "ZA",Email = "azza@gm.uz",Department = "far"},
            new Staff() {Id = 2,FirstName = "BF", LastName = "FB",Email = "bffb@gm.uz",Department = "duc"},
            new Staff() {Id = 3,FirstName = "HJ", LastName = "JH",Email = "hjjh@gm.uz",Department = "uql"}
        };
    }
    public Staff Get(int id)
    {
        return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
    }

    public IEnumerable<Staff> GetAll()
    {
        return _staffs;
    }
}
