using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using IBKS.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using IBKS.Models.Domain;

namespace TestIBKS
{
    public class UnitTest1 
    {
    

        [Fact]
        public void Test1()
        {
            var u = new User
            {
                Name = "Jawad",
                salary = 4400,
                Email = "jawad200@gmail.com",
                Department = "Cmps"

            };

            u.Name = "New Name";
            u.salary = 5000;
            u.Email = "New Email";
            u.Department = "New Department";

            Assert.Equal("New Name", u.Name);
            Assert.Equal(5000, u.salary);
            Assert.Equal("New Email", u.Email);
            Assert.Equal("New Department", u.Department);


        }
        [Fact]
        public void Test2()
        {
            var p = new Project
            {
                ProjName = "Math project",
                Type = "Hardware",
                status = "Complete",
                

            };

            p.ProjName = "New Name";
            p.Type = "New Type";
            p.status = "New status";
            
            
            Assert.Equal("New Name", p.ProjName); // Test Fails if we change New Name
            Assert.Equal("New Type", p.Type);// Test Fails if we change New Type
            Assert.Equal("New status", p.status);// Test Fails if we change New status


        }
    }
}