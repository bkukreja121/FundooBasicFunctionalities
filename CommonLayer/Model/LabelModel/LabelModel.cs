using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model.LabelModel
{
   
        public class LabelModel
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public long UserId { get; set; }
       
        public int Id { get; set; }

        
      
       
       
        public string Title { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
      
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
      
       
          /// foreign key..               
    }
    }

