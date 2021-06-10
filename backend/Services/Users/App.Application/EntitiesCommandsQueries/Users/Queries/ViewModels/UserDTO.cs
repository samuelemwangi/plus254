using App.Domain.Entities.Identity;
using System;
using System.Linq.Expressions;


/// <summary>
/// Basic Details
/// </summary>

namespace App.Application.EntitiesCommandsQueries.Users.Queries.ViewModels
{
    public class UserDTO : BaseEntityDTO
    {
        public new string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }

        public static Expression<Func<User, UserDTO>> Projection
        {
            get
            {
                return u => new UserDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserEmail = u.UserEmail,

                };
            }
        }


    }
}
