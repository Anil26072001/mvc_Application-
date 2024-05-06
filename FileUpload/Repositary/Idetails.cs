using FileUploadOperation.Models;


namespace FileUploadOperation.Interfaces
{
    public interface Idetails
    {

        public List<Register> GetUsers();
        void AddUsers(Register user);
        bool AuthenticatedUser(string email, string password);

        public bool DeleteUser(int id);

        //UserLogin GetUsersbyId(int id);
        void Edit(int id, Register register);
    }
}
