using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Labb3ApiRoutes.Data
{
    public class Labb3ApiRouteDbContext : DbContext
    {
        public Labb3ApiRouteDbContext(DbContextOptions<Labb3ApiRouteDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for 3 persons
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "Anna",
                    LastName = "Andersson",
                    PhoneNumber = "+46701234567"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "Björn",
                    LastName = "Bergström",
                    PhoneNumber = "+46707654321"
                },
                new Person
                {
                    PersonId = 3,
                    FirstName = "Cecilia",
                    LastName = "Carlsson",
                    PhoneNumber = "+46708901234"
                },
                new Person
                {
                    PersonId = 4,
                    FirstName = "David",
                    LastName = "Dahlberg",
                    PhoneNumber = "+46707650987"
                },
                new Person
                {
                    PersonId = 5,
                    FirstName = "Emma",
                    LastName = "Eriksson",
                    PhoneNumber = "+46703456789"
                },
                new Person
                {
                    PersonId = 6,
                    FirstName = "Fredrik",
                    LastName = "Fredriksen",
                    PhoneNumber = "+46701234567"
                },
                new Person
                {
                    PersonId = 7,
                    FirstName = "Gustav",
                    LastName = "Gustafsson",
                    PhoneNumber = "+467032165498"
                },
                new Person
                {
                    PersonId = 8,
                    FirstName = "Hanna",
                    LastName = "Hansson",
                    PhoneNumber = "+467017534698"
                },
                new Person
                {
                    PersonId = 9,
                    FirstName = "Isak",
                    LastName = "Isaksson",
                    PhoneNumber = "+46705576543"
                },
                new Person
                {
                    PersonId = 10,
                    FirstName = "Jenny",
                    LastName = "Johansson",
                    PhoneNumber = "+46702876534"
                },
                new Person
                {
                    PersonId = 11,
                    FirstName = "Karl",
                    LastName = "Karlsson",
                    PhoneNumber = "+46705678754"
                },
                new Person
                {
                    PersonId = 12,
                    FirstName = "Lina",
                    LastName = "Lindqvist",
                    PhoneNumber = "+46709124532"
                },
                new Person
                {
                    PersonId = 13,
                    FirstName = "Mikael",
                    LastName = "Månsson",
                    PhoneNumber = "+46704567891"
                },
                new Person
                {
                    PersonId = 14,
                    FirstName = "Nina",
                    LastName = "Nilsson",
                    PhoneNumber = "+46707654321"
                }
            );
            modelBuilder.Entity<Interest>().HasData(
    new Interest
    {
        InterestId = 1,
        InterestTitle = "Gardening",
        InterestDescription = "Growing and caring for plants",
        FK_PersonId = 1
    },
    new Interest
    {
        InterestId = 2,
        InterestTitle = "Cooking",
        InterestDescription = "Preparing and cooking meals",
        FK_PersonId = 2
    },
    new Interest
    {
        InterestId = 3,
        InterestTitle = "Reading",
        InterestDescription = "Enjoying books and literature",
        FK_PersonId = 3
    },
    new Interest
    {
        InterestId = 4,
        InterestTitle = "Hiking",
        InterestDescription = "Exploring nature by foot",
        FK_PersonId = 1
    },
    new Interest
    {
        InterestId = 5,
        InterestTitle = "Photography",
        InterestDescription = "Capturing the world through a lens",
        FK_PersonId = 2
    },
    new Interest
    {
        InterestId = 6,
        InterestTitle = "Drawing",
        InterestDescription = "Creating art with pencils, pens, or other media",
        FK_PersonId = 4
    },
    new Interest
    {
        InterestId = 7,
        InterestTitle = "Camping",
        InterestDescription = "Spending time outdoors and sleeping in a tent",
        FK_PersonId = 5
    },
    new Interest
    {
        InterestId = 8,
        InterestTitle = "Yoga",
        InterestDescription = "Practicing physical and mental exercises for relaxation and well-being",
        FK_PersonId = 6
    },
    new Interest
    {
        InterestId = 9,
        InterestTitle = "Swimming",
        InterestDescription = "Enjoying the water and getting exercise",
        FK_PersonId = 7
    },
    new Interest
    {
        InterestId = 10,
        InterestTitle = "Travel",
        InterestDescription = "Exploring new places and cultures",
        FK_PersonId = 8
    },
    new Interest
    {
        InterestId = 11,
        InterestTitle = "Sports",
        InterestDescription = "Playing and watching athletic games",
        FK_PersonId = 9
    },
    new Interest
    {
        InterestId = 12,
        InterestTitle = "Music",
        InterestDescription = "Listening to and creating music",
        FK_PersonId = 10
    },
    new Interest
    {
        InterestId = 13,
        InterestTitle = "Dancing",
        InterestDescription = "Moving to music for fun and exercise",
        FK_PersonId = 11
    },
    new Interest
    {
        InterestId = 14,
        InterestTitle = "Gaming",
        InterestDescription = "Playing video or board games",
        FK_PersonId = 12
    },
    new Interest
    {
        InterestId = 15,
        InterestTitle = "Programming",
        InterestDescription = "Writing code to create software and websites",
        FK_PersonId = 13
    }
);


            modelBuilder.Entity<Link>().HasData(
                new Link
                {
                    LinkId = 1,
                    LinkTitle = "Gardens World",
                    URL = "https://www.gardenersworld.com/",
                    FK_InterestId = 1,
                    FK_PersonId = 1
                },
                new Link
                {
                    LinkId = 2,
                    LinkTitle = "BBC good food",
                    URL = "https://www.bbcgoodfood.com/",
                    FK_InterestId = 2,
                    FK_PersonId = 2
                },
                new Link
                {
                    LinkId = 3,
                    LinkTitle = "Goddreads",
                    URL = "https://www.goodreads.com/",
                    FK_InterestId = 3,
                    FK_PersonId = 3
                },
                new Link
                {
                    LinkId = 4,
                    LinkTitle = "Alltrails",
                    URL = "https://www.alltrails.com/",
                    FK_InterestId = 4,
                    FK_PersonId = 1
                },
                new Link
                {
                    LinkId = 5,
                    LinkTitle = "National Geo",
                    URL = "https://www.nationalgeographic.com/photography/",
                    FK_InterestId = 5,
                    FK_PersonId = 2
                },
                 new Link
                 {
                     LinkId = 6,
                     LinkTitle = "Health Line",
                     URL = "https://www.healthline.com/nutrition",
                     FK_InterestId = 6,
                     FK_PersonId = 3
                 },
                new Link
                {
                    LinkId = 7,
                    LinkTitle = "NY times",
                    URL = "https://www.nytimes.com/cooking",
                    FK_InterestId = 2,
                    FK_PersonId = 1
                },
                new Link
                {
                    LinkId = 8,
                    LinkTitle = "World Wild Life",
                    URL = "https://www.worldwildlife.org/",
                    FK_InterestId = 4,
                    FK_PersonId = 2
                },
                new Link
                {
                    LinkId = 9,
                    LinkTitle = "The Guardian",
                    URL = "https://www.theguardian.com/books",
                    FK_InterestId = 3,
                    FK_PersonId = 1
                },
                new Link
                {
                    LinkId = 10,
                    LinkTitle = "The Spruce",
                    URL = "https://www.thespruce.com/gardening-4127787",
                    FK_InterestId = 1,
                    FK_PersonId = 2
                },
                new Link
                {
                    LinkId = 11,
                    LinkTitle = "National Parks",
                    URL = "https://www.nationalparks.org/connect/blog",
                    FK_InterestId = 4,
                    FK_PersonId = 3
                },
                new Link
                {
                    LinkId = 12,
                    LinkTitle = "National Geo Travel",
                    URL = "https://www.nationalgeographic.com/travel/",
                    FK_InterestId = 5,
                    FK_PersonId = 1
                },
                new Link
                {
                    LinkId = 13,
                    LinkTitle = "Epicurious",
                    URL = "https://www.epicurious.com/",
                    FK_InterestId = 2,
                    FK_PersonId = 3
                },
                new Link
                {
                    LinkId = 14,
                    LinkTitle = "Goodreads",
                    URL = "https://www.goodreads.com/quotes",
                    FK_InterestId = 3,
                    FK_PersonId = 2
                },              
                new Link
                {
                    LinkId = 15,
                    LinkTitle = "Dpreview",
                    URL = "https://www.dpreview.com/",
                    FK_InterestId = 5,
                    FK_PersonId = 3
                }
            );
        }
    }
}