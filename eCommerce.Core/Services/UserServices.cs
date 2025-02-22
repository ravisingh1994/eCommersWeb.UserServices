using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServicesContract;

namespace eCommerce.Core.Services;

internal class UserServices : IUserServices
{ 
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserServices(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponce?> Login(LogInRequest logInRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(logInRequest.Email, logInRequest.Password);
        if (user == null)
        {
            return null;
        }
        //return new AuthenticationResponce(user.UserId, user.Email, user.PersonName, user.Gender,"token", Sucess: true);
        var response = _mapper.Map<AuthenticationResponce>(user);
        return response with { Sucess = true, Token = "token" };

    }
        

    public async Task<AuthenticationResponce?> RegisterUser(RegisterRequest registerRequest)
    {
        ApplicationUser applicationUser = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = registerRequest.Gender.ToString(),


        };
        ApplicationUser? user = await _usersRepository.AddUser(applicationUser);
        if (user == null)
        {  return null; }
        //return new AuthenticationResponce(user.UserId, user.Email, user.PersonName, user.Gender, "token", Sucess: true);
        var response = _mapper.Map<AuthenticationResponce>(user);
        return response with { Sucess = true, Token = "token" };
    }
}

