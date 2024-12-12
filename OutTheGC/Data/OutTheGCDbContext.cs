using System;
using Microsoft.EntityFrameworkCore;
using OutTheGC.Models;
namespace OutTheGC.Data;

public class OutTheGCDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTrip> UserTrips { get; set; }
    public DbSet<UserVote> UsersVotes { get; set; }
    public DbSet<TripInvitation> TripInvitations { get; set; }

    public OutTheGCDbContext(DbContextOptions<OutTheGCDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Users can have many comments
        modelBuilder.Entity<User>()
            .HasMany(e => e.Comments)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        // Users can have many activities
        modelBuilder.Entity<User>()
            .HasMany(e => e.Activities)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        // Trip can have many activities and will remove all the associated activities on delete
        modelBuilder.Entity<Trip>()
            .HasMany(e => e.Activities)
            .WithOne(e => e.Trip)
            .HasForeignKey(e => e.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        // Activity can have many comments and will remove all the associated comments on delete
        modelBuilder.Entity<Activity>()
            .HasMany(e => e.Comments)
            .WithOne()
            .HasForeignKey(e => e.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        // A trip can have many users and vice versa
        modelBuilder.Entity<User>()
            .HasMany(e => e.Trips)
            .WithMany(e => e.Participants)
            .UsingEntity<UserTrip>();

        // User can own multiple trips
        modelBuilder.Entity<Trip>()
            .HasOne(e => e.Owner)            
            .WithMany()                      
            .HasForeignKey(e => e.UserId);

        // An activity can have many uservotes and user can vote on multiple activities
        modelBuilder.Entity<Activity>()
            .HasMany(uv => uv.Votes)
            .WithMany(uv => uv.VotedActvities)
            .UsingEntity<UserVote>();

        modelBuilder.Entity<Trip>()
            .HasMany(t => t.SentInvitations)
            .WithOne(si => si.Trip)
            .HasForeignKey(t => t.TripId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Invitations)
            .WithOne()
            .HasForeignKey(u => u.SenderId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Invitations)
            .WithOne()
            .HasForeignKey(u => u.RecipientId);

        modelBuilder.Entity<Activity>().HasData(ActivityData.Activities);
        modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
        modelBuilder.Entity<Comment>().HasData(CommentData.Comments);
        modelBuilder.Entity<Trip>().HasData(TripData.Trips);
        modelBuilder.Entity<User>().HasData(UserData.Users);
        modelBuilder.Entity<UserTrip>().HasData(UserTripData.UserTrips);
        modelBuilder.Entity<UserVote>().HasData(UserVoteData.UsersVotes);
    }
}
