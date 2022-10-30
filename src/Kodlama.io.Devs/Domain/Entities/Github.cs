using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Github : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public virtual User? User { get; set; }

        public Github(int id, int userId, string githubUrl, User? user) : this()
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;
            User = user;
        }

        public Github()
        {

        }
    }
}
