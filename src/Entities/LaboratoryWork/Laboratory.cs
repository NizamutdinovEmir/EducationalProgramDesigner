using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.LaboratoryWork;

public class Laboratory : ICloneable<Laboratory>, IEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Criteria { get; private set; }

    public int Points { get; private set; }

    public User Author { get; private set; }

    public Guid? BaseLabId { get; internal set; }

    public Laboratory(string name, string description, string criteria, int points, User author)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Criteria = criteria;
        Points = points;
        Author = author;
    }

    public Laboratory Clone()
    {
        return new Laboratory(Name, Description, Criteria, Points, Author)
        {
            BaseLabId = this.Id,
        };
    }

    public void Modify(User author, string? name = null, string? description = null, string? criteria = null)
    {
        if (Author.Id != author.Id)
        {
            throw new UnauthorizedAccessException("You are not authorized to modify this laboratory.");
        }

        if (!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if (!string.IsNullOrEmpty(description))
        {
            Description = description;
        }

        if (!string.IsNullOrEmpty(criteria))
        {
            Criteria = criteria;
        }
    }
}