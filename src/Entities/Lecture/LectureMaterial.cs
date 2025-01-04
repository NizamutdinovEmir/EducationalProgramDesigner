using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture;

public class LectureMaterial : ICloneable<LectureMaterial>, IEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public User Author { get; private set; }

    public Guid? BaseLectureId { get; internal set; }

    public LectureMaterial(string name, string description, string content, User author)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    public LectureMaterial Clone()
    {
        return new LectureMaterial(Name, Description, Content, Author)
        {
            BaseLectureId = this.Id,
        };
    }

    public void Modify(User author, string? name = null, string? description = null, string? content = null)
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

        if (!string.IsNullOrEmpty(content))
        {
            Content = content;
        }
    }
}