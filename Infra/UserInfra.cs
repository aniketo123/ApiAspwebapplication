using Core;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class UserInfra
    {
        CoreUserServices coreUserServices;
        public UserInfra()
        {
            coreUserServices = new CoreUserServices();
        }
        public List<UserDto> Getuser()
        {
            return coreUserServices.Getuser();
        }
        public bool Createuser(UserDto user)
        {
            return coreUserServices.Createuser(user);
        }
        public bool Deleteuser(UserDto user)
        {
            return coreUserServices.Deleteuser(user);
        }
        public UserDto Filledit(int Id)
        {
            return coreUserServices.Filledit(Id);
        }
        public bool Edituserdata(UserDto user)
        {
            return coreUserServices.Edituserdata(user);
        }
        public List<UserDto> Searchuser(UserDto userDto)
        {
            return coreUserServices.Searchuser(userDto);
        }
        public bool loginuser(UserDto user)
        {
            return coreUserServices.loginuser(user);
        }
    }
}
