﻿namespace NetSchool.Context.Seeder;

using NetSchool.Context.Entities;

public class DemoHelper
{
    //public IEnumerable<Book> GetBooks = new List<Book>
    //{
    //    new Book()
    //    {
    //        Uid = Guid.NewGuid(),
    //        Title = "Harry Potter and the Philosopher's Stone",
    //        Author = new Author()
    //        {
    //            Uid = Guid.NewGuid(),
    //            Name = "Joanne",  
    //            Detail = new AuthorDetail()
    //            {
    //                Country = "England",
    //                Family = "Rowling",
    //            }
    //        },
    //        Categories = new List<Category>()
    //        {
    //            new Category()
    //            {
    //                Title = "Child books",
    //            },
    //            new Category()
    //            {
    //                Title = "Fantasy",
    //            }
    //        }
    //    },
    //};

    public IEnumerable<Point> GetPoints = new List<Point>
    {
        new Point()
        {
            Uid = Guid.NewGuid(),
            Title = "Исаакиевский собор",
            Latitude = 59.9343,
            Longitude = 30.3351,
            PointCategory = new PointCategory()
            {
                Uid = Guid.NewGuid(),
                Title = "Собор",
            },
            Feedbacks = new List<Feedback>()
            {

            },
            ImagePathes = new List<ImagePath>()
            {
                
            }
        },
    };
}