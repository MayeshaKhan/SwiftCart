using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        private static TokenDTO createToken(string UserRole, int UserId)
        {
            Token newToken = new Token();
            newToken.UserRole = UserRole;
            newToken.UserId = UserId;
            newToken.CreateTime = DateTime.Now;
            newToken.ExpireTime = DateTime.Now.AddMinutes(30);
            newToken.TokenString = Guid.NewGuid().ToString();
            DataFactory.TokenData().Create(newToken);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token,  TokenDTO>();
            });
            var mapper = new Mapper(config);
            var tokenDtoObj = mapper.Map<TokenDTO>(newToken);
            return tokenDtoObj;
        } 
        public static TokenDTO ValidateToken(string token)
        {
            var tokenObj = DataFactory.TokenData().Get()
                .Where(x => x.TokenString.Equals(token))
                .SingleOrDefault();
            if(tokenObj == null)
            {
                return null;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var tokenDtoObj = mapper.Map<TokenDTO>(tokenObj);
            return tokenDtoObj;
        }
        public static TokenDTO Login(string username, string password)
        {
            //for admin
            var adminObj = DataFactory.AdminData().Get()
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                .SingleOrDefault();
            if(adminObj != null )
            {
                return createToken("Admin", adminObj.Id);
            }
            //for agent
            var agentObj = DataFactory.AgentData().Get()
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                .SingleOrDefault();
            if(agentObj != null )
            {
                return createToken("Agent", agentObj.Id);
            }
            //for seller
            var sellerObj = DataFactory.SellerData().Get()
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                .SingleOrDefault();
            if(sellerObj != null )
            {
                return createToken("Seller", sellerObj.Id);
            }
            //for customer
            var customerObj = DataFactory.CustomerData().Get()
                .Where(x => x.Username.Equals(username) && x.Password.Equals(password))
                .SingleOrDefault();
            if(customerObj != null )
            {
                return createToken("customer", customerObj.Id);
            }
            return null;
        }
    }
}
