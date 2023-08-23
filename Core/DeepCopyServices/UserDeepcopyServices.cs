using Core.CoreModel;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DeepCopyServices
{
    public class UserDeepcopyServices
    {
        public List<UserDto>CoretoDto(List<UserCoreModel>userCoreModel)
        {
            List<UserDto>userdtolist = new List<UserDto>();
            foreach (var item in userCoreModel)
            {
                UserDto userdto = new UserDto();
                userdto.UserId = item.UserId;
                userdto.UserName = item.UserName;
                userdto.UserPhoneNumber = item.UserPhoneNumber;
                userdto.UserEmail = item.UserEmail;
                userdtolist.Add(userdto);
            }
            return userdtolist;
        }
        public UserCoreModel DTotoCore(UserDto userDto)
        {
            UserCoreModel userCoreModel = new UserCoreModel();
            userCoreModel.UserId = userDto.UserId;
            userCoreModel.UserName = userDto.UserName;
            userCoreModel.UserPhoneNumber = userDto.UserPhoneNumber;
            userCoreModel.UserEmail = userDto.UserEmail;
            return userCoreModel;
        }
        public UserDto EditCoretoDto(UserCoreModel userCoreModel)
        {
            UserDto userDto=new UserDto();
            userDto.UserId= userCoreModel.UserId;
            userDto.UserName= userCoreModel.UserName;
            userDto.UserPhoneNumber= userCoreModel.UserPhoneNumber;
            userDto.UserEmail= userCoreModel.UserEmail;
            return userDto;
        }

    }
}
