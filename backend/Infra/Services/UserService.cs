namespace StarPay.Infra.Services;

public class UserService
{
    private readonly UserManager<User> _userManager;

    private readonly SignInManager<User> _signInManager;

    private readonly Imapper _mapper;

    private UserService(UserManager<User> userManager, Imapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

}