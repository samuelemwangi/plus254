/// <summary>
/// Common items used in a Query
/// </summary>


namespace App.Application.EntitiesCommandsQueries
{
    public abstract class BaseQuery
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRoles { get; set; }
        public string UserDomain { get; set; }
    }

}
