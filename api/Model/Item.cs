using System;
using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class Item
    {
        [Key]
        public Int64 item_id { get; set; }
        public Int64 board_id { get; set; }
        public string title { get; set; }
        public string contents { get; set; }
        public string creator { get; set; }
        public Boolean deleted { get; set; }
        public DateTimeOffset created_dt { get; set; }
        public DateTimeOffset updated_dt { get; set; }
    }
}
