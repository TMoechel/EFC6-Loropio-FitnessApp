using EfC6.Ch2.FitnessApp.Data;
using EFC6.Ch2.FitnessApp.Domain;
using Microsoft.EntityFrameworkCore;

using (FitnessAppContext context = new FitnessAppContext())
{
    context.Database.EnsureCreated();
}
AddUsers();
GetActivities();
Console.WriteLine("DB was created and run activities displyed");

void AddUsers()
{
    var user = new User() { 
        FirstName = "Mike", 
        LastName ="Miller" };
    
    user.RunActivities.Add(new RunActivity { Name = "Run from Lodwar to Loropio", Distance = 20 });
    user.RunActivities.Add(new RunActivity { Name = "Run from Maralal to Wamba", Distance = 30 });

    var context = new FitnessAppContext();
    context.Users.Add(user);
    context.SaveChanges();
}
void GetActivities()
{
    using var context = new FitnessAppContext();

    var users = context.Users.Include(user => user.RunActivities).ToList();
    if (users.Any())
        foreach (var user in users)
        {
            Console.WriteLine($"First Name: {user.FirstName} Last Name: {user.LastName}");
            foreach(var activity in user.RunActivities)
            {
                Console.WriteLine($"Name of Activity: {activity.Name} Distance: {activity.Distance}");
            }
        }
    else
        Console.WriteLine("No activities recorded yet");

}