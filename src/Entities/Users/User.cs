using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

public class User : IEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}