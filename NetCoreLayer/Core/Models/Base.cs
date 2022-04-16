using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Base
    {
        protected Base()
        {
            DataGuidID = Guid.NewGuid();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DataGuidID { get; set; }

        public int? CreatedUserId { get; set; } //Oluşturan Kullanıcı ID

        public int? ModifiedUserId { get; set; } //Güncelleyen Kullanıcı ID

        public string CreatedUserType { get; set; } //Olusturan Kullanıcı Tipi

        public string ModifiedUserType { get; set; } //Güncelleyen Kullanıcı Tipi

        public DateTime CreatedDate { get; set; } = DateTime.Now; //Oluşturulma Tarihi

        public DateTime? ModifiedDate { get; set; } //Güncellenme Tarihi

        public bool? IsDeleted { get; set; } //Verinin silinme değeri.
    }
}
