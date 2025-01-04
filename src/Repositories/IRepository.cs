using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository
{
    void Add(IEntity entity);

    void Remove(IEntity entity);

    IEntity? GetById(Guid id);

    IEnumerable<IEntity> GetAllElements();
}