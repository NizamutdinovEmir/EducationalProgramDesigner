using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Lecture.Builders;

public interface ILectureMaterialBuilder
{
    ILectureMaterialBuilder SetName(string name);

    ILectureMaterialBuilder SetDescription(string description);

    ILectureMaterialBuilder SetContent(string content);

    ILectureMaterialBuilder SetAuthor(User author);

    ILectureMaterialBuilder SetBaseLecture(LectureMaterial baseLecture);

    LectureMaterial Build();
}