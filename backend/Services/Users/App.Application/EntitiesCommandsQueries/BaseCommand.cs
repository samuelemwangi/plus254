/// <summary>
/// Commnon items in a Command
/// </summary>


namespace App.Application.EntitiesCommandsQueries
{
    public abstract class BaseCommand
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRoles { get; set; }
        public string UserDomain { get; set; }

    }

}
