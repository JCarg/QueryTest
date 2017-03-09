
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinqtEST.Models
{
    public class CommentFormModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Comment Priority")]
        public int Priority { get; set; }
        public int Whatever { get; set; }
    }

    public class CommentFormSearchModel
    {
        [Key]
        public int? ID { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Comment Priority")]
        public int? Priority { get; set; }
        public int? Whatever { get; set; }
    }

    public class CommentFormLogic
    {
        private LinqtESTContext Context;

        public CommentFormLogic()
        {
            Context = new LinqtESTContext();
        }

        public IQueryable<CommentFormModel> GetComments(CommentFormSearchModel searchModel)
        {
            var result = Context.CommentFormModels.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.ID.HasValue)
                    result = result.Where(x => x.ID == searchModel.ID);
                if (!string.IsNullOrEmpty(searchModel.Name))
                    result = result.Where(x => x.Name.Contains(searchModel.Name));
                if (!string.IsNullOrEmpty(searchModel.Comment))
                    result = result.Where(x => x.Comment.Contains(searchModel.Comment));
                if (searchModel.Priority.HasValue)
                    result = result.Where(x => x.Priority == searchModel.Priority);
                if (searchModel.Whatever.HasValue)
                    result = result.Where(x => x.Whatever == searchModel.Whatever);

            }
            return result;
        }
    }

}