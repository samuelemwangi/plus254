/// <summary>
/// Inherit from this for view models
/// </summary>


namespace App.Application.EntitiesCommandsQueries
{
    public abstract class BaseViewModel
    {
        public int RequestStatus { get; internal set; }
        public string StatusMessage { get; internal set; }

    }
}
