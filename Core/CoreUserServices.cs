using Core.CoreModel;
using Core.DeepCopyServices;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CoreUserServices
    {
        //UserContext _userContext;
        StudentContext _studentContext;
        public CoreUserServices()
        {
            _studentContext = new StudentContext();
        }
        public List<UserDto> Getuser()
        {
            var userlist = _studentContext.Users.ToList();
            var usercoretodtolist = new DeepCopyServices.UserDeepcopyServices().CoretoDto(userlist);
            return usercoretodtolist;
        }
        public bool Createuser(UserDto user)
        {
            var Coreuser = new DeepCopyServices.UserDeepcopyServices().DTotoCore(user);
            _studentContext.Users.Add(Coreuser);
            _studentContext.SaveChangesAsync();
            return true;
        }
        public bool Deleteuser(UserDto user)
        {
            var deleteuser = _studentContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            _studentContext.Users.Remove(deleteuser);
            _studentContext.SaveChangesAsync();
            return true;
        }
        public UserDto Filledit(int Id)
        {
            var Edituserdata = _studentContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            var EdituserCoretoDto = new DeepCopyServices.UserDeepcopyServices().EditCoretoDto(Edituserdata);
            return EdituserCoretoDto;
        }
        public bool Edituserdata(UserDto user)
        {
            var updaterecord = _studentContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            updaterecord.UserName = user.UserName;
            updaterecord.UserPhoneNumber = user.UserPhoneNumber;
            updaterecord.UserEmail = user.UserEmail;
            _studentContext.SaveChangesAsync();
            return true;
        }
        public List<UserDto> Searchuser(UserDto userDto)
        {
            var userdata = _studentContext.Users.Where(x => x.UserName.Contains(userDto.UserName) || x.UserEmail.Contains(userDto.UserName)).ToList();
            var usercoretodto = new DeepCopyServices.UserDeepcopyServices().CoretoDto(userdata);
            return usercoretodto;
        }
        public bool loginuser(UserDto user)
        {
            var userdata = _studentContext.Users.Where(x => x.UserName == user.UserName).ToList();
           if( userdata.Count>0)
            {
                return true;
            }
           else
            {
                return false;
            }
        }
    }
}
