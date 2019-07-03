namespace ListWishes.Domain.Users
{
    public class User : Entity<User>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
