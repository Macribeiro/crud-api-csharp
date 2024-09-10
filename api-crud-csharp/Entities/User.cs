using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_crud_csharp.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Departament { get; set; }
        public required string Address { get; set; }
    }
}
