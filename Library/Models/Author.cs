using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {
        public Author()
        {
            this.JoinEntries = new HashSet<AuthorBook>(); //creating an empty hash set of course students. HashSet is an unordered collection of unique elements. "Studends" would be more accurately named "JoinEntries" since it is a HashSet of CourseStudents.
        }
        [DisplayName("Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        public int AuthorId { get; set; }

        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
        public virtual ICollection<AuthorBook> JoinEntries { get; set; } //IColletion is basically a list. The ICollection<T> interface is the base interface for classes in the System.Collections.Generic namespace.
    }
}

