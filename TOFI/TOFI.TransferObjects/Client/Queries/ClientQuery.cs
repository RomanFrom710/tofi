namespace TOFI.TransferObjects.Client.Queries
{
    public class ClientQuery : Query
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }


        public static ClientQuery WithId(int id)
        {
            return new ClientQuery {Id = id};
        }

        public static ClientQuery WithUserId(int userId)
        {
            return new ClientQuery {UserId = userId};
        }
    }
}