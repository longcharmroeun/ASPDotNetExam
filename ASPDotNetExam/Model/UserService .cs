using ASPDotNetExam.DataBase;
using ASPDotNetExam.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASPDotNetExam.Model
{
    public interface IUserService
    {
        User AuthenticateAsync(string username, string password);
        IEnumerable<Item> GetItems(int id);
        User GetUserInfor(int id);
        Task<string> AddItemAsync(int id, Item item);
    }
    public class UserService:Database , IUserService
    {

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            this.userContext = new userContext();
        }

        public async Task<string> AddItemAsync(int id, Item item)
        {
            this.userContext.UserItems.Add(new UserItem() { Item = item, UserID = id });
            await this.userContext.SaveChangesAsync();
            return "successfully";
        }

        public User AuthenticateAsync(string username, string password)
        {
            var user = this.userContext.User.SingleOrDefault(x => x.Name == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user.WithoutPassword();
        }

        public IEnumerable<Item> GetItems(int id)
        {
            return this.userContext.UserItems.Where(UserItem => UserItem.UserID == id).
            Include(UserItem => UserItem.Item).ThenInclude(Item=>Item.ItemDate).
            Include(UserItem => UserItem.Item).ThenInclude(Item => Item.Category).
            Include(UserItem => UserItem.Item).ThenInclude(Item => Item.Stock).
            Include(UserItem => UserItem.Item).ThenInclude(Item => Item.Promo).
            Include(UserItem => UserItem.Item).ThenInclude(Item => Item.Type).
            Include(UserItem => UserItem.Item).ThenInclude(Item => Item.Price).
            Select(UserItem => UserItem.Item).ToList();
        }

        public User GetUserInfor(int id)
        {
            return this.userContext.User.Find(id).WithoutPassword();
        }
    }
}