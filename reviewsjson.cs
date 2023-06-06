using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviews
{
    
    public class reviewsjson
    {
        
        
        
            public int Id { get; set; }
            public string ReviewId { get; set; }
            public string ReviewFullText { get; set; }
            public string ReviewText { get; set; }
            public int NumLikes { get; set; }
            public int NumComments { get; set; }
            public int NumShares { get; set; }
            public int Rating { get; set; }
            public string ReviewCreatedOn { get; set; }
            public DateTime ReviewCreatedOnDate { get; set; }
            public int ReviewCreatedOnTime { get; set; }
            public string ReviewerId { get; set; }
            public string ReviewerUrl { get; set; }
            public string ReviewerName { get; set; }
            public string ReviewerEmail { get; set; }
            public string SourceType { get; set; }
            public bool IsVerified { get; set; }
            public string Source { get; set; }
            public string SourceName { get; set; }
            public string SourceId { get; set; }
            public List<string> Tags { get; set; }
            public string Href { get; set; }
            public string LogoHref { get; set; }
            public List<string> Photos { get; set; }
        
       
    }
    }
