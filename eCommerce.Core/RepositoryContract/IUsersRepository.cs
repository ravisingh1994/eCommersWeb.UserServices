using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContract;

    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add user to the Data Store and return Add User
        /// </summary>
        /// <param name="applicationUser"></param>
        /// <returns></returns>
       Task<ApplicationUser?> AddUser(ApplicationUser applicationUser);
        /// <summary>
        /// Methed to Get User Using Email and Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
