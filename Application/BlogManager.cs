using System;
using System.Collections.Generic;
using MM.Domain.Entity;

namespace Application
{
    public static class BlogManager
    {
        public static List<Blog> GetBlogs()
        {
            var result = new List<Blog>();

            var t = new Blog();
            t.CreateTime = new DateTime(2015, 8, 26, 13, 30, 0, 0);
            t.Summary = "<p>&nbsp;&nbsp;直接抢劫了现成的模板,在网络上挖上一个专属自己的坑。</p>";

            result.Add(t);

            return result;
        }
    }
}
