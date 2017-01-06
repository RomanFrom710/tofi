namespace TOFI.TransferObjects.Employee.Queries
{
    public class EmployeeQuery : Query
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }


        public static EmployeeQuery WithId(int id)
        {
            return new EmployeeQuery {Id = id};
        }

        public static EmployeeQuery WithUserId(int userId)
        {
            return new EmployeeQuery {UserId = userId};
        }
    }
}