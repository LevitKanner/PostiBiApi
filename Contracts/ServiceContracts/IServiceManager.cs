namespace Api.Contracts.ServiceContracts;

public interface IServiceManager
{
   IPostService PostService { get; }
   IAuthenticationService AuthenticationService { get; }
}