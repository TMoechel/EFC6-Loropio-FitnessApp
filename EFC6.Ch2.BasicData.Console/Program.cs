using EfC6.Ch2.FitnessApp.Data;
using EFC6.Ch2.BasicData.Domain;

using (FitnessAppContext context = new FitnessAppContext())
{
    context.Database.EnsureCreated();
}
AddAcitivity();
GetActivities();
Console.WriteLine("DB was created and run activities displyed");

void AddAcitivity()
{
    var activity = new RunActivity() { Name = "Jogging in the morning", Distance = 100 };
    var context = new FitnessAppContext();
    context.RunActivities.Add(activity);
    context.SaveChanges();
}
void GetActivities()
{
    using var context = new FitnessAppContext();
    var activities = context.RunActivities.ToList();
    if (activities.Any())
        foreach (var activity in activities)
        {
            Console.WriteLine($"{activity.Name} {activity.Distance}");
        }
    else
        Console.WriteLine("No activities recorded yet");

}