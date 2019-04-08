namespace LambdaContactListWebAPI.Models
{
    public class ReturnMessage
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        /// <summary>
        /// Class constructor
        /// -Assign data to class Properties
        /// </summary>
        /// <param name="error">Exists error?</param>
        /// <param name="message">Message to return</param>
        public ReturnMessage(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
