/// <summary>
/// Inherit from this for DTOs
/// </summary>


namespace App.Application.EntitiesCommandsQueries
{
    public abstract class BaseEntityDTO
    {

        private static readonly string DefaultString = "XXXXXX";
        private static readonly string DefaultDateString = "XX-XX-XXXX";
        public long Id { get; set; }
        public string CreatedBy = DefaultString;
        public string CreatedDate = DefaultDateString;
        public string LastModifiedBy = DefaultString;
        public string LastModifiedDate = DefaultDateString;
    }

}
