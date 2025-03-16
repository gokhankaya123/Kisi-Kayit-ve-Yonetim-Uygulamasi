using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Kisiler
    {
        [Key]
        public int Kisi_ID { get; set; }
        public string Kisi_FullName { get; set; }
    }
}
