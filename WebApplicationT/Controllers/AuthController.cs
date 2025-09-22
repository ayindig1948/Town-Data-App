using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationT.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IConfiguration _config;

        public AuthController(IConfiguration configuration)
        { 
        _config= configuration;
        }
        public record LogenModel ( string UserName,string Password );
        public record UserData(string FirstName, string LastName, string Titel );

        [HttpPost("/token")]
        public ActionResult<string> getTokin([FromBody] LogenModel logen)
        {
            var Data = ValdateData(logen);
            if (Data == null)
            {
                return Unauthorized("not Alowad");
            }
            else
            {
                var token = GenrateToken(Data);
                return Ok(token);
            } }
private string GenrateToken(UserData data)
        {
            var scureyyKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));
            var sc= new SigningCredentials(scureyyKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new(JwtRegisteredClaimNames.Sub, data.FirstName));
            claims.Add(new(JwtRegisteredClaimNames.UniqueName, data.LastName));
            //claims.Add(new("Titel",data.Titel));
            var token = new JwtSecurityToken(
                _config.GetValue<string>("Authentication:Issuer"),
                _config.GetValue<string>("Authentication:Audience"),
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(10),
                sc);
            var tokenB= new JwtSecurityTokenHandler().WriteToken(token);
            return tokenB;

                

               
        }

        private UserData ValdateData(LogenModel logen)
        {
            var isNotNuul=CompareData("ay054842",logen.UserName)&&CompareData("10031993",logen.Password);
            if (isNotNuul==true)
            {
                var user = new UserData("avrum", "indig", "user");
                return user;
            }
            else {
                return null;
        }
        }

        private bool CompareData(string ex,string actul)
        {
            if (actul==ex)
            {
                return true;
            }
            else return false;
        }
    }
}
