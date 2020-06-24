using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.Master;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SchoolManagement.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolManagement.Business
{
    public class AuthService : IAuthService
    {
        private readonly MasterDBContext dbContext;
        private readonly ISMUow uow;
        private readonly IConfiguration config;
        public AuthService(MasterDBContext dbContext, ISMUow uow, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.uow = uow;
            this.config = config;
        }
        public UserToken Login(LoginViewModel model)
        {
            var response = new UserToken();
            var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == model.Username && t.IsActive==true);
            if(user == null)
            {
                response.IsLoginSuccess = false;
                response.ErrorMessage = "Login failed.Incorrect username has been provided ";

                return response;
            }
            else
            {
                var passwordHash = CustomPasswordHasher.GenerateHash(model.Password);

                if(user.Password == passwordHash)
                {
                    var school = dbContext.Schools.FirstOrDefault(t => t.SchoolDomain.ToUpper() == model.SchoolName.ToUpper());

                    if(school==null)
                    {
                        response.IsLoginSuccess = false;
                        response.ErrorMessage = "Login failed.Invalid school name has been provided";

                        return response;
                    }
                    else
                    {
                        var test = config["Tokens:Key"];
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(school.SecretKey.ToString()));
                        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                        string userRole = string.Empty;
                        string role = user.UserRoles.FirstOrDefault().Role.Name;

                        var now = DateTime.UtcNow;
                        DateTime nowDate = DateTime.UtcNow;
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                            new Claim(JwtRegisteredClaimNames.Aud,"mobileapp"),
                            new Claim(JwtRegisteredClaimNames.Aud,"webapp"),
                            new Claim(ClaimTypes.Role,role),
                            new Claim("SecretKey", school.SecretKey.ToString())
                        };


                        var tokenOptions = new JwtSecurityToken(
                            issuer: config["Tokens:Issuer"],
                            claims: claims,
                            notBefore: nowDate,
                            expires: nowDate.AddDays(100),
                            signingCredentials: signinCredentials

                        );

                        tokenOptions.Header.Add("kid", school.APIKey.ToString());

                        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                        response.Token = tokenString;
                        response.IsLoginSuccess = true;
                        response.DisplayName = user.NickName;
                        response.Roles = user.UserRoles.Select(t => t.Role).Select(t => t.Name).ToList();
                        response.SchoolDomain = model.SchoolName;

                        // authentication successful so generate jwt token
                        //    var tokenHandler = new JwtSecurityTokenHandler();
                        //    var key = Encoding.ASCII.GetBytes(config["Tokens:Key"]);
                        //    var tokenDescriptor = new SecurityTokenDescriptor
                        //    {
                        //        Subject = new ClaimsIdentity(new Claim[]
                        //        {
                        //new Claim(ClaimTypes.Name, user.Id.ToString())
                        //        }),
                        //        Expires = DateTime.UtcNow.AddDays(7),
                        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        //    };
                        //    var token = tokenHandler.CreateToken(tokenDescriptor);


                        //    response.Token = tokenHandler.WriteToken(token);
                        //    response.IsLoginSuccess = true;



                        return response;
                    }


                }
                else
                {
                    response.IsLoginSuccess = false;
                    response.ErrorMessage = "Login failed.Incorrect password has been provided ";

                    return response;
                }
            }
        }
    }
}
