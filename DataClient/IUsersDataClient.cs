using System.Collections.Generic;

namespace DataClient
{
    public interface IUsersDataClient
    {
        bool DeleteUser(int id);
        List<UserDTO> GetAllUsers();
        UserDTO GetByID(int id);
        bool PatchExistingUser(UserDTO userDTO);
        bool PostNewUser(UserDTO userDTO);
        List<UserDTO> SearchUsersByName(string name);
    }
}