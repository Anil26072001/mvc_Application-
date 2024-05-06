using FileUpload.Data;

using FileUploadOperation.Interfaces;
using FileUploadOperation.Models;


namespace FileUploadOperation.Repository
{

    public class Authentication : Idetails
    {
        private readonly ApplicationDBContext _context;
        public Authentication(ApplicationDBContext context)
        {
            _context = context;
        }


        public List<Register> GetUsers()
        {

            List<Register> users = _context.Registers.Where(u => u.IsDeleted == true).ToList();

            return users;

        }
        public void UserLogin(UserLogin user)
        {
            throw new NotImplementedException();
        }


        public bool AuthenticatedUser(string Email, string password)
        {

            var succeed = _context.Registers.Where(a => a.Email == Email
                 && a.Password == password).FirstOrDefault();
            if (succeed != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void AddUsers(Register user)
        {
            if (user != null)
            {

                 _context.Registers.Add(user);
                 _context.SaveChanges();
            }
            return;
        }

        public void Edit(int id, Register register)
        {
            var users = _context.Registers.FirstOrDefault(i => i.id == id);

            if (users != null)
            {
                users.Name = register.Name;
                users.Email = register.Email;
                users.Password = register.Password;
                users.ConfirmPassword = register.ConfirmPassword;
                _context.SaveChanges();
            }
        }

        public bool DeleteUser(int id)
        {
            int i = 0;
            var getid = _context.Registers.Find(id);
            if (getid != null)
            {
                //getid.IsDeleted = false;
                getid.IsDeleted = false;
                i = _context.SaveChanges();
                return true;
            }
            else
                return false;
        
        }
}
    }

