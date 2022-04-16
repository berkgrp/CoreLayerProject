using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class FileRepo : Base
    {
        [Key]
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }//Extension of photo such as .png or .jpg
        public string FilePath { get; set; }
        public bool FilePhotoIsDefault { get; set; }
        public byte[] FileData { get; set; }//Data of photo
    }
}
