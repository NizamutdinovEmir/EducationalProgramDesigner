using Itmo.ObjectOrientedProgramming.Lab2.Entities.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository : IRepository
{
    private readonly Dictionary<Guid, IEntity> _elementsOfEntity = [];

    public void Add(IEntity entity)
    {
        if (!_elementsOfEntity.TryAdd(entity.Id, entity))
        {
            throw new ArgumentException("Сущность с таким идентификатором уже существует.");
        }
    }

    public void Remove(IEntity entity)
    {
        if (!_elementsOfEntity.Remove(entity.Id))
        {
            throw new KeyNotFoundException("Сущность с таким идентификатором не найдена.");
        }
    }

    public IEntity? GetById(Guid id)
    {
        return _elementsOfEntity.GetValueOrDefault(id);
    }

    public IEnumerable<IEntity> GetAllElements()
    {
        return _elementsOfEntity.Values;
    }
}