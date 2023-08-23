using Dto;
using Infra;
using StudentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace StudentData.Controllers
{
    public class UserController:Controller
    {
        UserInfra userinfra;
        public UserController()
        {
            userinfra = new UserInfra();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var userlist = userinfra.Getuser();
            List<UserViewModel> Userlist = new List<UserViewModel>();
            foreach (var user in userlist)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.UserName=user.UserName;
                userViewModel.UserPhoneNumber = user.UserPhoneNumber;
                userViewModel.UserEmail = user.UserEmail;
                userViewModel.UserId = user.UserId;
                Userlist.Add(userViewModel);
            }
            return View(Userlist);
        }
        [HttpPost]
        public ActionResult Index(string UserName)
        {
            var userDto = new UserDto();
            userDto.UserName = UserName;
            var model = userinfra.Searchuser(userDto);
            List<UserViewModel>userViewModels = new List<UserViewModel>();
            foreach(var item in model)
            {
                UserViewModel userViewModel=new UserViewModel();
                userViewModel.UserName=item.UserName;
                userViewModel.UserId=item.UserId;
                userViewModel.UserPhoneNumber=item.UserPhoneNumber;
                userViewModel.UserEmail=item.UserEmail;
                userViewModels.Add(userViewModel);
                ViewBag.username = UserName;
            }
            return View(userViewModels);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel instance)
        {
            var Userdto=new UserDto();
            {
                Userdto.UserName = instance.UserName;
                Userdto.UserPhoneNumber = instance.UserPhoneNumber;
                Userdto.UserEmail = instance.UserEmail;
                Userdto.UserId = instance.UserId;
            }
            userinfra.Createuser(Userdto);
            TempData["Success"]= "<script>alert('User created successfully');</script>";
            return RedirectToAction("Index", "User");
        }
        public ActionResult Delete(int Id)
        {
            var userdto=new UserDto();
            {
                userdto.UserId = Id;
            }
            userinfra.Deleteuser(userdto);
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {  
                var filluser = userinfra.Filledit(Id);
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.UserName = filluser.UserName;
                userViewModel.UserId = filluser.UserId;
                userViewModel.UserPhoneNumber = filluser.UserPhoneNumber;
                userViewModel.UserEmail = filluser.UserEmail;
            TempData["EditSuccess"]= "<script>alert('User Update successfully');</script>";
            return View(userViewModel);
            
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
                 var userDto=new UserDto();           
                userDto.UserName = model.UserName;
                userDto.UserId = model.UserId;
                userDto.UserPhoneNumber = model.UserPhoneNumber;
                userDto.UserEmail = model.UserEmail;
                userinfra.Edituserdata(userDto);
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public ActionResult loginuser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginuser(string UserName)
        {
            var userDto = new UserDto();
            userDto.UserName = UserName;
            var model = userinfra.loginuser(userDto);
            if(model==true)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("loginuser", "User");
            }
            
        }
    }
}