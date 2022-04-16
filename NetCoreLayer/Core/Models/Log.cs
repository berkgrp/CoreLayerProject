using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Log:Base
    {
        [Required(ErrorMessage = "Required Field !"), StringLength(500)]
        public string LogDescription { get; set; }// to define action

        [Required(ErrorMessage = "Required Field !"), StringLength(50)]
        public string LogType { get; set; }// to filter logs

        [Required(ErrorMessage = "Required Field !"), StringLength(5)]
        public string TableID { get; set; }// recording data id to search out.

        [Required(ErrorMessage = "Required Field !"), StringLength(50)]
        public string TableName { get; set; }// recording data table name.

        public bool IsThatLog { get; set; }// is it gonna be notification or not.
        public bool IsThatNotification { get; set; }// is it gonna be notification or not.
        public List<string> ReaderIDs { get; set; } = new List<string>();// if it's notification, we need to keep readers user id.
    }
}
