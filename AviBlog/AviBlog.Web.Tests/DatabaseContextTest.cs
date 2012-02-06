using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AviBlog.Core.Context;
using AviBlog.Web.Tests.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviBlog.Web.Tests
{
    [TestClass]
    public class DatabaseContextTest
    {
        [TestMethod]
        public void Should_be_able_to_recreate_a_database()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            IDbConnectionFactory connection = new SqlConnectionFactory(connectionString);
            Database.DefaultConnectionFactory = connection;
            Database.SetInitializer(new BlogDbInitializer());

            var context = new BlogContext(connectionString);
            Assert.IsTrue(context.Posts.Any());
        }
       
        
    }
}
