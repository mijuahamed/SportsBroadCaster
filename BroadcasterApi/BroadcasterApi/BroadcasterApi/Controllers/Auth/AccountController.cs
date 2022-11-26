using BroadcasterApi.ViewModel.LoginRegistration;
using DAL.Migrations;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace BroadcasterApi.Controllers.Auth
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            var response = new ResponseRegistrationViewModel();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Age = model.Age,
                    Address = model.Address,
                    IsActive= IsActiveStatus.Active

                };

                await _roleManager.CreateAsync(new IdentityRole(Role.Person));
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = new List<string>();
                    foreach (var x in result.Errors)
                    {
                        errors.Add(x.Description);
                    }
                    response.Success = false;
                    response.Message = "User Creation Not Successfull";

                    return BadRequest(new { success = response.Success , message = response.Message,errors = errors });
                }

                else
                {
                    await _userManager.AddToRoleAsync(user, Role.Person);

                    response.Success = true;
                    response.Message = "Registration Completed!";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Validation Error";
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return BadRequest(new { success = response.Success, message = response.Message, errors = allErrors });
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var response = new ResponseLoginViewModel();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Login Failed";
                return Ok(response);
            }

            var login = await _signManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (login.Succeeded)
            {
                response.Success = true;
                response.Message = "Login Successfully";
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user.IsActive)
                {
                    response.UserId = user.Id;
                    response.UserRole = await _userManager.GetRolesAsync(user);
                    
                    response.Token = await GenerateTokenAsync(user);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Login Failed User not Active";
                }

            }
            else
            {
                response.Success = false;
                response.Message = "Login Failed";
            }

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            var response = new ResponseLoginViewModel();
            await _signManager.SignOutAsync();
            response.Success = true;
            response.Message = "Login Successfully";
            return Ok(response);
        }
        private async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTDescription.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesCommaSeparated = string.Join(',', roles);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("UserId",user.Id),
                new Claim(ClaimTypes.Role,rolesCommaSeparated),
            };
            var token = new JwtSecurityToken(JWTDescription.Issuer,
                JWTDescription.Audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
