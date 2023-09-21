namespace WebAPIPractice
{
    public class GenericUser<T,U>
    {
        public U Id { get; set; }
        public T Tc { get; set; }
        public T Name { get; set; }

        public GenericUser(U Id, T Tc, T Name)
        {
            this.Id = Id;
            this.Tc = Tc;
            this.Name = Name;
        }

        public static List<GenericUser<string, int>> GetGenericUsers()
        {
            var genericUsers = new List<GenericUser<string, int>>
            {
                new GenericUser<string, int>(0, "36382689960", "Azizcan"),
                new GenericUser<string, int>(1, "38273782873", "Cihan"),
                new GenericUser<string, int>(2, "38283289388", "Kemal")
            };

            return genericUsers;
        }
        public void UpdateUser()
        {
            
        }
    }
}
