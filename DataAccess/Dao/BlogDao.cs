using System.Collections.Generic;
using System.Linq;
using Dapper;
using MM.Domain.Entity;

namespace DataAccess.Dao
{
    public class BlogDao
    {
        public static List<Blog> GetAllBlogs()
        {
            using (var cnn = ConnectionManager.GetConnection())
            {
                cnn.Open();
                var result = cnn.Query<Blog>(
                    @"SELECT * FROM Blog ").ToList();

                return result;
            }
        }

        public static Blog Create(Blog blog)
        {
            using (var cnn = ConnectionManager.GetConnection())
            {
                cnn.Open();
                cnn.Execute("Insert into Blog (ID,Summary,CreateTime) VALUES (@ID,@Summary,@CreateTime)", blog);

                return blog;
            }
        }

        public static Blog Update(Blog blog)
        {
            using (var cnn = ConnectionManager.GetConnection())
            {
                cnn.Open();
                cnn.Execute("Update Blog set Summary=@Summary,CreateTime=@CreateTime WHERE ID=@ID", blog);

                return blog;
            }
        }

        public static void Delete(string id)
        {
            using (var cnn = ConnectionManager.GetConnection())
            {
                cnn.Open();
                cnn.Execute("Delete from Blog WHERE ID=@ID", new { ID = id });
            }
        }
    }
}
