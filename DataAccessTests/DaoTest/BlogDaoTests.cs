using System;
using DataAccess.Dao;
using MM.Domain.Entity;
using NUnit.Framework;

namespace DataAccessTests.DaoTest
{
    [TestFixture]
    public class BlogDaoTests
    {
        [Test]
        public void GetAllBlogsTest()
        {
            Assert.NotNull(BlogDao.GetAllBlogs());
        }

        [Test]
        public void TestAddBlog()
        {
            BlogDao.Delete("0fd98278b1a549638556ca029b1dffe8");
            BlogDao.Delete("3b5df9babcc64ec4a49599e10272c365");

            var blog = new Blog();
            blog.Summary = "";
            blog.CreateTime = DateTime.Now;
            blog.ID = Guid.NewGuid().ToString("N");

            BlogDao.Create(blog);

            blog.Summary = "<p>&nbsp;&nbsp;直接抢劫了现成的模板,在网络上挖上一个专属自己的坑。</p>";
            BlogDao.Update(blog);

            BlogDao.Delete(blog.ID);
        }
    }
}
