using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServicesContract
{
   /// <summary>
///     contract for users services  that contains use case for user
/// </summary>
    public interface IUserServices
    {
        /// <summary>
        /// Method to handle user login and return AuthenticationResponce object that contain status of login
        /// </summary>
        /// <param name="logInRequest"></param>
        /// <returns></returns>
       Task<AuthenticationResponce?> Login(LogInRequest logInRequest);

        /// <summary>
        /// Method to handle user Registration process and return AuthenticationResponce object that contain status of user Registration
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponce?> RegisterUser(RegisterRequest registerRequest);
    }
}
