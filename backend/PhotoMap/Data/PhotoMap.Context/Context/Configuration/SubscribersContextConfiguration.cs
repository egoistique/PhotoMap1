using Microsoft.EntityFrameworkCore;
using PhotoMap.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMap.Context;

public static class SubscribersContextConfiguration
{
    public static void ConfigureSubscribers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subscriber>().ToTable("subscribers");
        modelBuilder.Entity<Subscriber>().Property(x => x.Email).IsRequired();
    }
}
