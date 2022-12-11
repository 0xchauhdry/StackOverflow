using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using StackOverflow.BusinessLayer;

namespace StackOverflow.Classes
{
    public class Tag
    {
        public int Id;
        public string Name;

        //using this constructor before adding to database
        public Tag(string _name)
        {
            Name = _name;
        }

        //using this constructor when making list in question
        public Tag(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public List<Tag> Search(Tag tag)
        {
            AddQuestionBL aBL = new AddQuestionBL();
            return aBL.GetTags(tag.Name);
        }

        public DataTable AddTag(Tag tag)
        {
            AddQuestionBL aBL = new AddQuestionBL();
            return aBL.AddTag(tag.Name);
        }
    }

}