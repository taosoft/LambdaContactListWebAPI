namespace LambdaContactListWebAPI.Models
{
    public class UpdateContactModel : ContactModel
    {
        /// <summary>
        /// Class to receive Contact data for update
        /// -It adds an id (key from Dictionary) to identify
        /// </summary>
        public int Id { get; set; }
    }
}
