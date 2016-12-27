namespace TOFI.TransferObjects.User.Queries
{
    public class UserQuery : Query
    {
        public int? Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int? EmployeeId { get; set; }

        public int? ClientId { get; set; }


        public static UserQuery WithId(int id)
        {
            return new UserQuery {Id = id};
        }

        public static UserQuery WithUsername(string username)
        {
            return new UserQuery {Username = username};
        }

        public static UserQuery WithEmail(string email)
        {
            return new UserQuery {Email = email};
        }

        public static UserQuery WithEmployeeId(int employeeId)
        {
            return new UserQuery {EmployeeId = employeeId};
        }

        public static UserQuery WithClientId(int clientId)
        {
            return new UserQuery {ClientId = clientId};
        }
    }
}