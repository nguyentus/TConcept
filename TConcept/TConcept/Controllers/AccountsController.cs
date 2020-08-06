using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TConcept.BLL;
using TConcept.Common.Req;
using TConcept.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TConcept.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace TConcept.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IConfiguration _config;
        public AccountsController(IConfiguration config)
        {
            _svc = new AccountsSvc();
            _config = config;
        }

        [HttpPost("get-account-login")]
        public IActionResult getAccountLogin([FromBody]AccountReq req)
        {
            var res = new SingleRsp();
            res = _svc.Login(req.UserName, req.UserPassword);
            return Ok(res);
        }

        [HttpPost("create-account")]
        public IActionResult CreateAccount([FromBody]AccountReq req)
        {
            var res = _svc.CreateAccount(req);
            return Ok(res);
        }

        [HttpPost("update-account")]
        public IActionResult UpdateAccount([FromBody]AccountReq req)
        {
            var res = _svc.UpdateAccount(req);
            return Ok(res);
        }

        //[HttpPost("delete-account")]
        //public IActionResult DeleteAccount([FromBody]SimpleReq req)
        //{
        //    var res = _svc.DeleteAccount(req.Id);
        //    return Ok(res);
        //}

        //[HttpPost("get-all")]
        //public IActionResult getAllAccount()
        //{
        //    var res = new SingleRsp();
        //    res.Data = _svc.All;
        //    return Ok(res);
        //}

        [Authorize]
        [HttpPost("get-by-id")]
        public IActionResult getAccountById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        //[HttpPost("get-info-account-by-id")]
        //public IActionResult GetInfoAccountByID([FromBody]InfoAccountReq req)
        //{
        //    var res = _svc.GetInfoAccountByID(req.AccountId);
        //    return Ok(res);
        //}


        // Config TOKEN
        private Accounts AuthenticateUser(Accounts login)
        {
            Accounts user = null;
            if (login.UserName == "nguyentu" && login.UserPassword == "123")
            {
                user = new Accounts()
                {
                    UserName = "Thanh Tu Nguyen",
                    UserPassword = "123",
                    Notes = "Day la api co token"
                };
            }
            return user;
        }

        private string GenerateJSONWebToken(Accounts userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Notes),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        [HttpGet("get-account-token")]
        public IActionResult GetAccountToken(string username, string password)
        {
            var login = new Accounts()
            {
                UserName = username,
                UserPassword = password
            };

            IActionResult respone = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                respone = Ok(new { token = tokenStr });
            }

            return respone;
        }

        private readonly AccountsSvc _svc;
    }
}