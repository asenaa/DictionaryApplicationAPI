using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryApplication.Models
{
    public partial class Word
    {
        [Key]
        public int Id { get; set; }
        [Column("Word_En")]
        public string WordEn { get; set; }
        [Column("Word_Tr")]
        public string WordTr { get; set; }
    }
}
