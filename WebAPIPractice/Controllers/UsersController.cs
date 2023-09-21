using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPractice.Dtos;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //-------------  Create list with type of User.  -----------//
        //static List<User> _users = new List<User>
        //{

        //    new User(0, "36382689960", "Azizcan", 23),
        //    new User(1, "11213141516", "Cihan", 27),
        //    new User(2,"12223242526","Ahmet",58)
        //};


        //-----------  Create static list with type of genericUser.  ------------//
        //static List<GenericUser<string, int>> genericUsers = new List<GenericUser<string, int>>
        //{
        //    new GenericUser<string,int>(0,"36382689960","Azizcan"),
        //    new GenericUser<string,int>(1,"38273782873","Cihan"),
        //    new GenericUser<string,int>(2,"38283289388","Kemal")
        //};
        static List<GenericUser<string, int>> genericUsers = GenericUser<string, int>.GetGenericUsers();

        // GET: api/<UserController>
        [HttpGet("GetAllUsers")]
        public IEnumerable<UserDto> Get()
        {

            //    List<UserDto> users = new List<UserDto>();

            //    foreach (User user in _users)
            //    {
            //        UserDto userDto = new UserDto();
            //        userDto.Id = user.id;
            //        userDto.Name = user.Name;
            //        userDto.Tc = user.Tc;

            //        users.Add(userDto);
            //    }
            //    return users.ToArray();
            //List<UserDto> users = new List<UserDto>();

            //******  DTO and Generic Class implementation  ********//
            
            
            return genericUsers.Select(u => new UserDto() { Id = u.Id, Name = u.Name, Tc = u.Tc }).ToArray();

        }

        // GET api/<UserController>/5
        [HttpGet("GetUserById")]
        public UserDto Get(int id)
        {
            //List<UserDto> users = new List<UserDto>();

            //foreach (User user in _users)
            //{
            //    UserDto userDto = new UserDto();
            //    userDto.Id = user.id;
            //    userDto.Name = user.Name;
            //    userDto.Tc = user.Tc;

            //    users.Add(userDto);
            //}

            //return users.Where(u => u.Id == id).FirstOrDefault();



            //------- Generic implementation ---------//

            var user = genericUsers.Select(u => new UserDto() { Id = u.Id, Name = u.Name, Tc = u.Tc });
            return user.Where(u => u.Id == id).FirstOrDefault();



        }
        [HttpGet("Search")]
        public IEnumerable<UserDto> Search(string keyword)
        {
            //List<UserDto> users = new List<UserDto>();
            //List<UserDto> searchResult = new List<UserDto>();

            //foreach (User user in _users)
            //{
            //    UserDto userDto = new UserDto();
            //    userDto.Id = user.id;
            //    userDto.Name = user.Name;
            //    userDto.Tc = user.Tc;
            //    users.Add(userDto);
            //}

            //foreach (UserDto userDto in users)
            //{
            //    if (userDto.Name.StartsWith(keyword))
            //    {
            //        searchResult.Add(userDto);
            //    }
            //}
            //return searchResult.ToArray();


            
            var user = genericUsers.Where(u => u.Name.StartsWith(keyword) || u.Tc.StartsWith(keyword)).ToList();

            return user.Select(r => new UserDto() { Id = r.Id, Name = r.Name, Tc = r.Tc }).ToList();

        }
        // POST api/<UserController>
        [HttpPost("AddUser")]
        public void Post([FromBody] UserDto value)
        {
            //User user = new User(value.Id,value.Tc,value.Name);

            GenericUser<string,int> newUser = new GenericUser<string, int>(value.Id,value.Tc,value.Name);
            genericUsers.Add(newUser);
            Get();
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public IEnumerable<UserDto> Put(int id, [FromBody] string newName)
        {
            //User user = _users.Where(u => u.id == id).FirstOrDefault();



            //var user = genericUsers.Where(u => u.Id == id).FirstOrDefault();
            //user.
            //UpdateUser(genericUsers,newName,id);
            var user = genericUsers.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı");

            user.Name = newName;

            return Get();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("DeleteUser")]
        public void Delete(int id)
        {
            var user = genericUsers.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı");

            genericUsers.Remove(user);

        }
        
    }
}
