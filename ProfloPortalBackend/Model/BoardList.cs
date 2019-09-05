using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfloPortalBackend.Model
{
    public class BoardList
    {
        public string ListId { get; set; }
        
        public string ListName { get; set; }
        
        public int ListPosition { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
