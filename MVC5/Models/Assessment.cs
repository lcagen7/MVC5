using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfQuestions { get; set; }
        public AssessmentType AssessmentType { get; set; }
    }
}