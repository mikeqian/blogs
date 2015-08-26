using System;
using System.Collections.Generic;
using DataAccess.Dao;
using MM.Domain.Entity;

namespace Application
{
    public static class BlogManager
    {
        public static List<Blog> GetBlogs()
        {
            return BlogDao.GetAllBlogs();
        }

        public static void AddBlog(Blog blog)
        {
            BlogDao.Create(blog);
        }

        public static void UpdateBlog(Blog blog)
        {
            BlogDao.Update(blog);
        }

        public static void DeleteBloe(string id)
        {
            BlogDao.Delete(id);
        }
    }
}