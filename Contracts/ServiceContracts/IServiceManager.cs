namespace Api.Contracts.ServiceContracts;

public interface IServiceManager
{
   IPostService PostService { get; }
   IUserService UserService { get; }
   IAuthenticationService AuthenticationService { get; }
}