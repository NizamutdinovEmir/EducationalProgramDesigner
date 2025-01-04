using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture.Builders;

public class LectureMaterialBuilder : ILectureMaterialBuilder
{
    private string? _name;
    private string? _description;
    private string? _content;
    private User? _author;
    private Guid? _baseLectureId;
    private LectureMaterial? _baseLecture;

    public ILectureMaterialBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ILectureMaterialBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public ILectureMaterialBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public ILectureMaterialBuilder SetAuthor(User author)
    {
        _author = author;
        return this;
    }

    public ILectureMaterialBuilder SetBaseLecture(LectureMaterial baseLecture)
    {
        _baseLecture = baseLecture.Clone();
        _baseLectureId = baseLecture.Id;
        return this;
    }

    public LectureMaterial Build()
    {
        if (_baseLecture != null)
        {
            return new LectureMaterial(
                _baseLecture.Name ?? throw new ArgumentNullException(nameof(_baseLecture.Name)),
                _baseLecture.Description ?? throw new ArgumentNullException(nameof(_baseLecture.Description)),
                _baseLecture.Content ?? throw new ArgumentNullException(nameof(_baseLecture.Content)),
                _baseLecture.Author ?? throw new ArgumentNullException(nameof(_baseLecture.Author)))
            {
                BaseLectureId = _baseLectureId ?? throw new ArgumentNullException(nameof(_baseLectureId)),
            };
        }

        return new LectureMaterial(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _content ?? throw new ArgumentNullException(nameof(_content)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}
